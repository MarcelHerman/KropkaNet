using ProjektTurnieju.Models;
using ProjektTurnieju.Data;
using Microsoft.EntityFrameworkCore;

namespace ProjektTurnieju.DBActions
{

    public class DBDruzyna
    {
		TurniejDBContext context = new TurniejDBContext();
		public void Dodaj(Druzyna druzyna)
        {
            context.Add(druzyna);
            context.SaveChanges();
        }
		public void Usun(Druzyna druzyna,int Id)
		{
			druzyna.Id = Id;
			context.Entry(druzyna).State = EntityState.Deleted;
			context.Remove(druzyna);

            context.SaveChanges();
		}

		public void Zmodyfikuj(Druzyna druzyna, int Id)
		{
			druzyna.Id = Id;
			context.Entry(druzyna).State = EntityState.Modified;
			context.SaveChanges();
		}

		public Druzyna getOne(int id)
		{
			Druzyna druzyna= new Druzyna();
			var bazadanych = context.Druzyny;

			druzyna = bazadanych.Find(id);

			return druzyna;
		}
		public List<Druzyna> getList()
		{
			List<Druzyna> lista = new List<Druzyna>();
			var druzyny = context.Druzyny;

			foreach (Druzyna d in druzyny)
			{
				lista.Add(d);
			}

			return lista;
		}

	}
}
