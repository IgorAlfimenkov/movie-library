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
using DataObjects;
using ServiceLayer;

namespace Movie_library.PresentationLayer
{
    public partial class MovieInfo : Form
    {
        Database db = new Database("data.xml");
        public CatalogForm f;
        Service service = new Service();
        Film film = new Film();
        public MovieInfo(string name)
        {
            film = service.GetFilm(name);
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            label1.Text = film.Name;
            label2.Text = film.Description;
            label3.Text = "(" + Convert.ToString(film.Year) + ")";
            label4.Text = film.Company;
            label5.Text = Convert.ToString(film.Duration) + "min";
            label6.Text = Convert.ToString(film.Rating);
            List<Actor> actors = new List<Actor>();
            actors = service.GetActorsByfilm(film);
            foreach (Actor actor in actors)
            {
                listBox1.Items.Add(actor.Name);
            }
            List<Genre> genres = new List<Genre>();
            genres = service.GetGenresByFilm(film);
            foreach (Genre genre in genres)
            {
                listBox2.Items.Add(genre.Name);
            }
            PictureBox pb1 = new PictureBox();
            pb1.Image = Image.FromFile(film.Poster);
            pb1.Location = new Point(10, 10);
            pb1.Width = 230;
            pb1.Height = 298;
            pb1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pb1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            CatalogForm f = new CatalogForm();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            service.Save(service.GetAllFilms());
            Application.Exit();
        }

        private void MovieInfo_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            AddFilmForm form = new AddFilmForm(service.GetFilm(label1.Text));
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            service.DeleteFilm(service.GetFilm(label1.Text));
            MessageBox.Show("Film was succsessfully deleted!");
            Hide();
            CatalogForm f = new CatalogForm();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (service.GetFilm(label1.Text).Trailer == String.Empty)
            {
                MessageBox.Show("Film doesnt have trailer!");
            }
            else
            {
                Hide();
                Trailer trailer = new Trailer(service.GetFilm(label1.Text));
                trailer.Show();
            }

        }
    }
}
