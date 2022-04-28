using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using CursoXamarin.Media;
using CursoXamarin.Droid;
using Xamarin.Forms;
using Android.Content;
using Android.Provider;
using Java.IO;

[assembly: Xamarin.Forms.Dependency(typeof(MainActivity))]
namespace CursoXamarin.Droid
{
    [Activity(Label = "CursoXamarin", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : 
        global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
        , ICamera
    {

        static Java.IO.File arquivoImagem;

        public void TirarFoto()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);


            arquivoImagem = PegarArquivo();

            intent.PutExtra(MediaStore.ExtraOutput,
                Android.Net.Uri.FromFile(arquivoImagem));

            var activity = Forms.Context as Activity;
            activity.StartActivityForResult(intent, 0);
        }

        private static Java.IO.File PegarArquivo()
        {
            File arquivoImagem;
            Java.IO.File diretorio = new Java.IO.File(
              Android.OS.Environment.GetExternalStoragePublicDirectory(
                  Android.OS.Environment.DirectoryPictures), "Imagens");

            if (!diretorio.Exists())
                diretorio.Mkdirs();


            arquivoImagem =
               new Java.IO.File(diretorio, "MinhaFoto.jpg");
            return arquivoImagem;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {

            TabLayoutResource = Resource.Layout.Tabbar; //esta linha 
            ToolbarResource = Resource.Layout.Toolbar; //esta linha 

            /*StrictMode.VmPolicy.Builder builder = new StrictMode.VmPolicy.Builder(); //esta linha 
            StrictMode.SetVmPolicy(builder.Build()); //esta linha */

            base.OnCreate(savedInstanceState);

            //Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok)
            {
                byte[] bytes;
                using (var stream = new Java.IO.FileInputStream(arquivoImagem))
                {
                    bytes = new byte[arquivoImagem.Length()];
                    stream.Read(bytes);
                }
                    MessagingCenter.Send<byte[]>(bytes, "FotoTirada");
            }       
        }
    }
}