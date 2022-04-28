using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursoXamarin.Data
{
    public interface ISQLite
    {
        SQLiteConnection PegarConexao();
    }
}
