using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib
{
    public class MovieDatabase
    {
        public MovieDatabase () : this("My Movies") //this is constructor chaining (one constructor calling another)
        {
            //always do minimal initialization of instance, IF ANY
            //don't initialize fields in here - use field initializers
            //unless the field depends on other fields or relies on data available after initialization

            //replicate init code
            //Initialize();
        }

        //bad init approach
        //private void Initialize();
        //{
        //     _id = 1;
        //}

        public MovieDatabase ( string name )
        {
            //Initialize();
            _id = 1;
            Name = name;
        }
        //private string _name;
        private int _id;

        public string Name { get; set; }

        //virtual means derived types can be overridden 
        public virtual void Add ( Movie movie )
        {

        }

        public void Delete ( Movie movie )
        {

        }

        public Movie Search ( string name )
        {
            return null;
        }

        public Movie Get ()
        {
            return null;
        }

        public void Update ( Movie movie )
        {

        }

        protected void Foo () { } //protected means accessible to types and derived types, its private to everything else (also this is a dummy for demonstration purposes if you couldnt tell but like its obvious)
    }

    public class MemoryMovieDatabase : MovieDatabase //this is type inheritance
    {
        public MemoryMovieDatabase () : base("Memory Movies") //when you have a derived type, you are actually dealing with objects within objects
        {

        }

        public override void Add ( Movie movie )
        {
            base.Add(movie);
        }
    }
}
