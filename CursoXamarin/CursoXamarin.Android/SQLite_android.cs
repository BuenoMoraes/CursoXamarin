using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CursoXamarin.Data;
using CursoXamarin.Droid;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_android))]
namespace CursoXamarin.Droid
{
    class SQLite_android : ISQLite
    {
        private const string nomeArquivoDB = "Agendamento.db3";

        public SQLiteConnection PegarConexao()
        {
            var caminhoDB = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path,
                nomeArquivoDB);

            return new SQLite.SQLiteConnection(nomeArquivoDB);
        }
    }
}