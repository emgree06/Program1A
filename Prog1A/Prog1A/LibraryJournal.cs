/*
 * Grading ID: Z9435
 * Program: A1
 * Due Date: 2/14/2018
 * Section: CIS 200-01
 * Class LibraryJournal is a a concrete class for Library Periodical. A journal is a specific type of periodical. The constructor adds two new parameters
 *                      discipline and editor. It also overrides the CalcLateFee method so that journals cost .75 cents per day they're late. It then
 *                      overrides the ToString method to format the output.
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1A
{
    //Creates the IS-A relationship between base class LibraryPeriodical and derived class LibraryJournal
    class LibraryJournal : LibraryPeriodical
    {
        private string _discipline;//the journal's discipline
        private string _editor;//the journal's editor
        private decimal _latefee;//the journal's possible late fee

        /*Precondition: CoprightYear >= 0, LoanPeriod >= 0, Volume >=1, Number >=1
         *              the Title, Publisher, and CallNumber can't be empty or null.
         *Postcondition: The library item has been initialized with values for Title, Publisher
         *              Copyright year, LoanPeriod, CallNumber, volume, number, discipline, and editor */
        public LibraryJournal(String title, String publisher, int copyrightyear,
            int loanperiod, String callnumber, int volume, int number, String discipline, String editor) :
            base(title, publisher, copyrightyear, loanperiod, callnumber, volume, number) //calls base constructor for help
        {
            Discipline = discipline;
            Editor = editor;
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
             // Postcondition: the late fee is a non-negative value
                if (value >= 0)
                {
                    _latefee = value;
                }
                else
                    throw new ArgumentOutOfRangeException($"{nameof(LateFee)}", value,
                            $"{nameof(LateFee)} must be >= 0");
            }
        }
        public string Discipline
        {
            get
            {// Precondition:  None
             // Postcondition: The dscipline has been returned
                return _discipline;
            }
            set
            {// Precondition:  can't be null or empty
             // Postcondition: The discipline has been set to specified value
                if (string.IsNullOrWhiteSpace(value)) // IsNullOrWhiteSpace includes tests for null, empty, or all whitespace
                {
                    throw new ArgumentOutOfRangeException($"{nameof(Discipline)}", value,
                        $"{nameof(Discipline)} must not be null or empty");
                }
                else
                    _discipline = value.Trim();
            }
        }

        public string Editor
        {
            get
            {// Precondition:  None
             // Postcondition: The editor has been returned
                return _editor;
            }
            set
            {// Precondition:  value can't be null or empty
             // Postcondition: The editor has been set to specified value
                if (string.IsNullOrWhiteSpace(value)) // IsNullOrWhiteSpace includes tests for null, empty, or all whitespace
                {
                    throw new ArgumentOutOfRangeException($"{nameof(Editor)}", value,
                        $"{nameof(Editor)} must not be null or empty");
                }
                else
                    _editor = value.Trim();
            }
        }

        /*Precondition: the library item must be checked out
         * Postcondition: the method calculates what it would cost if the item was x days late and returns it */
        public override decimal CalcLateFee(int daysLate)
        {
            const double LATE_FEE_PER_DAY = 0.75; //the late fee for every day a journal item is not returned


            LateFee = daysLate * (decimal)LATE_FEE_PER_DAY;

            return LateFee; //the dollar amount of if a journal was x days late

            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string NL = Environment.NewLine;

            return $"{base.ToString()}{NL}" + $"Discipline: {Discipline}{NL}" +
                $"Editor: {Editor}";
        }
    }
}
