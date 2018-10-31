/*
 * Grading ID: Z9435
 * Program: A1
 * Due Date: 2/14/2018
 * Section: CIS 200-01
 * Class LibraryMovie is a LibraryMediaItem. This class is a concrete class for the abstract class LibraryMediaItem. This class specifically deals
 *              with movies, so it has the enummeration of movie ratings to describe a movie. It also has new properties like director to provide a way
 *              to capture that characteristic of a movie. The class will only accept DVDs, VHS, and BLUERAY from the MediaType Enum. It also overrides
 *              the CalcLateFee method so that Bluerays are 1.50 per day and VHS and DVD are only a 1.00 per day. The it overrides the ToString method
 *              to format the output.
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1A
{
    //Creates IS-A relationship
    class LibraryMovie : LibraryMediaItem
    {
        private MediaType _medium;// the movie's media type
        private decimal _latefee;// the late fee for the movie
        const double MAX_LATE_FEE = 25.00;// the maximum amount the late fee can be
        private string _director;// the director for the movie
        private MPAARatings _rating;// the rating for the movie

        public enum MPAARatings { G, PG, PG13, R, NC17, U }; // enummeration of ratings for each movie

        /*Precondition: CoprightYear >= 0, LoanPeriod >= 0, Duration >=0
        *              the Title, Publisher, CallNumber, and director can't be empty or null.
        *Postcondition: The library item has been initialized with values for Title, Publisher
        *              Copyright year, LoanPeriod, CallNumber, duration, director, medium, and rating */
        public LibraryMovie(String title, String publisher, int copyrightyear, int loanperiod,
            String callnumber, double duration, String director, MediaType medium, MPAARatings rating) : base(title, publisher,
                copyrightyear, loanperiod, callnumber, duration)
        {
            Director = director;
            Medium = medium;
            Rating = rating;
        }
        protected override decimal LateFee
        {
            get
            {// Precondition:  the value must be >= 0 and <= MAX_LATE_FEE
             // Postcondition: The late fee will return a value
                return _latefee;
            }
            set
            {// Precondition:  the value must be >= 0 and <= MAX_LATE_FEE
             // Postcondition: The late fee has been set to the specified value
                if (value >= 0 && value <= (decimal)MAX_LATE_FEE)
                {
                    _latefee = value;
                }
                else
                    _latefee = (decimal)MAX_LATE_FEE;
            }
        }
        public string Director
        {// Precondition: None
         // Postcondition: The director has been returned
            get
            {
                return _director;
            }
            set
            {// Precondition: can't be null or whitespace
             // Postcondition: The director has been set to the specified value
                if (string.IsNullOrWhiteSpace(value)) // IsNullOrWhiteSpace includes tests for null, empty, or all whitespace
                    throw new ArgumentOutOfRangeException($"{nameof(Director)}", value,
                        $"{nameof(Director)} must not be null or empty");
                else
                    _director = value.Trim();
            }
        }

        public override MediaType Medium //property overriden from abstract class MediaItem. 
        {
            get
            {// Precondition:  None
             // Postcondition: The medium has been set to the specified value
                return _medium;
            }
            set
            {// Precondition:  the medium value for a movie must be DVD or Blueray or VHS
             // Postcondition: The medium has been set to the specified value
                if (value == MediaType.DVD || value == MediaType.BLUERAY || value == MediaType.VHS)
                {
                    _medium = value;
                }
                else
                    throw new IndexOutOfRangeException();
            }
        }

        public MPAARatings Rating
        {// Precondition: None
         // Postcondition: Rating returns the value
            get
            {
                return _rating;
            }
            set
            {// Precondition: Rating must be G, PG, PG13, NC17, R, or U to be a valid entry
             // Postcondition: Rating is set to the specified value
                if (Rating == MPAARatings.G || Rating == MPAARatings.PG || Rating == MPAARatings.PG13 || Rating == MPAARatings.NC17 || Rating == MPAARatings.R || Rating == MPAARatings.U)
                { _rating = value; }
                else
                    throw new IndexOutOfRangeException();
            }
        }

        //Precondition: movie must be checked out
        //Postcondition: The late fee for x amount of days will be returned
        public override decimal CalcLateFee(int daysLate)
        {
            const double LATE_FEE_FOR_DVD_VHS = 1.00;
            const double LATE_FEE_FOR_BLUERAY = 1.50;
            //const double MAX_LATE_FEE = 25.00;
            MediaType medium = Medium;


            if (Medium == MediaType.DVD || Medium == MediaType.VHS) //if it's a DVD or VHS it is 1.00 per day
            {
                LateFee = (decimal)(LATE_FEE_FOR_DVD_VHS) * daysLate;
            }
            else
            { // Blue ray is 1.50 per day
                LateFee = (decimal)LATE_FEE_FOR_BLUERAY * daysLate;
            }

            if (LateFee >= (decimal)MAX_LATE_FEE)
            {
                return (decimal)MAX_LATE_FEE;
            }
            else
                return LateFee;

            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string NL = Environment.NewLine;

            return $"{base.ToString()}{NL}" + $"Director: {Director}{NL}" + $"Rating: {Rating}{NL}";
        }
    }
}
