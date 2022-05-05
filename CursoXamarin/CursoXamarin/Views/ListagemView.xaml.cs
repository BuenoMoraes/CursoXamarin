using CursoXamarin.Models;
using CursoXamarin.ViewModels;
//using CursoXamarin.ViewModels;
using CursoXamarin.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CursoXamarin.Views
{
    

    public partial class ListagemView : ContentPage
    {

        public ListagemViewModel ViewModel { get; set; }

        Usuario usuario;
        public ListagemView(Usuario usuario)
        {
            InitializeComponent();
            this.ViewModel = new ListagemViewModel();
            this.usuario = usuario;
            this.BindingContext = this.ViewModel;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado",
               (veiculo) =>
               {
                   Navigation.PushAsync(new DetalheView(veiculo, usuario));
               });

            await this.ViewModel.GetVeiculos();

        }

         protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
        }

    }
}