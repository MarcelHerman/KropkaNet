using ProjektTurnieju.Models;
using ProjektTurnieju.Data;
using Microsoft.EntityFrameworkCore;

namespace ProjektTurnieju.DBActions
{

    public class DBTurniej
    {
        TurniejDBContext context = new TurniejDBContext();
        public void Dodaj(Turniej turniej)
        {
            context.Add(turniej);
            context.SaveChanges();
        }
        public void Usun(Turniej turniej, int Id)
        {
            turniej.Id = Id;
            context.Entry(turniej).State = EntityState.Deleted;
            context.Remove(turniej);

            context.SaveChanges();
        }

        public void Zmodyfikuj(Turniej turniej, int Id)
        {
            turniej.Id = Id;
            context.Entry(turniej).State = EntityState.Modified;
            context.SaveChanges();
        }

        public Turniej getOne(int id)
        {
            Turniej turniej = new Turniej();
            var bazadanych = context.Turniej;

            turniej = bazadanych.Find(id);

            return turniej;
        }
        public List<Turniej> getList()
        {
            List<Turniej> lista = new List<Turniej>();
            var turniej = context.Turniej;

            foreach (Turniej t in turniej)
            {
                lista.Add(t);
            }

            return lista;
        }
    }
}
