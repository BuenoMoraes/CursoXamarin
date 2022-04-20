using System;
using CursoXamarin.Models;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace CursoXamarin.ViewModels
{
    public class DetalheViewModel : BaseViewModel
    {
        public Veiculo Veiculo { get; set; }

        public string TextoFreioABS
        {
            get
            {
                return string.Format("Freio ABS - R$ {0}", Veiculo.freio_abs);
            }
        }

        public string TextoArCondicionado
        {
            get
            {
                return string.Format("Ar Condicionado - R$ {0}", Veiculo.ar_condicionado);
            }
        }

        public string TextoMP3Player
        {
            get
            {
                return string.Format("MP3 Player - R$ {0}", Veiculo.mp3_player);
            }
        }

        public bool TemFreioABS
        {
            get
            {
                return Veiculo.TemFreioABS;
            }
            set
            {
                Veiculo.TemFreioABS = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public bool TemArCondicionado
        {
            get
            {
                return Veiculo.TemArCondicionado;
            }
            set
            {
                Veiculo.TemArCondicionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public bool TemMP3Player
        {
            get
            {
                return Veiculo.TemMP3Player;
            }
            set
            {
                Veiculo.TemMP3Player = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public string ValorTotal
        {
            get
            {
                return Veiculo.PrecoTotalFormatado;


            }
        }

        public DetalheViewModel(Veiculo veiculo)
        {

            this.Veiculo = veiculo;
            ProximoCommand = new Command(() =>
            {
                MessagingCenter.Send(veiculo, "Proximo");
            });
        }



        public ICommand ProximoCommand { get; set; }

    }
}
