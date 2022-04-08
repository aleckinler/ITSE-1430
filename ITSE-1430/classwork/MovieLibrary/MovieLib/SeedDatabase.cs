using System;

using MovieLib.Memory;

namespace MovieLib
{
    //extension methods
    //  in a static public/internal class
    //  must be a static method
    //  first parameter must be preceded by "this"

    /// <summary>
    /// seeds a movie database
    /// </summary>
    public static class SeedDatabase
    {
        public static void Seed ( this IMovieDatabase database )
        {
            database.Add(new Movie() {
                Title = "Dune",
                Genre = "Sci-Fi",
                ReleaseYear = 2021,
                Duration = 155,
                Rating = "PG-13",
                Description = "Boy does drugs",
            });

            database.Add(new Movie() {
                Title = "Blade Runner",
                Genre = "Sci-Fi",
                ReleaseYear = 1982,
                Duration = 110,
                Rating = "R",
                IsClassic = true,
                Description = "Man gets robot wife",
            });

            database.Add(new Movie() {
                Title = "Blade Runner 2049",
                Genre = "Sci-Fi",
                ReleaseYear = 2017,
                Duration = 163,
                Rating = "R",
                Description = "Robot gets robot wife, but not for long",
            });
        }
    }
}
