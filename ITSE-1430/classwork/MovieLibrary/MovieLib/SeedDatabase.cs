using System;

using MovieLib.Memory;

namespace MovieLib
{
    /// <summary>
    /// seeds a movie database
    /// </summary>
    public class SeedDatabase
    {
        public void Seed ( MemoryMovieDatabase database )
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
                Description = "Robot loses robot wife, consoled by man who lost robot wife",
            });
        }
    }
}
