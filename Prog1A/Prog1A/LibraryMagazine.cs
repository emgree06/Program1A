/*
 * Grading ID: Z9435
 * Program: A1
 * Due Date: 2/14/2018
 * Section: CIS 200-01
 * Class LibraryMagazine: LibraryMagazine is a concrete class for LibraryPeriodical. This class provides characteristics for a speicif 
 *                        periodical, a magazine. The characteristics are title, publisher, copyright year, loan period, call number, volume, and
 *                        number. The Magazine provides a concrete version of the abstract CalcLateFee method and has a max late fee of 20.00. The class
 *                        then provides a ToString method to print the information to the console.
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1A
{
    //Creates the IS-A relationship
    class LibraryMagazine : LibraryPeriodical
    {
        private decimal _latefee;// the late fee for the magazine
        const double MAX_LATE_FEE = 20.00; // the max late fee for a library magazine

        // Precondition:  theCopyrightYear >= 0, LoanPeriod >=0, Volume >=1, Number >=1
        //                theTitle, theCallNumber, Publisher may not be null or empty
        // Postcondition: The library periodical has been initialized with the specified
        //                values for title, author, publisher, copyright year, and
        //                call number. The book is not checked out.
        public LibraryMagazine(String title, String publisher, int copyrightyear,
            int loanperiod, String callnumber, int volume, int number)
            : base(title, publisher, copyrightyear, loanperiod, callnumber, volume, number)
        {

        }


        protected override decimal LateFee
        {
            get
            {// Precondition:  None
             // Postcondition: The late fee has been returned
                return _latefee;
            }
            set
            {// Precondition:  None
             // Postcondition: the late fee that is specified is set
                if (value >= 0 && value <= (decimal)MAX_LATE_FEE)
                {
                    _latefee = value;
                }
                else
                    _latefee = (decimal)MAX_LATE_FEE;
            }
        }


        //Precondition: the magazine must be checked out
        //              late fee must be >=0 and <=20
        //Postcondition: the method will return the late fee for the number of x days that the magazine is late
        public override decimal CalcLateFee(int daysLate)
        {
            const double LATE_FEE_PER_DAY = 0.25;// the amount charged each day a magazine is late


            if (LateFee < (decimal)MAX_LATE_FEE)
            {
                LateFee = daysLate * (decimal)LATE_FEE_PER_DAY;
                return LateFee;
            }
            else return (decimal)MAX_LATE_FEE;

            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
