using CursoXamarin.Models;
using CursoXamarin.Services;
using CursoXamarin.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CursoXamarin
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new LoginView();
        }

        protected override void OnStart()
        {

            MessagingCenter.Subscribe<Usuario>(this, "SucessoLogin",
               (usuario) =>
               {
                   // MainPage = new NavigationPage(new ListagemView());
                   MainPage = new MasterDetailView(usuario);
               });
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
