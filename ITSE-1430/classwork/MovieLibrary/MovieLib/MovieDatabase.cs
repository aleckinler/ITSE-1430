using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib
{
    public abstract class MovieDatabase : IMovieDatabase //if any methods within a class are abstract, then the whole class needs to be declared as abstract (this is a c# thing apparently)
    {
        public Movie Add ( Movie movie )
        {
            //raise an error using throw
            //throw -statement ::= throw E(exception)

            //TODO: validate
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));
            //movie = movie ?? throw new ArgumentNullException(nameof(movie));


            //Throw ValidationException if anything wrong
            ObjectValidator.ValidateObject(movie);
            //return "Movie cannot be null";
            //TODO: fix validation message
            //if (!ObjectValidator.TryValidateObject(movie, out var errors))
            //    return "Movie is invalid";
            //var error = movie.Validate();
            //if (!String.IsNullOrEmpty(error))
            //    return "Movie is invalid";

            //title must be unique
            var existing = FindByName(movie.Title);
            if (existing != null)
                //return "Movie must be unique";
                //throw new InvalidOperationException("Movie must be unique");
                throw new ArgumentException("Movie must be unique", nameof(movie));

            //add (adds and item to your list, duh)
            var newMovie = AddCore(movie);
            //movie.Id = newMovie.Id;
            //return "";
            return newMovie;
        }

        protected abstract Movie AddCore ( Movie movie );

        public void Delete ( int id )
        {
            if (id <= 0)
                //return "ID must be > 0";
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be > 0"); //note that nameof is first here, unlike ArgumentException

            //find by movie.Id;
            DeleteCore(id);
        }

        protected abstract void DeleteCore ( int id );

        public Movie Get ( int id )
        {
            //TODO: Validate
            //if (id <= 0)
            //    return null;
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be > 0");

            return GetCore(id);
        }

        protected abstract Movie GetCore ( int id );

        //iterators - implementation of IEnumerable<T>
        //

        public IEnumerable<Movie> GetAll () => GetAllCore();

        protected abstract IEnumerable<Movie> GetAllCore ();

        public void Update ( int id, Movie movie )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be > 0"); ;
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            ObjectValidator.ValidateObject(movie);
            //var error = movie.Validate();
            //if (!String.IsNullOrEmpty(error))
            //    return error;

            //title must be unique or same movie
            var existing = FindByName(movie.Title);
            if (existing != null && existing.Id != id)
                //return "Movie must be unique";
                throw new ArgumentException("Movie must be unique", nameof(movie));

            //make sure movie already exists
            existing = GetCore(id);
            if (existing == null)
                //return "Movie does not exist";
                throw new ArgumentException("Movie does not exist", nameof(movie));

            //add (adds and item to your list, duh)
            UpdateCore(id, movie);
            //return "";
        }

        protected abstract void UpdateCore ( int id, Movie movie );

        protected abstract Movie FindByName ( string name );
    }
}
