using System;

namespace MovieLib
{
    // Class - wraps data and functionality
    //   Naming: nouns, Pascal cased
    //   Default accessibility: internal for a class, private for a class member

    /// <summary>Represents a movie.</summary>
    public class Movie
    {
        //Access modifiers
        //  public - everyone
        //  internal - assembly only
        //  private - declaring type

        //Fields - where the data is stored
        // Naming: nouns, camel cased
        //   Readable and writable (assuming accessibility)
        //   Work just like all other variables
        //  

        /// <summary>Gets or sets the title of the movie.</summary>
        public string Title //this is an example of a property
        {
            get { return _title; } //getter - returns a T
            set { _title = value; } //setter (real creative guys) - T value
        }

        private string _title;
        public int _duration;
        public int _releaseYear = 1900;
        public string _rating;
        public string _genre;
        public bool _isClassic;
        public string _description;

        //bw = 1939
        public bool IsBlackAndWhite
        {
            get { return _isBlackAndWhite; }
            set { /*idk we didnt type anything, the world is your oyster*/}
        }

        private bool _isBlackAndWhite;

        public void CalculateBlackAndWhite ()
        {
            _isBlackAndWhite = _releaseYear <= 1939;
        }
        //fields ALWAYS are notated with an underscore in front "_field"
        //ALL instance methods (functions) have a hidden this parameter that represents the instance
        /// <summary>
        /// validates the instance.
        /// </summary>
        /// <returns>returns error message if any or empty string otherwise.</returns>
        public string Validate (/* Movie this */) //this cant be a parameter cuz its actually a keyword
        {
            var title = ""; //this local variable can do not harm because _title is specified as a field, so theres no conflict
            //title is required
            if (String.IsNullOrEmpty(_title))
                return "Title is required";

            if (_duration < 0)
            //compiler writes this as this.duration
                return "Duration must be at least 0";

            if (_releaseYear < 1900)
                return "Release year must be at least 1900";

            if (String.IsNullOrEmpty(_rating))
                return "rating is required";

            //special rule - no classic movies before 1940
            if (_isClassic && _releaseYear < 1940)
                return "Release year must be at least 1940 to be a classic";

            return "";
        }

        private int id;
    }
}
