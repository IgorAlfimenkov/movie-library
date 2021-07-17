using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObjects;
using ServiceLayer;

namespace Movie_library.PresentationLayer
{
    public partial class Trailer : Form
    {
        Service service = new Service();
        public Film film = new Film();
        public Trailer(Film film)
        {
            this.film = film;
            InitializeComponent();
            axWindowsMediaPlayer1.URL = film.Trailer;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            MovieInfo f = new MovieInfo(film.Name);
            f.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            service.Save(service.GetAllFilms());
            Application.Exit();
        }
    }
}
