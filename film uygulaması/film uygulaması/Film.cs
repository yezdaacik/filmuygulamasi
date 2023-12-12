using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace film_uygulaması
{
    internal class Film
    {
        public int Id { get; set; }
        public string FilmAd { get; set; }
        public int Sure { get; set; }
        public DateTime KayitTarih { get; set; }
        public string Tur { get; set; }
        public bool Begendim { get; set; }

        public Film (int ıd, string filmAd, int sure, DateTime kayitTarih, string tur, bool begendim)
        {
            Id = ıd;
            FilmAd = filmAd;
            Sure = sure;
            KayitTarih = kayitTarih;
            Tur = tur;
            Begendim = begendim;
        }   
    }
}
