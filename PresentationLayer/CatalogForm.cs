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
    public partial class CatalogForm : Form
    {

        Database db = new Database("data.xml");
        public Film ffilm = new Film();
        Service service = new Service();
        public CatalogForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            FillGenres();
            FillActors();
            comboBox1.Text = "All";
        }
        private void FillGenres()
        {
            comboBox1.Items.Add("All");
            List<Genre> genres = new List<Genre>();
            genres = service.GetGenres();
            foreach (Genre g in genres)
            {
                if (!comboBox1.Items.Contains(g.Name))
                {
                    comboBox1.Items.Add(g.Name);
                }

            }

        }

        private void FillActors()
        {
            List<Actor> actors = new List<Actor>();
            actors = service.GetActors();
            foreach (Actor a in actors)
            {
                if (!comboBox2.Items.Contains(a.Name))
                {
                    comboBox2.Items.Add(a.Name);
                }

            }
        }
        private void DrawFilm(Film film)
        {
            Panel panel = new Panel();
            panel.Width = 260;
            panel.Height = 368;
            panel.BackColor = Color.White;
            PictureBox pb = new PictureBox();
            pb.Location = new Point(10, 10);
            pb.Width = 230;
            pb.Height = 298;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Image = Image.FromFile(film.Poster);
            pb.Click += Pb1_Click;
            pb.Tag = film.Name;
            Label l1 = new Label();
            l1.AutoSize = true;
            l1.Text = film.Name;
            l1.Location = new Point(10, 310);
            Label l2 = new Label();
            l2.Text = Convert.ToString(film.Year);
            l2.Location = new Point(10, 335);
            Label l3 = new Label();
            l3.AutoSize = true;
            l3.Text = Convert.ToString(film.Rating);
            l3.Location = new Point(150, 335);
            panel.Controls.Add(l1);
            panel.Controls.Add(l2);
            panel.Controls.Add(l3);
            panel.Controls.Add(pb);
            flowLayoutPanel1.Controls.Add(panel);
        }
       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Film> sortediflms = new List<Film>();
            if (comboBox1.Text.Equals("All"))
            {
                flowLayoutPanel1.Controls.Clear();

                foreach (Film film in service.GetAllFilms())
                {
                    DrawFilm(film);
                }

            }
            foreach (Genre g in db.Genres)
            {
                if (g.Name.Equals(comboBox1.Text))
                {
                    flowLayoutPanel1.Controls.Clear();
                    sortediflms = service.GetFilmsByGenre(g.Name);
                    foreach (Film f in sortediflms)
                    {
                        DrawFilm(f);
                    }
                }
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                List<Film> sortedfilms = new List<Film>();
                sortedfilms = service.GetFilmsByYear(Convert.ToInt32(textBox2.Text));
                if (sortedfilms.Count == 0)
                {
                    MessageBox.Show("Enter valid year!");
                }
                else
                {
                    flowLayoutPanel1.Controls.Clear();
                    foreach (Film f in sortedfilms)
                    {
                        DrawFilm(f);
                    }
                }
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Film> sortedfilms = new List<Film>();
            foreach (Actor a in db.Actors)
            {
                if (a.Name.Equals(comboBox2.Text))
                {
                    flowLayoutPanel1.Controls.Clear();
                    sortedfilms = service.GetFilmsByActor(comboBox2.Text);
                    foreach (Film f in sortedfilms)
                    {
                        DrawFilm(f);
                    }
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            List<Film> sortedfilms = db.SortByYearOldToHNew();
            flowLayoutPanel1.Controls.Clear();
            foreach (Film f in sortedfilms)
            {
                DrawFilm(f);
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            List<Film> sortedfilms = db.SortByYearNewToOld();
            flowLayoutPanel1.Controls.Clear();
            foreach (Film f in sortedfilms)
            {
                DrawFilm(f);
            }
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            List<Film> sortedfilms = db.SortByRatingFromLow();
            flowLayoutPanel1.Controls.Clear();
            foreach (Film f in sortedfilms)
            {
                DrawFilm(f);
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            List<Film> sortedfilms = db.SortByRatingFromHigh();
            flowLayoutPanel1.Controls.Clear();
            foreach (Film f in sortedfilms)
            {
                DrawFilm(f);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            AddFilmForm f = new AddFilmForm();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            service.Save(service.GetAllFilms());
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            List<Film> sortedfilms = service.GetBestFilms();
            foreach (Film f in sortedfilms)
            {
                DrawFilm(f);
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Text = "Search...";
        }
        private void Pb1_Click(object sender, EventArgs e)
        {
            Hide();
            string fname = Convert.ToString((sender as PictureBox).Tag);
            MovieInfo mi = new MovieInfo(fname);
            mi.Show();
        }

        
    }
}
