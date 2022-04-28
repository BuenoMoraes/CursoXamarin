using CursoXamarin.Media;
using CursoXamarin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CursoXamarin.ViewModels
{
    public class MasterViewModel : BaseViewModel
    {
        public string Nome
        {
            get
            {
                return this.usuario.nome;
            }
            set
            {
                this.usuario.nome = value;
            }
        }

        public string Email
        {
            get { return this.usuario.email; }
            set
            {
                this.usuario.email = value;
            }
        }

        public string DataNascimento
        {
            get { return usuario.dataNascimento; }
            set { usuario.dataNascimento = value; }
        }

        public string Telefone
        {
            get { return usuario.telefone; }
            set { usuario.telefone = value; }
        }

        private bool editando;
        public bool Editando
        {
            get { return editando; }
            private set
            {
                editando = value;
                OnPropertyChanged(nameof(Editando));
            }
        }

        private ImageSource fotoPerfil = "perfil.png";

        public ImageSource FotoPerfil
        {
            get { return fotoPerfil; }
            private set { 
                fotoPerfil = value;
                OnPropertyChanged();
            }
        }

        private readonly Usuario usuario;

        public ICommand EditarPerfilCommand { get; private set; }
        public ICommand EditarCommand { get; private set; }
        public ICommand SalvarCommand { get; private set; }
        public ICommand TirarFotoCommand { get; private set; }

        public MasterViewModel(Usuario usuario)
        {
            this.usuario = usuario;

            DefinirComandos(usuario);
        }

        private void DefinirComandos(Usuario usuairo)
        { 
            EditarPerfilCommand = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(usuario, "EditarPerfil");
            });

            SalvarCommand = new Command(() =>
            {
                Editando = false;
                MessagingCenter.Send<Usuario>(usuario, "SucessoSalvarUsuario");
            });

            EditarCommand = new Command(() =>
            {
                Editando = true;
            });

            TirarFotoCommand = new Command(() =>
            {
                DependencyService.Get<ICamera>().TirarFoto();
            });

            MessagingCenter.Subscribe<byte[]>(this, "FotoTirada",
                (bytes) =>
                {
                    FotoPerfil = ImageSource.FromStream(
                        () => new MemoryStream(bytes));
                });
        }
    }
}
