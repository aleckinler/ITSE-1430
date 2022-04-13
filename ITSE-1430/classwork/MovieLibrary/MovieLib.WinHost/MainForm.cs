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

        //extension methods
        //extended a type with a new method
        //works with any type
        //
        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            //If database is empty
            IEnumerable<Movie> items = _movies.GetAll();
            if (!items.Any())
            {
                if (MessageBox.Show(this, "Do you want to seed the database?", "Seed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //seed
                    //var seed = new SeedDatabase(); - unneeded due to static optimizations
                    _movies.Seed();
                    UpdateUI();
                };
            };
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
                    //dlg.Movie.Title = "Star Wars";
                    UpdateUI();
                    return;
                };

                MessageBox.Show(this, error, "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (true);
        }

        private void UpdateUI ()
        {
            _lstMovies.Items.Clear();

            //approach 2
            //var movies = _movies.GetAll()
            //                    .OrderBy(x => x.Title)
            //                    .ThenBy(x => x.ReleaseYear);
            //BreakMovies(movies);

            //approach1
            //foreach (var movie in movies)
            //    _lstMovies.Items.Add(movie);

            //approach 3
            var movies = from m in _movies.GetAll()
                         orderby m.Title, m.ReleaseYear
                         select m;

            _lstMovies.Items.AddRange(movies.ToArray());
        }

        //private void BreakMovies ( IEnumerable<Movie> movies )
        //{
        //    if (movies.Any())
        //    {
        //        var firstMovie = movies[0];
        //
        //      firstMovie.Title = "Star Wars";
        //    }
        //}

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            //getting selected movie
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            var dlg = new MovieForm();
            dlg.Movie = movie;

            do
            {
                if (dlg.ShowDialog(this) !=DialogResult.OK)
                    return;

                //TODO: update movie!
                var error = _movies.Update(movie.Id, dlg.Movie);
                if (String.IsNullOrEmpty(error))
                {
                    UpdateUI();
                    return;
                };

                MessageBox.Show(this, error, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (true);
        }

        private void OnMovieDelete ( object sender, EventArgs e ) //EventArgs could also be a derived type (remember inheritance)
        {
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            if (MessageBox.Show(this, $"Are you sure you want to delete {movie.Title}?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)

                return;
            
            _movies.Delete(movie.Id);
            UpdateUI();
        }

        private Movie GetSelectedMovie ()
        {
            return _lstMovies.SelectedItem as Movie;
        }

        private Movie _movie;
        private readonly IMovieDatabase _movies = new MemoryMovieDatabase();

        private void _lstMovies_SelectedIndexChanged ( object sender, EventArgs e )
        {
            //this does nothing but i dont wanna screw up anything by deleting it
        }
    }
}
