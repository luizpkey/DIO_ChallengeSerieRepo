using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
  public class SerieRepository : iRepository<Serie>
  {
    private List<Serie> serieList = new List<Serie>();
    public void Delete(int id)
    {
      serieList[id].Del();
    }

    public void Insert(Serie entidy)
    {
      this.serieList.Add(entidy);
    }

    public List<Serie> List()
    {
      return serieList;
    }

    public int NextId()
    {
      return serieList.Count;
    }

    public void Refresh(int id, Serie entidy)
    {
      serieList[id]=entidy;
    }

    public Serie ReturnById(int id)
    {
      return serieList[id];
    }
  }
}