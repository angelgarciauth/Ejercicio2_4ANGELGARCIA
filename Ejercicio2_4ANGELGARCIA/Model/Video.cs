using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio2_4ANGELGARCIA.Model
{
    public class Video
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string descripcion { get; set; }
        public string url { get; set; }
        public DateTime fecha { get; set; }
    }
}
