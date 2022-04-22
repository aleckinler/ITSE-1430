using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.IO
{
    public class FileMovieDatabase : MovieDatabase
    {
        public FileMovieDatabase ( string filename )
        {
            _filename = filename;
        }
        private readonly string _filename;
        protected override Movie AddCore ( Movie movie )
        {
            //save the movies!!
            List<Movie> movies = LoadMovies();

            var id = movies.Any() ? movies.Max(x => x.Id) : 0;
            movie.Id = ++id;

            movies.Add(movie);
            SaveMovies(movies);

            return movie;
        }

        private void SaveMovies ( IEnumerable<Movie> movies )
        {
            var lines = movies.Select(SaveMovie);
            File.WriteAllLines(_filename, lines);
        }

        private string SaveMovie ( Movie movie )
        {
            //id, "title", duration, releaseyear, "rating", "genre", isclassic, "description"
            return String.Join(',', movie.Id, Enquote(movie.Title), movie.Duration, movie.ReleaseYear, Enquote(movie.Rating), Enquote(movie.Genre), movie.IsClassic, Enquote(movie.Description));
        }

        private static string Dequote ( string value ) => value.Trim('\"');

        private static string Enquote ( string value ) => "\""+value+"\"";

        private List<Movie> LoadMovies ()
        {
            //buffered text IO
            try
            {
                string[] lines = File.ReadAllLines(_filename);

                return lines.Select(LoadMovie).Where(x => x != null).ToList();
            } catch (FileNotFoundException)
            {
                return new List<Movie>();
            };
        }

        private IEnumerable<Movie> EnumerateMovies ()
        {
            //streamed, text IO
            if (File.Exists(_filename))
            {
                //var stream = File.OpenRead(_filename);
                //var reader = new StreamReader(stream);

                //using - statement requires IDisposable interface
                //IDisposable has a single method called Dispose
                using (var reader = new StreamReader(_filename))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var movie = LoadMovie(line);
                        if (movie != null)
                            yield return movie;
                    };
                }; //try - finally { reader.Close(); } - apparently this is way better (more efficient?) its going to be used in databases so we'll see
            };
        }

        private Movie LoadMovie ( string value )
        {
            if (String.IsNullOrEmpty(value))
                return null;

            string[] tokens = value.Split(',', 8);
            if (tokens.Length != 8)
                return null;

            try
            {
                return new Movie() {
                    Id = Int32.Parse(tokens[0]),
                    Title = Dequote(tokens[1]),
                    Duration = Int32.Parse(tokens[2]),
                    ReleaseYear = Int32.Parse(tokens[3]),
                    Rating = Dequote(tokens[4]),
                    Genre = Dequote(tokens[5]),
                    IsClassic = Boolean.Parse(tokens[6]),
                    Description = Dequote(tokens[7]),
                };
            } catch
            {
                return null;
            }
        }

        protected override void DeleteCore ( int id )
        {
            var movies = LoadMovies();
            var movie = movies.FirstOrDefault(x => x.Id == id);
            if (movie != null)
            {
                movies.Remove(movie);
                SaveMovies(movies);
            };
        }

        protected override Movie FindByName ( string name )
        {
            return EnumerateMovies()
                        .FirstOrDefault(x => String.Equals(x.Title, name, StringComparison.OrdinalIgnoreCase));
        }

        protected override IEnumerable<Movie> GetAllCore ()
        {
            return Enumerable.Empty<Movie>();
        }

        protected override Movie GetCore ( int id )
        {
            return EnumerateMovies()
                        .FirstOrDefault(x => x.Id == id);
        }

        protected override void UpdateCore ( int id, Movie movie )
        {
            var movies = LoadMovies();
            var existing = movies.FirstOrDefault(x => x.Id == id);
            if (existing == null)
                throw new Exception("Movie not found");

            existing.CopyFrom(movie);
            SaveMovies(movies);
        }
    }
}
