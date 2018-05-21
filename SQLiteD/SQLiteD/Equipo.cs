using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteD
{
    public class Equipo
    {
        [PrimaryKey, AutoIncrement]
        public int Idc { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
        public string Cliente { get; set; }

        public string NombreCompleto
        {
            get
            {
                return string.Format("Marca: {0}  Modelo: {1}  Serie: {2}", this.Marca, this.Modelo, this.Serie);
            }
        }
        public override string ToString()
        {
            return string.Format("Id: {0} {1}", Idc, NombreCompleto);
        }
    }

    
}
