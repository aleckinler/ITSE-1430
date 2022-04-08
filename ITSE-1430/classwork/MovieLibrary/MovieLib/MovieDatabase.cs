using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib
{
    public abstract class MovieDatabase : IMovieDatabase //if any methods within a class are abstract, then the whole class needs to be declared as abstract (this is a c# thing apparently)
    {
        public string Add ( Movie movie )
        {
            //TODO: validate
            if (movie == null)
                return "Movie cannot be null";

            //TODO: fix validation message
            if (!ObjectValidator.TryValidateObject(movie, out var errors))
                return "Movie is invalid";
            //var error = movie.Validate();
            //if (!String.IsNullOrEmpty(error))
            //    return "Movie is invalid";

            //title must be unique
            var existing = FindByName(movie.Title);
            if (existing != null)
                return "Movie must be unique";

            //add (adds and item to your list, duh)
            var newMovie = AddCore(movie);
            movie.Id = newMovie.Id;
            return "";
        }

        protected abstract Movie AddCore ( Movie movie );

        public string Delete ( int id )
        {
            if (id <= 0)
                return "ID must be > 0";

            //find by movie.Id;
            DeleteCore(id);
            return "";
        }

        protected abstract void DeleteCore ( int id );

        public Movie Get ( int id )
        {
            //TODO: Validate
            if (id <= 0)
                return null;

            return GetCore(id);
        }

        protected abstract Movie GetCore ( int id );

        //iterators - implementation of IEnumerable<T>
        //

        public IEnumerable<Movie> GetAll ()
        {
            //TODO: Handle null
            return GetAllCore();
        }

        protected abstract IEnumerable<Movie> GetAllCore ();

        public string Update ( int id, Movie movie )
        {
            if (id <= 0)
                return "Id must be greater than or equal to 0";
            if (movie == null)
                return "Movie cannot be null";

            if (!ObjectValidator.TryValidateObject(movie, out var errors))
                return "Movie is invalid";
            //var error = movie.Validate();
            //if (!String.IsNullOrEmpty(error))
            //    return error;

            //title must be unique or same movie
            var existing = FindByName(movie.Title);
            if (existing != null && existing.Id != id)
                return "Movie must be unique";

            //make sure movie already exists
            existing = GetCore(id);
            if (existing == null)
                return "Movie does not exist";

            //add (adds and item to your list, duh)
            UpdateCore(id, movie);
            return "";
        }

        protected abstract void UpdateCore ( int id, Movie movie );

        protected abstract Movie FindByName ( string name );
    }
}
