/*
 * Grading ID: Z9435
 * Program: A1
 * Due Date: 2/14/2018
 * Section: CIS 200-01
 * Class LibraryMediaItem is a derived abstract class from the abstract base of LibraryItem. This class is inteded to capture characteristics for media items
 *                      that are either music or movies. It includes the new property duration. The constructor also calls the base class' constructor
 *                      to help initialize characteristics. This class includes the enummeration MediaType that holds DVD, BLUERAY, VHS, CD, SACD, and VINYL.
 *                      The class also overrides the ToString method to help format the new data.
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1A
{
    //Creates IS-A relationship
    public abstract class LibraryMediaItem : LibraryItem
    {
        private double _duration;// the media item's duration
        public enum MediaType { DVD, BLUERAY, VHS, CD, SACD, VINYL }; // list of media types

        /*Precondition: CoprightYear >= 0, LoanPeriod >= 0, Duration >=0
        *              the Title, Publisher, and CallNumber can't be empty or null.
        *Postcondition: The library item has been initialized with values for Title, Publisher
        *              Copyright year, LoanPeriod, and CallNumber */
        public LibraryMediaItem(String title, String publisher, int copyrightyear, int loanperiod,
            String callnumber, double duration) : base(title, publisher, copyrightyear, loanperiod, callnumber)
        {
            Duration = duration;
        }

        //abstract property for the enummerated list
        public abstract MediaType Medium
        {   //Precondtion: None
            //Postcondition: when initialized in a concrete class it will set the value to the specified value for the set and return the value
            get; set;
        }

        public double Duration
        {
            get
            {// Precondition:  None
             // Postcondition: The duration has been returned
                return _duration;
            }
            set
            {// Precondition:  the value for duration must be >= 0 
             // Postcondition: The duration has been set to the specified value
                if (value >= 0)
                {
                    _duration = value;
                }
                else
                    throw new ArgumentOutOfRangeException($"{nameof(Duration)}", value,
                        $"{nameof(Duration)} >= 0");
            }
        }

        public override string ToString()
        {
            string NL = Environment.NewLine;

            return $"{base.ToString()}{NL} Duration: {Duration}{NL}" + $"Medium: {Medium}";
        }
    }
}
