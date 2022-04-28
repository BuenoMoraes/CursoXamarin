using CursoXamarin.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursoXamarin.Data
{
    class AgendamentoDAO
    {
        SQLiteConnection conexao;
        public AgendamentoDAO(SQLiteConnection conexao)
        {
            this.conexao = conexao;
            this.conexao.CreateTable<Agendamento>();
        }

        public void Salvar(Agendamento agendamento)
        {
            this.conexao.Insert(agendamento);
        }
    }
}
