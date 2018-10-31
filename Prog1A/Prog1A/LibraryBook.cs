/*
 * Grading ID: Z9435
 * Program: A1
 * Due Date: 2/14/2018
 * Section: CIS 200-01
 * Class LibraryBook: LibraryBook is a concrete class for the abstract class LibraryItem. It is supposed to initialize
 *                      the characteristics of a library book through its constructor. It also overrides the abstract method
 *                      of to return the value of a library book that hasn't been returned in x amount of days. Then the class provides a ToString
 *                      method for formating output.
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1A
{
    //Creates the IS-A relationship between base class LibraryItem and derived class LibraryBook
    class LibraryBook : LibraryItem
    {
        private string _author;// the book's author
        private decimal _latefee;// the book's late fee

        // Precondition:  theCopyrightYear >= 0, LoanPeriod >=0
        //                theTitle, theCallNumber, Publisher, Author may not be null or empty
        // Postcondition: The library book has been initialized with the specified
        //                values for title, author, publisher, copyright year, and
        //                call number. The book is not checked out.
        public LibraryBook(String title, String author, String publisher, int copyrightyear, int loanperiod,
            String callnumber) : base(title, publisher, copyrightyear, loanperiod, callnumber)
        {
            Author = author;
        }

        protected override decimal LateFee  //overriding abstract property from LibraryItem class
        {
            get
            {// Precondition:  None
             // Postcondition: The late fee has been returned
                return _latefee;
            }
            set
            {// Precondition:  None
             // Postcondition: the late fee has been set to the specified value
                if (value >= 0)
                {
                    _latefee = value;
                }
                else
                    throw new ArgumentOutOfRangeException($"{nameof(LateFee)}", value,
                            $"{nameof(LateFee)} must be >= 0");
            }
        }

        public string Author
        {
            // Precondition:  None
            // Postcondition: The author has been returned
            get
            {
                return _author;
            }

            // Precondition:  None
            // Postcondition: The author has been set to the specified value
            set
            {
                // Since empty author is OK, just change null to empty string
                _author = (value == null ? string.Empty : value.Trim());
            }
        }

        //Precondition: book must be checked out
        //Postcondition: The late fee for x amount of days will be returned
        public override decimal CalcLateFee(int daysLate)
        {
            const double LATE_FEE_PER_DAY = 0.25;// the cost of keeping a book for x amount of days

            LateFee = daysLate * (decimal)LATE_FEE_PER_DAY;

            return LateFee;

        }

        public override string ToString()
        {
            string NL = Environment.NewLine; // NewLine shortcut
            string checkedOutBy; // Holds checked out message
            string late; //late fee message

            if (IsCheckedOut())
                checkedOutBy = $"Checked Out By: {NL}{Patron}";
            else
                checkedOutBy = "Not Checked Out";

            if (IsCheckedOut())
                late = $"{NL}Late fee:{LateFee:C}";
            else
                late = "Not Over Due";

            return $"Title: {Title}{NL}Author: {Author}{NL}Publisher: {Publisher}{NL}" +
                $"Copyright: {CopyrightYear}{NL}Call Number: {CallNumber}{NL}{checkedOutBy}{late}";
        }
    }
}
