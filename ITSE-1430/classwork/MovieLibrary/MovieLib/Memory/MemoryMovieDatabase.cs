using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Memory
{
    public class MemoryMovieDatabase : MovieDatabase
    {
        protected override Movie AddCore ( Movie movie )
        {
            //add (adds and item to your list, duh)
            
            movie.Id = _id++;
            _movies.Add(movie.Copy());
            return movie;
        }

        protected override Movie FindByName ( string name )
        {
            //foreach rules: LOOP VARIANT is READONLY - 
            foreach (var movie in _movies)
                if (String.Equals(movie.Title, name, StringComparison.CurrentCultureIgnoreCase))
                    return movie;

            return null;
        }

        protected override void DeleteCore ( int id )
        {
            //Find by movie.Id;
            foreach (var item in _movies)
            {
                if (item.Id == id)
                {
                    _movies.Remove(item);
                    return;
                };
            };
        }

        protected override Movie GetCore ( int id )
        {
            return FindById(id)?.Copy();
        }

        //iterators - implementation of IEnumerable<T>
        //

        public Movie FindById ( int id )
        {
            foreach (var item in _movies)
            {
                if (item.Id == id)
                    return item;
            };

            return null;
        }

        protected override IEnumerable<Movie> GetAllCore ()
        {
            //return _movies.ToArray();
            //var items = new Movie[_movies.Count];
            //var index = 0;
            foreach (var movie in _movies)
            {
                System.Diagnostics.Debug.WriteLine($"Returning {movie.Title}");

                //items[index++] = movie.Copy();
                yield return movie.Copy();
            };

            //return items;
        }


        protected override void UpdateCore ( int id, Movie movie )
        {
            //var error = movie.Validate();
            //if (!String.IsNullOrEmpty(error))
            //    return error;

            //title must be unique or same movie
            var existing = GetCore(id);
            existing.CopyFrom(movie);
        }

        private readonly List<Movie> _movies = new List<Movie>();
        private int _id = 1;
    }
}
