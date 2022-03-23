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
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent();
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            //confirm exit
            DialogResult dr = MessageBox.Show(this, "Are you sure you want to quit?", "Quit",
                                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                //user clicked yes
                Close();
            };
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var form = new AboutBox();
            form.ShowDialog(this);
        }

        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var dlg = new MovieForm();
             if (dlg.ShowDialog(this) !=DialogResult.OK)
                return;

            //TODO: save the movie!
            _movie = dlg.Movie;
            UpdateUI();
        }

        private void UpdateUI ()
        {
            _lstMovies.Items.Clear();
            if (_movie != null)
            _lstMovies.Items.Add(_movie);
        }

        private Movie _movie;

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            var menuItem = sender as ToolStripMenuItem;
            //sender == _miMovieEdit;

            //getting selected movie
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            var dlg = new MovieForm();
            dlg.Movie = movie;

            //show modally - blocking call
            if (dlg.ShowDialog(this) !=DialogResult.OK)
                return;

            //TODO: update movie!
            _movie = dlg.Movie;
            UpdateUI();
        }

        private void OnMovieDelete ( object sender, EventArgs e ) //EventArgs could also be a derived type (remember inheritance)
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            if (MessageBox.Show(this, $"Are you sure you want to delete {movie.Title}?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)

                return;

            _movie = null;
            UpdateUI();
        }

        private Movie GetSelectedMovie ()
        {
            return _lstMovies.SelectedItem as Movie;
        }
    }
}
