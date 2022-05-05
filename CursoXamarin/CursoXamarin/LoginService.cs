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
                /*cliente.BaseAddress = new Uri("https://aluracar.herokuapp.com");
                var camposFormulario = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>("email", login.email),
                        new KeyValuePair<string, string>("senha", login.senha)
                    });
                var resultado = await cliente.PostAsync("/login", camposFormulario);*/
                cliente.BaseAddress = new Uri("http://192.168.0.47:8000/api/agendamentos");
                cliente.Timeout = TimeSpan.FromSeconds(200);
                var camposFormulario = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string, string>("nome", "Cadastro via Xamarin"),
                        new KeyValuePair<string, string>("telefone", "1234-5678"),
                        new KeyValuePair<string, string>("email", "cadastro@gmail.com"),
                        new KeyValuePair<string, string>("modelo", "veiculo1"),
                        new KeyValuePair<string, string>("preco", "100.10"),
                        new KeyValuePair<string, string>("data", "2022-02-04 12:00")
                    });
                var resultado = await cliente.PostAsync("http://192.168.0.47:8000/api/agendamentos", camposFormulario);
                //Console.WriteLine(resultado.StatusCode);
                //Console.WriteLine("Após cadastro");
                return resultado;
            }
        }
    }
}
