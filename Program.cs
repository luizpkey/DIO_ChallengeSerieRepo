using System;
namespace DIO.Series
{
  class Program
  {
    static SerieRepository repository = new SerieRepository();
    static void Main(string[] args)
    {
      string optionUser = GetOptionUser();

      while (optionUser != "X")
      {
        switch (optionUser)
        {
          case "1":
            SerieList();
            break;
          case "2":
            InsertSerie();
            break;
          case "3":
            RefreshSerie();
            break;
          case "4":
            DeleteSerie();
            break;
          case "5":
            ViewSeries();
            break;
          case "C":
            Console.Clear();
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }
        optionUser = GetOptionUser();
      }
      Console.WriteLine("Obrigado por utilizar nossos serviços.");
      Console.WriteLine();

    }

    private static void ViewSeries()
    {
      Console.WriteLine("Digite o Id da série: ");
      int id = int.Parse(Console.ReadLine());
      var serie = repository.ReturnById(id);
      Console.WriteLine(serie);
    }

    private static void DeleteSerie()
    {
      Console.WriteLine("Digite o Id da série: ");
      int id = int.Parse(Console.ReadLine());
      repository.Delete(id:id);
    }

    private static void RefreshSerie()
    {
      Console.WriteLine("Digite o Id da série: ");
      int id = int.Parse(Console.ReadLine());
//      var serie = repository.ReturnById(id);
      foreach (int i in Enum.GetValues(typeof(Gender)))
      {
        Console.WriteLine($"{i}-{Enum.GetName(typeof(Gender), i)}");
      }
      Console.WriteLine("Digite o genêro entra as opções acima: ");
      int genderId = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o Título da Série: ");
      string title = Console.ReadLine();

      Console.WriteLine("Digite o Ano de Ínicio da Série: ");
      int year = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite a Descrição da Série: ");
      string description = Console.ReadLine();

      Serie serie = new Serie(id: id,
                              gender: (Gender)genderId,
                              title: title,
                              year: year,
                              description: description);
      repository.Insert(serie);
      repository.Refresh(id:id, entidy:serie);
    }

    private static string GetOptionUser()
    {
      Console.WriteLine();
      Console.WriteLine("DIO Séries a seu dispor!!!");
      Console.WriteLine("Informe a opção desejada:");

      Console.WriteLine("1- Listar séries");
      Console.WriteLine("2- Inserir nova série");
      Console.WriteLine("3- Atualizar série");
      Console.WriteLine("4- Excluir série");
      Console.WriteLine("5- Visualizar série");
      Console.WriteLine("C- Limpar Tela");
      Console.WriteLine("X- Sair");
      Console.WriteLine();

      string optionUser = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return optionUser;
    }

    private static void InsertSerie()
    {
       foreach ( int i in Enum.GetValues(typeof(Gender)))
       {
        Console.WriteLine( $"{i}-{Enum.GetName(typeof(Gender), i)}" );
       }
       Console.WriteLine("Digite o genêro entra as opções acima: "); 
       int genderId = int.Parse( Console.ReadLine());
       
       Console.WriteLine("Digite o Título da Série: "); 
       string title = Console.ReadLine();
       
       Console.WriteLine("Digite o Ano de Ínicio da Série: "); 
       int year = int.Parse( Console.ReadLine());
       
       Console.WriteLine("Digite a Descrição da Série: "); 
       string description = Console.ReadLine();

       Serie newSerie = new Serie( id: repository.NextId(),
                                  gender: (Gender)genderId,
                                  title:title,
                                  year:year,
                                  description:description);
        repository.Insert(newSerie);
    }
    private static void SerieList()
    {
      Console.WriteLine("Listar séries");
      var list = repository.List();

      if (list.Count == 0)
      {
        Console.WriteLine("Nenhuma série cadastrada.");
      }
      foreach (var serie in list )
      {
        var deleted = serie.isDeleted() ? "(Excluido)" : "";
        Console.WriteLine($"#ID {serie.returnId()} - {serie.returnTitle()} {deleted}" ); 
      }
    }
  }
}
