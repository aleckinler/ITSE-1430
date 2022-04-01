using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Memory
{
    public class MemoryMovieDatabase
    {
        public string Add ( Movie movie )
        {
            //TODO: validate
            if (movie == null)
                return "Movie cannot be null";
            var error = movie.Validate();
            if (!String.IsNullOrEmpty(error))
                return "Movie is invalid";

            //title must be unique
            var existing = FindByName(movie.Title);
            if (existing != null)
                return "Movie must be unique";

            //add (adds and item to your list, duh)
            movie.Id = _id++;
            _movies.Add(movie.Copy());
            return "";
        }

        private Movie FindByName ( string name )
        {
            //foreach rules: LOOP VARIANT is READONLY - 
            foreach (var movie in _movies)
                if (String.Equals(movie.Title, name, StringComparison.CurrentCultureIgnoreCase))
                    return movie;

            return null;
        }

        public void Delete ( Movie movie )
        {
            //find by movie.Id;
            foreach (var item in _movies)
            {
                if (item.Id == movie.Id)
                {
                    _movies.Remove(item);
                    return;
                };
            };
        }

        public Movie Get ( int id)
        {
            return FindById(id)?.Copy();
        }

        public Movie FindById ( int id )
        {
            foreach (var item in _movies)
            {
                if (item.Id == id)
                    return item;
            };

            return null;
        }

        public Movie[] GetAll()
        {
            //return _movies.ToArray();
            var items = new Movie[_movies.Count];
            var index = 0;
            foreach (var movie in _movies)
                items[index++] = movie.Copy();

            return items;
        }


        public string Update ( int id, Movie movie )
        {
            if (id <= 0)
                return "Id must be greater than or equal to 0";
            if (movie == null)
                return "Movie cannot be null";
            var error = movie.Validate();
            if (!String.IsNullOrEmpty(error))
                return error;

            //title must be unique or same movie
            var existing = FindByName(movie.Title);
            if (existing != null && existing.Id != id)
                return "Movie must be unique";

            //make sure movie already exists
            existing = FindById(id);
            if (existing == null)
                return "Movie does not exist";

            //add (adds and item to your list, duh)
            movie.CopyFrom(existing);
            return "";
        }

        private readonly List<Movie> _movies = new List<Movie>();
        private int _id = 1;
    }
}
