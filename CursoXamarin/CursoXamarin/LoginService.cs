using CursoXamarin.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CursoXamarin
{
    public class LoginService
    {
        public async Task<HttpResponseMessage> FazerLogin(Login login)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://aluracar.herokuapp.com");
                var camposFormulario = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>("email", login.email),
                        new KeyValuePair<string, string>("senha", login.senha)
                    });
                var resultado = await cliente.PostAsync("/login", camposFormulario);
                return resultado;
            }
        }
    }
}
