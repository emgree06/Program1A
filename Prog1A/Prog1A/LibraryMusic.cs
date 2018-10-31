/*
 * Grading ID: Z9435
 * Program: A1
 * Due Date: 2/14/2018
 * Section: CIS 200-01
 * Class LibraryMusic is a concrete class for the abstract class LibraryMediaItem. It captures new characteristics such as artist, number of tracks, and
 *                      provides a concrete property for the MediumType enummeration. It overrides methods CalcLateFee to make each music item charge
 *                      .50 for everyday that its late and it overrides ToString method to format output.
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog1A
{
    //Creates the IS-A relationship
    public class LibraryMusic : LibraryMediaItem
    {
        private int _numTracks; //the music items number of tracks
        private MediaType _medium; //the enum that will be used to identify the music item
        const double MAX_LATE_FEE = 20.00;  // the max amount that can be charged for a late music item
        private decimal _latefee;// the late fee for an overdue music item
        private string _artist; //the artist of the music item

        public LibraryMusic(String title, String publisher, int copyrightyear, int loanperiod,
            String callnumber, string artist, double duration, MediaType medium, int numtracks) : base(title, publisher, copyrightyear, loanperiod,
                callnumber, duration)
        {
            Artist = artist;
            NumTracks = numtracks;
            Medium = medium;
        }

        protected override decimal LateFee //Property ovverriden from abstract class
        {
            get
            {// Precondition:  None
             // Postcondition: The late fee has been returned
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

        public string Artist
        {// Precondition:  None
         // Postcondition: the artist returns a value
            get
            {
                return _artist;
            }
            set
            {// Precondition:  artist can't be null or empty
             // Postcondition: the artist is set to the specified value
                if (string.IsNullOrWhiteSpace(value)) // IsNullOrWhiteSpace includes tests for null, empty, or all whitespace
                    throw new ArgumentOutOfRangeException($"{nameof(Title)}", value,
                        $"{nameof(Title)} must not be null or empty");
                else
                    _artist = value.Trim();
            }
        }

        public override MediaType Medium
        {// Precondition:  None
         // Postcondition: The medium is returned
            get
            {
                return _medium;
            }
            set
            {// Precondition:  None
             // Postcondition: The medium is set to its specified value
                if (value == MediaType.CD || value == MediaType.SACD || value == MediaType.VINYL)
                {
                    _medium = value;
                }
            }
        }

        public int NumTracks
        {
            get
            {// Precondition:  None
             // Postcondition: The number of tracks has been returned
                return _numTracks;
            }
            set
            {// Precondition:  the value must be greater or equal to 1
             // Postcondition: The number of tracks is set to it's specified value
                if (value >= 1)
                {
                    _numTracks = value;
                }
                else
                    throw new ArgumentOutOfRangeException($"{nameof(NumTracks)}", value,
                            $"{nameof(NumTracks)} must be >= 1");
            }
        }

        //Precondition: item must be checked out
        //Postcondition: The late fee for x amount of days will be returned
        public override decimal CalcLateFee(int daysLate)
        {
            const double LATE_FEE = .50; //amount charged every day a music item is late
            LateFee = daysLate;

            LateFee = (decimal)(LATE_FEE) * daysLate;// calculates the late fee given the fee of .50 cents per day

            if (LateFee > (decimal)MAX_LATE_FEE)
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

            return $"{base.ToString()}{NL}" + $"Artist: {Artist}{NL}" + $"Number of Tracks: {NumTracks}{NL}"
              + $"Medium: {Medium}";
        }
    }
}
