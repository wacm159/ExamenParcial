using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SQLiteD
{
    public class DataAccess : IDisposable
    {
        private SQLiteConnection connection;
        public DataAccess()
        {
            var config = DependencyService.Get<IConfig>();
            connection = new SQLiteConnection(config.Plataforma,
            System.IO.Path.Combine(config.DirectorioDB, "Equipos.db3"));
            connection.CreateTable<Equipo>();
        }
        public void InsertEquipo(Equipo equipo)
        {
            connection.Insert(equipo);
        }
        public void UpdateEquipo(Equipo equipo)
        {
            connection.Update(equipo);
        }
        public void DeleteEquipo(Equipo equipo)
        {
            connection.Delete(equipo);
        }
        public Equipo GetEquipo(int Idc)
        {
            return connection.Table<Equipo>().FirstOrDefault(c => c.Idc == Idc 
            );
        }
        public List<Equipo> GetEquipo()
        {
            return connection.Table<Equipo>().OrderBy(c => c.Idc).ToList();
        }
        public void Dispose()
        {
            connection.Dispose();
        }
    }
}

