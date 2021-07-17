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
    public partial class AddFilmForm : Form
    {
       // Database db = new Database("data.xml");
        Service service = new Service();
        public Film film = new Film();
        public Film efilm = new Film();
        public bool isLeaved = true;
        public List<Genre> genres = new List<Genre>();
        public List<Actor> actors = new List<Actor>();
        public AddFilmForm(Film editfilm)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            label1.Text = "Edit movie";
            this.film = editfilm;
            this.efilm = editfilm;
            textBox1.Text = film.Name;
            textBox2.Text = film.Company;
            textBox3.Text = Convert.ToString(film.Year);
            textBox4.Text = film.Description;
            textBox5.Text = Convert.ToString(film.Rating);
            textBox6.Text = Convert.ToString(film.Duration);
            foreach (Genre g in film.genres)
            {
                listBox2.Items.Add(g.Name);
            }
            foreach (Actor a in film.actors)
            {
                listBox1.Items.Add(a.Name);
            }
        }

        public AddFilmForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            label1.Text = "New movie";
            openFileDialog2.InitialDirectory = "E:/Downloads/";
            openFileDialog2.Filter = "Image files (*.jpg)|*.jpg";
            openFileDialog1.InitialDirectory = "E:/Downloads/";
            openFileDialog1.Filter = "Video files (*.mp4)|*.mp4";
            textBox3.Validating += Year_Validating;
            textBox5.Validating += Rating_Validating;
            textBox6.Validating += Dur_Validating;
            textBox1.Validating += Name_Validating;
            textBox2.Validating += Company_Validating;
            textBox4.Validating += Desc_Validating;
        }

        private void AddFilmForm_Load(object sender, EventArgs e)
        {

            openFileDialog2.InitialDirectory = "E:/Downloads/";
            openFileDialog2.Filter = "Image files (*.jpg)|*.jpg";
            openFileDialog1.InitialDirectory = "E:/Downloads/";
            openFileDialog1.Filter = "Video files (*.mp4)|*.mp4";
            textBox3.Validating += Year_Validating;
            textBox5.Validating += Rating_Validating;
            textBox6.Validating += Dur_Validating;
            textBox1.Validating += Name_Validating;
            textBox2.Validating += Company_Validating;
            textBox4.Validating += Desc_Validating;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0 || textBox2.Text.Trim().Length == 0 || textBox3.Text.Trim().Length == 0 || textBox4.Text.Trim().Length == 0 || textBox5.Text.Trim().Length == 0 || textBox6.Text.Trim().Length == 0 || film.Poster == null)
            {
                if (textBox1.Text.Trim().Length == 0) { textBox1.BackColor = Color.Red; }
                if (textBox2.Text.Trim().Length == 0) { textBox2.BackColor = Color.Red; }
                if (textBox3.Text.Trim().Length == 0) { textBox3.BackColor = Color.Red; }
                if (textBox4.Text.Trim().Length == 0) { textBox4.BackColor = Color.Red; }
                if (textBox5.Text.Trim().Length == 0) { textBox5.BackColor = Color.Red; }
                if (textBox6.Text.Trim().Length == 0) { textBox6.BackColor = Color.Red; }
                if (film.Poster == null) { button8.BackColor = Color.Red; }
                MessageBox.Show("Erorr!");
            }
            else
            {
                film.Name = textBox1.Text;
                film.Company = textBox2.Text;
                film.Year = Convert.ToInt32(textBox3.Text);
                film.Description = textBox4.Text;
                film.Rating = Convert.ToDouble(textBox5.Text);
                film.Duration = Convert.ToInt32(textBox6.Text);
                if (label1.Text == "New movie")
                {
                    service.Insert(film);
                }
                else if (label1.Text == "Edit movie")
                {
                    service.DeleteFilm(efilm);
                    service.Insert(film);
                }
                MessageBox.Show("Film was succsessfully added!");
                Hide();
                CatalogForm f = new CatalogForm();
                f.Show();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.listBox1.Items.Add(this.textBox8.Text);
            Actor a = new Actor();
            a.Name = textBox8.Text;
            film.actors.Add(a);
            this.textBox8.Text = String.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.listBox2.Items.Add(this.textBox9.Text);
            Genre g = new Genre();
            g.Name = textBox9.Text;
            film.genres.Add(g);
            this.textBox9.Text = String.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            CatalogForm f = new CatalogForm();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            service.Save(service.GetAllFilms());
            Application.Exit();
        }



        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Select actor to delete!");
            }
            else
            {
                film.actors.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem == null)
            {
                MessageBox.Show("Select genre to delete!");
            }
            else
            {
                film.genres.RemoveAt(listBox2.SelectedIndex);
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                film.Poster = openFileDialog2.FileName;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                film.Trailer = openFileDialog1.FileName;

            }
        }

        private void Year_Validating(object sender, CancelEventArgs e)
        {
            int val = 0;
            if (String.IsNullOrEmpty(textBox3.Text))
            {
                e.Cancel = true;
                //textBox3.Focus();
                errorProvider1.SetError(textBox3, "Enter year!");
            }
            else if (!Int32.TryParse(textBox3.Text, out val))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox3, "Invalid value!"); ;
            }
            else
            {
                e.Cancel = false;
                //errorProvider1.Clear();
            }
        }

        private void Rating_Validating(object sender, CancelEventArgs e)
        {
            double val = 0;
            if (String.IsNullOrEmpty(textBox5.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox5, "Enter  rating!");
            }
            else if (!double.TryParse(textBox5.Text, out val))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox5, "Invalid value!"); ;
            }
            else if (Convert.ToDouble(textBox5.Text) > 10)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox5, "Enter value less than 10!"); ;
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void Dur_Validating(object sender, CancelEventArgs e)
        {
            int val = 0;
            if (String.IsNullOrEmpty(textBox6.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox6, "Enter duration!");
            }
            else if (!Int32.TryParse(textBox6.Text, out val))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox6, "Invalid value!"); ;
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        private void Name_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Enter value!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        private void Desc_Validating(object sender, CancelEventArgs e)
        {

            if (String.IsNullOrEmpty(textBox4.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox4, "Enter value!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        private void Company_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox2, "Enter value!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
}
