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
        //  do not expose publicly
        public const int MinimumReleaseYear = 1900;
        public readonly DateTime MinimumReleaseDate = new DateTime(1900, 1, 1);

        //properites - exposes data
        //field syntax with methods being called
        //can get (read) and/or set (write)
        //  T getter ()
        //  void setter ( T value )

        //handling null
        //null coalescing ::=E ?? E, find first non-null
        //null conditional ::= E?.M, execute M if E not null

        /// <summary>Gets or sets the title of the movie.</summary>
        public string Title //this is an example of a property
        {
            get { return !String.IsNullOrEmpty(_title) ? _title : ""; } //getter - returns a T (MUST ALWAYS BE A RETURN STATEMENT or at least contain one?)
            set { _title = (value != null) ? value.Trim() : null; } //setter (real creative guys) - T value (no specific rules)
        }

        private string _title; //fields are the only way to store data within a CLASS

        /// <summary>
        /// gets or sets the duration in minutes
        /// </summary>
        public int Duration { get; set; } //auto property syntax is pretty nice for anything that isnt a string

        public int ReleaseYear { get; set; } = 1900;

        public string Rating
        {
            get { return (_rating != null) ? _rating : ""; } //simplified version of title syntax
            set { _rating = value?.Trim(); } //simplified version of title syntax, using NULL CONDITIONAL - if the value was null, the trim function would not occur (thats the condition get it haha get it null CONDITIONal woah cool)
        }

        private string _rating;

        public string Genre
        {
            get { return _genre ?? ""; } //EXTREMELY simplified version of title and rating syntax
            set { _genre = (value != null) ? value.Trim() : null; } //evaluating from left to right, which is why it checks title and then empty string NULL COALESCING OPERATOR GOOGLE THAT SHIT BOIII
        }

        private string _genre;

        public bool IsClassic { get; set; } //yeah this is nice

        private bool _isClassic;

        public string Description
        {
            get { return !String.IsNullOrEmpty(_description) ? _description : ""; }
            set { _description = (value != null) ? value.Trim() : null; }
        }

        private string _description;

        //bw = 1939
        public bool IsBlackAndWhite
        {
            get { return ReleaseYear <= 1939; }
            //set { } (property is no longer writable since setter is gone)
        }

        //private bool _isBlackAndWhite;

       // private void CalculateBlackAndWhite ()
        //{
        //    _isBlackAndWhite = ReleaseYear <= 1939;
        //}

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

            if (Duration < 0)
            //compiler writes this as this.duration
                return "Duration must be at least 0";

            if (ReleaseYear < MinimumReleaseYear)
                return "Release year must be at least 1900";

            if (String.IsNullOrEmpty(Rating))
                return "rating is required";

            //special rule - no classic movies before 1940
            if (IsClassic && ReleaseYear < 1940)
                return "Release year must be at least 1940 to be a classic";

            return "";
        }

        public int Id { get; private set; }
        //{
        //    get { return _id; }
        //    private set { _id = value; } //mixed accessability, only getter OR setter (must be more restrictive than property)
        //}
        //
        //private int _id; (auto property generates a field for this, so it doesnt need to be a declared)
    }
}
