/*
 * Grading ID: Z9435
 * Program: A1
 * Due Date: 2/14/2018
 * Section: CIS 200-01
 * Class LibraryItem is an abstract base class for which the rest of this program elaborates on its characteristics. It provides the abstract method
 *                      CalcLateFee to calculate the late fee for library items. It also creates a HAS-A relationship with library parton so each item
 *                      that is checked out is checked out to a patron. Its constructor initializes the basic characteristics of a library item such as
 *                      publish, title, copyright year, loan period, and call number. It also provides a ToString method to print the output to the
 *                      Console.
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1A
{
    public abstract class LibraryItem
    {
        private string _title;// the Library item's title
        private string _publisher; //the Library item's publisher
        private int _copyrightyear; // the library item's copyright year
        private int _loanperiod; // the library item's loan period
        private string _callNumber; //the library item's call number
        private bool _checkedOut;   // The book's checked out status

        /*Precondition: CoprightYear >= 0, LoanPeriod >= 0
         *              the Title, Publisher, and CallNumber can't be empty or null.
         *Postcondition: The library item has been initialized with values for Title, Publisher
         *              Copyright year, LoanPeriod, and CallNumber */
        public LibraryItem(String title, String publisher, int copyrightyear, int loanperiod,
            String callnumber)
        {
            Title = title;
            Publisher = publisher;
            CopyrightYear = copyrightyear;
            LoanPeriod = loanperiod;
            CallNumber = callnumber;

            ReturnToShelf();
        }

        //Precondition: None
        //Postcondtion: create an abstract property that can be modified by derived classes.
        protected abstract decimal LateFee
        {//Precondtion: None
            //Postcondition: when initialized in a concrete class it will set the value to the specified value for the set and return the value
            get; set;
        }


        public string Title
        {
            //Precondition: None
            //Postcondition: return title
            get
            {
                return _title;
            }
            set
            {   // Precondition:  value must not be null or empty
                // Postcondition: The title has been set to the specified value

                if (string.IsNullOrWhiteSpace(value)) // IsNullOrWhiteSpace includes tests for null, empty, or all whitespace
                    throw new ArgumentOutOfRangeException($"{nameof(Title)}", value,
                        $"{nameof(Title)} must not be null or empty");
                else
                    _title = value.Trim();
            }
        }

        public string Publisher
        {
            get
            {// Precondition:  None
             // Postcondition: The publisher has been returned
                return _publisher;
            }
            set
            {// Precondition:  None
             // Postcondition: The publisher has been set to the specified value
                _publisher = (value == null ? string.Empty : value.Trim());
            }
        }

        public int CopyrightYear
        {
            get
            {// Precondition:  None
             // Postcondition: The copyright year has been returned
                return _copyrightyear;
            }
            set
            {       // Precondition:  value >= 0
                    // Postcondition: The copyright year has been set to the specified value
                if (value >= 0)
                    _copyrightyear = value;
                else
                    throw new ArgumentOutOfRangeException($"{nameof(CopyrightYear)}", value,
                        $"{nameof(CopyrightYear)} must be >= 0");

            }
        }

        public int LoanPeriod
        {
            get
            {// Precondition:  None
             // Postcondition: The loan period has been returned
                return _loanperiod;
            }
            set
            { // Precondition:  value >= 0
              // Postcondition: The loan period has been set to the specified value
                if (LoanPeriod >= 0)
                {
                    _loanperiod = value;
                }
                else
                    throw new ArgumentOutOfRangeException($"{nameof(LoanPeriod)}", value,
                        $"{nameof(LoanPeriod)} must not be >=0");
            }
        }

        public string CallNumber
        {
            get
            {// Precondition:  None
             // Postcondition: The call number has been returned
                return _callNumber;
            }
            set
            {       // Precondition:  None
                    // Postcondition: The call number has been set to the specified value
                if (string.IsNullOrWhiteSpace(value)) // IsNullOrWhiteSpace includes tests for null, empty, or all whitespace
                    throw new ArgumentOutOfRangeException($"{nameof(CallNumber)}", value,
                        $"{nameof(CallNumber)} must not be null or empty");
                else
                    _callNumber = value.Trim();
            }
        }

        // Create HAS-A
        public LibraryPatron Patron
        {
            // Precondition:  None
            // Postcondition: The book's patron has been returned
            get; // Auto-implement is fine

            // Helper
            // Precondition:  None
            // Postcondition: The book's patron has been set to the specified value
            private set; // Auto-implement is fine 
        }

        // Precondition:  thePatron != null
        // Postcondition: The book is checked out by the specified patron
        public void CheckOut(LibraryPatron thePatron)
        {
            if (thePatron != null)
                Patron = thePatron;
            else
                throw new ArgumentNullException($"{nameof(thePatron)}", $"{nameof(thePatron)} must not be null");

            _checkedOut = true;
        }

        // Precondition:  None
        // Postcondition: The book is not checked out
        public void ReturnToShelf()
        {
            Patron = null; // Remove previously stored reference to patron

            _checkedOut = false;
        }

        // Precondition:  None
        // Postcondition: true is returned if the book is checked out,
        //                otherwise false is returned
        public bool IsCheckedOut()
        {
            return _checkedOut;
        }

        //Precondtion: None
        //Postcondition: creates an abstract method that can be used by derived classes
        //              accepts on parameter and returns a decimal
        public abstract decimal CalcLateFee(int daysLate);

        public override string ToString()
        {
            string NL = Environment.NewLine; // NewLine shortcut
            string checkedOutBy; // Holds checked out message
            string late;// holds late fee message

            if (IsCheckedOut())
                checkedOutBy = $"Checked Out By: {NL}{Patron}";
            else
                checkedOutBy = "Not Checked Out";

            if (IsCheckedOut())
            {
                late = $"{NL}Late fee:{LateFee:C}";
            }
            else
                late = $"{NL}Not Overdue";

            return $"Title: {Title}{NL}Publisher: {Publisher}{NL}" +
                $"Copyright: {CopyrightYear}{NL}Call Number: {CallNumber}{NL}{checkedOutBy}{late}";
        }
    }
}
