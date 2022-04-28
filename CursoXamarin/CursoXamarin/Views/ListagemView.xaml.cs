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
        readonly Usuario usuario;
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
            AssinarMensagem();

            await this.ViewModel.GetVeiculos();

        }

        private void AssinarMensagem()
        {
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado",
                           (veiculo) =>
                           {
                               Navigation.PushAsync(new DetalheView(veiculo, usuario));
                           });

            /*MessagingCenter.Subscribe<Exception>(this, "Falha Listagem",
              (veiculo) =>
              {
                  DisplayAlert("Erro", "Ocorreu um erro ao obter a listagem de veículo", "OK");
              });*/

            
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CancelarAssinar();
        }

        private void CancelarAssinar()
        {
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
            //MessagingCenter.Unsubscribe<Exception>(this, "Falha Listagem");
        }
    }
}