using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace film_uygulaması
{
    public partial class Form1 : Form
    {
        BindingList<Film> filmler = new BindingList<Film>();
        public Form1()
        {
            InitializeComponent();
        }

       

        private void btnEkle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string filmAd = txtFilm.Text;
            int sure = Convert.ToInt32(txtSure.Text);
            DateTime tarih = DateTime.Now;
            string tur = cmbTur.Text;
            bool begendim = cbBegenme.Checked;

            Film film = new Film(id, filmAd, sure, tarih, tur, begendim);

            filmler.Add(film);

            dtvBilgi.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Film film1 = new Film(1, "Çaki", 89, new DateTime(2023, 10, 05), "Korku", true);
            Film film2 = new Film(2, "Yeşil Yol", 100, new DateTime(2023, 12, 09), "Dram", false);
            Film film3 = new Film(2, "Recep İvedik 5", 100, new DateTime(2023, 11, 12), "Dram", true);

            filmler.Add(film1);
            filmler.Add(film2);
            filmler.Add(film3);

            dtvBilgi.DataSource = filmler;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dtvBilgi.SelectedRows.Count > 0)
            {
                Film film = (Film)dtvBilgi.SelectedRows[0].DataBoundItem;

                film.FilmAd = txtFilm.Text;
                film.Sure = Convert.ToInt32(txtSure.Text);
                film.KayitTarih = dtpTarih.Value;
                film.Tur = cmbTur.SelectedText;
                film.Begendim = cbBegenme.Checked;

                dtvBilgi.Refresh();
            }
        }

        private void dtvBilgi_SelectionChanged(object sender, EventArgs e)
        {
            if (dtvBilgi.SelectedRows.Count > 0)
            {
                Film film = (Film)dtvBilgi.SelectedRows[0].DataBoundItem;

                txtId.Text = film.Id.ToString();
                txtFilm.Text = film.FilmAd;
                txtSure.Text = film.Sure.ToString();
                dtpTarih.Value = film.KayitTarih;
                cmbTur.Text = film.Tur;
                cbBegenme.Checked = film.Begendim;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dtvBilgi.SelectedRows.Count > 0)
            {
                Film film = (Film)dtvBilgi.SelectedRows[0].DataBoundItem;

                DialogResult sonuc = MessageBox.Show(film.FilmAd + " silinsin mi?","Kayıt Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (sonuc == DialogResult.Yes)
                {

                    filmler.Remove(film);

                }
            }
        }
    }
}
