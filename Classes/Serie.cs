namespace DIO.Series
{
    public class Serie : EntidyBase
    {
        
        private Gender Gender { get; set;}
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Deleted{ get; set; }

        public Serie( int id, Gender gender, string title, string description, int year){
            this.Id = id;
            this.Gender = gender;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string whoMe = "";
            whoMe += this.Deleted?"(Excluido)":"";
            whoMe += "Gênero: " + this.Gender + Environment.NewLine;
            whoMe += "Título: " + this.Title + Environment.NewLine;
            whoMe += "Descrição: " + this.Description + Environment.NewLine;
            whoMe += "Ano de Ínicio: " + this.Year + Environment.NewLine;
            return whoMe;
        }

        public string returnTitle()
        {
            return this.Title;
        }

        public int returnId()
        {
            return this.Id;
        }

        public bool isDeleted()
        {
            return this.Deleted;
        }
        public void Del()
        {
            this.Deleted = true;
        }
    }
}