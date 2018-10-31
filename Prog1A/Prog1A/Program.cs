/*
 * Grading ID: Z9435
 * Program: A1
 * Due Date: 2/14/2018
 * Section: CIS 200-01
 * Class Program: Tests ouput from the class hierarchy and makes sure that it works. The class prints the instances to the console.
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Prog1A
{
    class Program
    {
        public static void Main(string[] args)
        {
            LibraryItem book1 = new LibraryBook("The Wright Guide to C#", "Andrew Wright", "UofL Press",
            2010, 10, "ZZ25 3G");  // 1st test book
            LibraryItem book2 = new LibraryBook("C#", "Wright", "Press",
            2010, 10, "ZZ25 3G");  // 2st test book
            LibraryItem book3 = new LibraryBook("null", "test", "ID", 2001, 3, "AS123"); //3rd book

            LibraryItem journal1 = new LibraryJournal("I'm not that creative", "Dead inside Inc.", 1995, 10, "1235AD", 1, 12, "How to Give Up", "Jung");    //1st journal
            LibraryItem journal2 = new LibraryJournal("creative", "inside Inc.", 1995, 10, "1235AD", 1, 9, "Give Up", "UGH"); //2nd journal

            LibraryItem magazine1 = new LibraryMagazine("Magazine", "Dr. Jian Guian", 2018, 365, "SQL34", 2, 10); //1st magazine

            LibraryItem movie1 = new LibraryMovie("The Land Before Time", "Dino", 1990, 3, "RAWR 34", 1.30, "Stegasaurous", LibraryMediaItem.MediaType.BLUERAY, LibraryMovie.MPAARatings.G); //1st movie
            LibraryItem movie2 = new LibraryMovie("movie", "Dino", 1990, 3, "RAWR 34", 1.30, "Stegasaurous", LibraryMediaItem.MediaType.VHS, LibraryMovie.MPAARatings.U); //2nd mvoie
            LibraryItem movie3 = new LibraryMovie("Emoji Movie", "Emoji", 1990, 3, "RAWR 34", 1.30, "Stegasaurous", LibraryMediaItem.MediaType.DVD, LibraryMovie.MPAARatings.PG13); //3rd movie

            LibraryItem music1 = new LibraryMusic("music", "The Music", 1908, 1, "ABCDE", "1234", 1.30, LibraryMediaItem.MediaType.CD, 1); //1st music item
            LibraryItem music2 = new LibraryMusic("muse", "The ", 1908, 2, "ABCDE", "1234", 1.30, LibraryMediaItem.MediaType.SACD, 1); //2nd music item
            LibraryItem music3 = new LibraryMusic("Beatles", "The ", 1908, 2, "ABCDE", "1234", 2.30, LibraryMediaItem.MediaType.VINYL, 10); //3rd music item

            LibraryPatron patron1 = new LibraryPatron("Ima Reader", "123456"); // 1st test patron
            LibraryPatron patron2 = new LibraryPatron("Jane Doe", "112233");  // 2nd test patron
            LibraryPatron patron3 = new LibraryPatron("   John Smith   ", "   654321   "); // 3rd test patron - Trims?
            LibraryPatron patron4 = new LibraryPatron("Reader", "1234567"); // 4st test patron
            LibraryPatron patron5 = new LibraryPatron("Ima", "12"); // 5st test patron

            List<LibraryItem> theBooks = new List<LibraryItem> { book1, book2, book3 }; // Test list of books
            List<LibraryItem> theMusic = new List<LibraryItem> { music1, music2, music3, }; //Test list of music items
            List<LibraryItem> theMovies = new List<LibraryItem> { movie1, movie2, movie3 };// Test list of movie items
            List<LibraryItem> theMagazines = new List<LibraryItem> { magazine1 };// Test list of magazines
            List<LibraryItem> theJournals = new List<LibraryItem> { journal1, journal2 }; //Test list of journals

            WriteLine("Original list of the items");
            WriteLine("----------------------");
            PrintItems(theBooks);
            PrintItems(theMusic);
            PrintItems(theMovies);
            PrintItems(theJournals);
            Pause();

            // Make changes
            book1.CheckOut(patron2);
            book1.CalcLateFee(3);
            book2.CheckOut(patron5);
            book2.CalcLateFee(20);

            try
            {
                try
                {
                    book3.CheckOut(null);// invalid checkout
                }
                catch (ArgumentNullException ex)
                {
                    WriteLine("Caught invalid person trying to checkout");
                    WriteLine(ex.Message);
                }
                try
                {
                    book1.CallNumber = null; //invalid call number
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    WriteLine("Caught null entry");
                    WriteLine(ex.Message);
                }

                try
                {
                    journal2.CopyrightYear = -123; //invalid copyright year
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    WriteLine("Caught invalid copyright year");
                    WriteLine(ex.Message);
                }
            }
            catch { }

            movie1.CheckOut(patron2);
            movie1.CalcLateFee(100);    //testing validation for method

            movie2.CheckOut(patron3);
            movie2.CalcLateFee(4);

            movie3.CheckOut(patron5);
            movie3.CalcLateFee(2);

            book1.CheckOut(patron1);

            music1.CheckOut(patron3);
            music1.CalcLateFee(100);    //testing validation for method

            music2.CheckOut(patron2);
            music2.CalcLateFee(10);

            music3.CheckOut(patron4);
            music3.CalcLateFee(1);

            magazine1.CheckOut(patron3);
            magazine1.CalcLateFee(100);     //testing validation for method

            journal1.CheckOut(patron5);
            journal1.CalcLateFee(10);
            journal2.CheckOut(patron4);
            journal2.CalcLateFee(3);

            WriteLine("The Books After changes");
            WriteLine("-------------");
            PrintItems(theBooks);
            Pause();

            WriteLine("The Music After changes");
            WriteLine("-------------");
            PrintItems(theMusic);
            Pause();

            WriteLine("The Movies After changes");
            WriteLine("-------------");
            PrintItems(theMovies);
            Pause();

            WriteLine("The Magazines After changes");
            WriteLine("-------------");
            PrintItems(theMagazines);
            Pause();

            WriteLine("The Journals After changes");
            WriteLine("-------------");
            PrintItems(theJournals);
            Pause();

            // Return the books
            book1.ReturnToShelf();
            book2.ReturnToShelf();
            movie1.ReturnToShelf();
            movie2.ReturnToShelf();
            movie3.ReturnToShelf();
            music1.ReturnToShelf();
            music2.ReturnToShelf();
            music3.ReturnToShelf();
            magazine1.ReturnToShelf();
            journal1.ReturnToShelf();
            journal2.ReturnToShelf();


            WriteLine("After returning the Books");
            WriteLine("-------------------------");
            PrintItems(theBooks);
            Pause();

            WriteLine("After returning the Music");
            WriteLine("-------------------------");
            PrintItems(theMusic);
            Pause();

            WriteLine("After returning the Movies");
            WriteLine("-------------------------");
            PrintItems(theMovies);
            Pause();

            WriteLine("After returning the Magazines");
            WriteLine("-------------------------");
            PrintItems(theMagazines);
            Pause();

            WriteLine("After returning the Journals");
            WriteLine("-------------------------");
            PrintItems(theJournals);
        }



        // Precondition:  None
        // Postcondition: The books have been printed to the console
        public static void PrintItems(List<LibraryItem> items)
        {
            foreach (LibraryItem i in items)
            {
                WriteLine(i);
                WriteLine();
            }
        }

        // Precondition:  None
        // Postcondition: Pauses program execution until user presses Enter and
        //                then clears the screen
        public static void Pause()
        {
            WriteLine("Press Enter to Continue...");
            ReadLine();

            Clear(); // Clear screen
        }
    }
}