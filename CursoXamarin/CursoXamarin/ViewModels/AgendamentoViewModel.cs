using CursoXamarin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CursoXamarin.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {

        const string URL_POST_AGENDAMENTO = "https://aluracar.herokuapp.com/salvaragendamento";

        public Agendamento Agendamento { get; set; }
        public Veiculo Veiculo
        {
            get
            {
                return Agendamento.Veiculo;
            }
            set
            {
                Agendamento.Veiculo = value;
            }
        }

        public string Nome
        {
            get
            {
                return Agendamento.Nome;
            }
            set
            {
                Agendamento.Nome = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }

        }

        public string Fone
        {
            get
            {
                return Agendamento.Fone;
            }
            set
            {
                Agendamento.Fone = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }

        }
        public string Email
        {
            get
            {
                return Agendamento.Email;
            }
            set
            {
                Agendamento.Email = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }


        }

        DateTime dataAgendamento = DateTime.Today;

        public DateTime DataAgendamento
        {
            get
            {
                return Agendamento.DataAgendamento;
            }
            set
            {
                Agendamento.DataAgendamento = value;
            }
        }

        public TimeSpan HoraAgendamento
        {
            get
            {
                return Agendamento.HoraAgendamento;
            }
            set
            {
                Agendamento.HoraAgendamento = value;
            }

        }
        public AgendamentoViewModel(Veiculo veiculo)
        {
            this.Agendamento = new Agendamento();
            this.Agendamento.Veiculo = veiculo;

            AgendarCommand = new Command(() =>
            {
                MessagingCenter.Send<Agendamento>(this.Agendamento
                    , "Agendamento");
            }, () =>
            {
                return !string.IsNullOrEmpty(this.Nome)
                 && !string.IsNullOrEmpty(this.Fone)
                 && !string.IsNullOrEmpty(this.Email);
            });

        }

        public ICommand AgendarCommand { get; set; }

        public async void SalvarAgendamento()
        {
            using (var cliente = new HttpClient())
            {
                cliente.Timeout = TimeSpan.FromSeconds(200);
                var camposFormulario = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>("nome", "Cadastro via Xamarin"),
                        new KeyValuePair<string, string>("telefone", "1234-5678"),
                        new KeyValuePair<string, string>("email", "cadastro@gmail.com"),
                        new KeyValuePair<string, string>("modelo", Veiculo.Nome),
                        new KeyValuePair<string, string>("preco", Convert.ToString(Veiculo.Preco)),
                        new KeyValuePair<string, string>("data", "2022-02-04 12:00")
                    });
                var resultado = await cliente.PostAsync("http://192.168.0.47:8000/api/agendamentos", camposFormulario);
            }
                /*HttpClient cliente = new HttpClient();

                var dataHoraAgendamento = new DateTime(
                    DataAgendamento.Year, DataAgendamento.Month, DataAgendamento.Day,
                    HoraAgendamento.Hours, HoraAgendamento.Minutes, HoraAgendamento.Seconds);

                var json = JsonConvert.SerializeObject(new
                {
                    nome = Nome,
                    fone = Fone,
                    email = Email,
                    carro = Veiculo.Nome,
                    preco = Veiculo.Preco,
                    dataAgendamento = dataHoraAgendamento
                });

                var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

                var resposta = await cliente.PostAsync(URL_POST_AGENDAMENTO, conteudo);

                if (resposta.IsSuccessStatusCode)
                    MessagingCenter.Send<Agendamento>(this.Agendamento, "SucessoAgendamento");
                else
                    MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaAgendamento");*/


            }

    }
}
