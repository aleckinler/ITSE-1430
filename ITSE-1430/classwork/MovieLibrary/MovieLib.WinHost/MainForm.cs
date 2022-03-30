using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MovieLib.Memory;

namespace MovieLib.WinHost
{
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing ( FormClosingEventArgs e )
        {
            //Confirm exit
            DialogResult dr = MessageBox.Show(this, "Are you sure you want to quit?", "Quit",
                                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr != DialogResult.Yes)
                e.Cancel = true;
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var form = new AboutBox();
            form.ShowDialog(this);
        }

        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var dlg = new MovieForm();

            //show modally, blocking call
            do
            {
                if (dlg.ShowDialog(this) !=DialogResult.OK)
                    return;

                //TODO: save the movie!
                var error = _movies.Add(dlg.Movie);
                if (String.IsNullOrEmpty(error))
                {
                    UpdateUI();
                    return;
                };

                MessageBox.Show(this, error, "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (true);
        }

        private void UpdateUI ()
        {
            _lstMovies.Items.Clear();

            var movies = _movies.GetAll();
            _lstMovies.Items.AddRange(movies);
        }


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

        private Movie _movie;
        private readonly MemoryMovieDatabase _movies = new MemoryMovieDatabase();
    }
}
