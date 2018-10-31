/*
 * Grading ID: Z9435
 * Program: A1
 * Due Date: 2/14/2018
 * Section: CIS 200-01
 * Class LibraryPeriodical is an abstract derived class of the abstract base class LibraryItem. The class includes new characteristics for periodicals
 *        such as the periodical's number and volume along with the base class' characteristics.The volume and number must be > 1. It includes a ToString
 *        method to print the output to the console.
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1A
{
    //Creates the IS-A relationship.
    public abstract class LibraryPeriodical : LibraryItem
    {
        private int _volume; // the periodical's volume
        private int _number; // the periodical's number

        // Precondition:  theCopyrightYear >= 0, LoanPeriod >=0, Volume >=1, Number >=1
        //                theTitle, theCallNumber, Publisher may not be null or empty
        // Postcondition: The library periodical has been initialized with the specified
        //                values for title, author, publisher, copyright year, and
        //                call number. The book is not checked out.
        public LibraryPeriodical(String title, String publisher, int copyrightyear, int loanperiod,
            String callnumber, int volume, int number) : base(title, publisher, copyrightyear, loanperiod, callnumber)
        {
            Volume = volume;
            Number = number;
        }

        public int Volume
        {
            get
            {// Precondition:  None
             // Postcondition: The volume has been returned
                return _volume;
            }
            set
            {
                if (value < 1)
                { // Precondition:  None
                  // Postcondition: The volume has been set to the specified value
                    throw new ArgumentOutOfRangeException($"{nameof(Volume)}", value,
                        $"{nameof(Volume)} must be > 1");
                }
                else
                    _volume = value;
            }
        }

        public int Number
        {
            get
            {// Precondition:  None
             // Postcondition: The number has been returned
                return _number;
            }
            set
            { // Precondition:  None
              // Postcondition: The number has been set to the specified value
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(Number)}", value,
                        $"{nameof(Number)} must be > 1");
                }
                else
                    _number = value;
            }
        }

        public override string ToString()
        {
            string NL = Environment.NewLine;

            return $"{base.ToString()}{NL}" + $"Volume: {Volume}{NL}" + $"Number: {Number}";
        }
    }
}
