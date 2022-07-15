using Ejercicio2_4ANGELGARCIA.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_4ANGELGARCIA.Controller
{
    public class BaseDatos
    {
        readonly SQLiteAsyncConnection basedatos;

        public BaseDatos(string path)
        {
            basedatos = new SQLiteAsyncConnection(path);

            basedatos.CreateTableAsync<Video>();
        }

        #region OperacionesVideo
        //Metodos CRUD - CREATE
        public Task<int> insertUpdateVideo(Video video)
        {
            if (video.id != 0)
            {
                return basedatos.UpdateAsync(video);
            }
            else
            {
                return basedatos.InsertAsync(video);
            }
        }

        //Metodos CRUD - READ
        public Task<List<Video>> getListVideo()
        {
            return basedatos.Table<Video>().ToListAsync();
        }

        public Task<Video> getVideo(int id)
        {
            return basedatos.Table<Video>()
                .Where(i => i.id == id)
                .FirstOrDefaultAsync();
        }

       

        #endregion OperacionesVideo

    }
}
