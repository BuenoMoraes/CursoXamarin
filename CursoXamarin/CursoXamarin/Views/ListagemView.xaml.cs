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

        public ListagemView()
        {
            InitializeComponent();
            this.ViewModel = new ListagemViewModel();
            this.BindingContext = this.ViewModel;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado",
               (msg) =>
               {
                   Navigation.PushAsync(new DetalheView(msg));
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