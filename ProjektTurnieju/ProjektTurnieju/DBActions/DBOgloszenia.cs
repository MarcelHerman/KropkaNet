using ProjektTurnieju.Models;
using ProjektTurnieju.Data;
using Microsoft.EntityFrameworkCore;

namespace ProjektTurnieju.DBActions
{

    public class DBOgloszenia
    {
		TurniejDBContext context = new TurniejDBContext();
		public void Dodaj(Ogloszenie ogloszenie)
        {
            context.Add(ogloszenie);
            context.SaveChanges();
        }
		public void Usun(Ogloszenie ogloszenie,int Id)
		{
			ogloszenie.Id = Id;
			context.Entry(ogloszenie).State = EntityState.Deleted;
			context.Remove(ogloszenie);

            context.SaveChanges();
		}

		public void Zmodyfikuj(Ogloszenie ogloszenie, int Id)
		{
			ogloszenie.Id = Id;
			context.Entry(ogloszenie).State = EntityState.Modified;
			context.SaveChanges();
		}

		public Ogloszenie getOne(int id)
		{
			Ogloszenie ogloszenie = new Ogloszenie();
			var bazadanych = context.Ogloszenia;

			ogloszenie = bazadanych.Find(id);

			return ogloszenie;
		}
		public List<Ogloszenie> getList()
		{
			List<Ogloszenie> lista = new List<Ogloszenie>();
			var ogloszenie = context.Ogloszenia;

			foreach (Ogloszenie o in ogloszenie)
			{
				lista.Add(o);
			}

			return lista;
		}

	}
}
