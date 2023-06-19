using ProjektTurnieju.Models;
using ProjektTurnieju.Data;
using Microsoft.EntityFrameworkCore;

namespace ProjektTurnieju.DBActions
{

    public class DBUzytkownik
    {
		TurniejDBContext context = new TurniejDBContext();
		public void Dodaj(Uzytkownik uzytkownik)
        {
			uzytkownik.CzyMaDruzyne = false;
            context.Add(uzytkownik);
            context.SaveChanges();
        }
		public void Usun(Uzytkownik uzytkownik,int Id)
		{
			uzytkownik.Id = Id;
			context.Entry(uzytkownik).State = EntityState.Deleted;
			context.Remove(uzytkownik);

            context.SaveChanges();
		}

		public void Zmodyfikuj(Uzytkownik uzytkownik, int Id)
		{
			uzytkownik.Id = Id;
			context.Entry(uzytkownik).State = EntityState.Modified;
			context.SaveChanges();
		}

		public Uzytkownik getOne(int id)
		{
			Uzytkownik uzytkownik = new Uzytkownik();
			var bazadanych = context.Uzytkownicy;

			uzytkownik = bazadanych.Find(id);

			return uzytkownik;
		}
		public List<Uzytkownik> getList()
		{
			List<Uzytkownik> lista = new List<Uzytkownik>();
			var uzytkownicy = context.Uzytkownicy;

			foreach (Uzytkownik u in uzytkownicy)
			{
				lista.Add(u);
			}

			return lista;
		}

	}
}
