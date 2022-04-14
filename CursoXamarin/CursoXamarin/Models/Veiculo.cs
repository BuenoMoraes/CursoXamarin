using System;
using System.Collections.Generic;
using System.Text;

namespace CursoXamarin.Models
{
    public class Veiculo
    {

        public const int freio_abs = 800;
        public const int ar_condicionado = 1000;
        public const int mp3_player = 500;
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string PrecoFormatado
        {
            get { return string.Format("R$ {0}", Preco); }
        }

        public bool TemFreioABS { get; set; }
        public bool TemArCondicionado { get; set; }
        public bool TemMP3Player { get; set; }

        public string PrecoTotalFormatado
        {
            get 
            {
                return string.Format("Valor Total: R$ {0}",
                    Preco
                   + (TemFreioABS ? freio_abs : 0)
                   + (TemArCondicionado ? ar_condicionado : 0)
                   + (TemMP3Player ? mp3_player : 0)
                   );



            }
        }

        

    }
}
