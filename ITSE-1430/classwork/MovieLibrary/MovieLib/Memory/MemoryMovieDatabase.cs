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
            //approach 1
            //foreach (var movie in _movies)
            //    if (String.Equals(movie.Title, name, StringComparison.CurrentCultureIgnoreCase))
            //        return movie;
            //
            //return null;

            //approach 2
            //return _movies.FirstOrDefault(x => String.Equals(x.Title, name, StringComparison.CurrentCultureIgnoreCase));
            //both of these compile down to the same code, so its personal preference (above and below)
            return (from m in _movies
                    where String.Equals(m.Title, name, StringComparison.CurrentCultureIgnoreCase)
                    select m).FirstOrDefault();
        }

        protected override void DeleteCore ( int id )
        {
            //Find by movie.Id;
            var movie = _movies.FirstOrDefault(x => x.Id == id);
            if (movie != null)
                _movies.Remove(movie);
            //foreach (var item in _movies)
            //{
            //    if (item.Id == id)
            //    {
            //        _movies.Remove(item);
            //        return;
            //    };
            //};
        }

        protected override Movie GetCore ( int id )
        {
            return FindById(id)?.Copy();
        }

        //iterators - implementation of IEnumerable<T>
        //

        private Movie FindById ( int id )
        {
            //LINQ
            //what - Data desired (entire movie)
            //where - IEnumerable<T>
            //when - ids match
            //IEnumerable<Movie> matches = _movies.Where(IsMatchingId)
            //var match = matches.FirstOrDefault();
            //var movie = _movies.Where(IsMatchingId)

            //approach 2
            //var movie = _movies.Where(item => item.Id == id)
            //                   .FirstOrDefault();
            //return movie;

            return _movies.FirstOrDefault(x => x.Id == id);

            //foreach (var item in _movies)
            //{
            //    if (item.Id == id)
            //        return item;
            //};
            
            //return null;
        }

        //Func<Movie, bool>
        //private bool IsMatchingId ( Movie movie )
        //{
        //    return false;
        //}

        protected override IEnumerable<Movie> GetAllCore ()
        {
            //return _movies.ToArray();
            //var items = new Movie[_movies.Count];
            //var index = 0;

            //approach 1
            //foreach (var movie in _movies)
            //{
            //    System.Diagnostics.Debug.WriteLine($"Returning {movie.Title}");
            //
            //    //items[index++] = movie.Copy();
            //    yield return movie.Copy();
            //};
            //return items;

            //approach 2
            return _movies.Select(x => x.Copy());
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
