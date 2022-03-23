using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieLib.WinHost
{
    public partial class MovieForm : Form
    {
        public MovieForm ()
        {
            InitializeComponent();
        }

        public Movie Movie { get; set; }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e); //base keyword prevents a recursive function (that shit would crash)

            if (Movie != null)
            {
                _txtTitle.Text = Movie.Title;
                _txtDescription.Text = Movie.Description;
                _txtGenre.Text = Movie.Genre;
                _chIsClassic.Checked = Movie.IsClassic;
                _ddlRating.Text = Movie.Rating;
                _txtDuration.Text = Movie.Duration.ToString();
                _txtReleaseYear.Text = Movie.ReleaseYear.ToString();
            };
        }

        private int ReadAsInt32 ( Control control, int defaultValue )
        {
            if (Int32.TryParse(control.Text, out var result))
                return result;

            return defaultValue;
        }

        private void OnSave ( object sender, EventArgs e )
        {
            //create a new movie
            var movie = new Movie();

            //set properties from ui
            movie.Title = _txtTitle.Text;
            movie.Description = _txtDescription.Text;
            movie.Genre = _txtGenre.Text;
            movie.Duration = ReadAsInt32(_txtDuration, -1);
            movie.IsClassic = _chIsClassic.Checked;
            movie.Rating = _ddlRating.Text;
            movie.ReleaseYear = ReadAsInt32(_txtReleaseYear, -1);

            //validate; close if valid
            var error = movie.Validate();
            if (String.IsNullOrEmpty(error))
            {
                //valid
                Movie = movie;
                DialogResult = DialogResult.OK;
                Close();
            };
            //display error
            MessageBox.Show(this, error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void OnCancel ( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void _ddlRating_SelectedIndexChanged ( object sender, EventArgs e )
        {

        }
    }
}
