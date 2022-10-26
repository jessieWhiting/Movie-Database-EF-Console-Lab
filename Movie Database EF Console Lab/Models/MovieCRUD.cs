using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie_Database_EF_Console_Lab;
using static System.Collections.Specialized.BitVector32;
using static System.Reflection.Metadata.BlobBuilder;

namespace Movie_Database_EF_Console_Lab.Models
{
    internal class MovieCRUD
    {
        public void UserSelection()
        {
            bool goAgain = true;        

            MovieContext db = new MovieContext();

            List<Movie> movies = db.Movies.ToList();

            Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Movie List: ");
            Console.ResetColor();
            Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");


            while (goAgain)
            {
                Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                Console.WriteLine("Enter |Title[T]| OR |GENRE[G]|: ");
                Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
               
                    string user = Console.ReadLine().ToUpper();
                    Console.Clear();
                if (user == "GENRE" || user == "G")
                {

                    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                    Console.WriteLine("Enter Genre: ");
                    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                    Console.WriteLine("Horror");
                    Console.WriteLine("Action");
                    Console.WriteLine("Drama");
                    Console.WriteLine("Comedy");
                    Console.WriteLine("Romance");

                    string userInput = Console.ReadLine().ToUpper();

                    if (user == "HORROR" || user == "ACTION" || user == "DRAMA" || user == "COMEDY"
                        || user == "ROMANCE")
                    {
                        List<Movie> listGenres = SearchByGenre(userInput, movies);

                        PrintMovies(listGenres);


                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                        Console.WriteLine("GENRE UNAVAILABLE");
                        Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                        Console.ResetColor();
                        continue;
                    }


                }
                else if (user == "TITLE" || user == "T")
                {
                    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                    Console.WriteLine("Enter Title: ");
                    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");

                    Console.WriteLine("The Conjuring ");
                    Console.WriteLine("Pulp Fiction ");
                    Console.WriteLine("The Shawshank Redemption ");
                    Console.WriteLine("Trick 'r Treat ");
                    Console.WriteLine("Idiocracy ");
                    Console.WriteLine("Gladiator ");
                    Console.WriteLine("Meet The Parents ");
                    Console.WriteLine("Jurassic Park ");
                    Console.WriteLine("Bob The Butler");
                    Console.WriteLine("Satan's Blood");
                    Console.WriteLine("Factory Girl");

                    string input = Console.ReadLine().ToUpper().Trim();
                    Console.Clear();

                    List<Movie> listTitles = SearchByTitle(input, movies);
                    if (input == "THE CONJURING" || input == "PULP FICTION" || input == "THE SHAWSHANK REDEMPTION"
                        || input == "TRICK 'R TREAT" || input == "IDIOCRACY" || input == "GLADIATOR" || input == "MEET THE PARENTS"
                        || input == "JURASSIC PARK" || input == "BOB THE BUTLER" || input == "SATAN'S BLOOD" || input == "FACTORY GIRL")

                    {
                        PrintMovies(listTitles);

                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                        Console.WriteLine("TITLE UNAVAILABLE");
                        Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                        Console.ResetColor();

                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                    Console.WriteLine("INVALID INPUT");
                    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                    Console.ResetColor();
                    UserSelection();
                }
                     
                        goAgain = GoAgain();
            }
        }
        public bool GoAgain()
        {
            Console.WriteLine("Search Again |YES[Y]| OR |NO[N]|?: ");
            string input = Console.ReadLine().ToUpper();

            if (input == "YES" || input == "Y")
            {
                return true;
            }
            else if (input == "NO" || input == "N")
            {
                Console.WriteLine("EXIT: ");
                return false;
            }
            else
            {
                Console.WriteLine("INVALID INPUT");
                return GoAgain();
            }
        }

        //Method for TITLE LIST
        public List<Movie> SearchByTitle(string userInput, List<Movie> movies)
        {

            List<Movie> listTitles = movies.Where(n => n.Title.ToUpper() == userInput).ToList();
    

            return listTitles;
        }
        //Method for GENRE LIST
        public List<Movie> SearchByGenre(string userInput, List<Movie> movies)
        {

            List<Movie> listGenres = movies.Where(n => n.Genre.ToUpper() == userInput).ToList();

            return listGenres;
        }
        public void PrintMovies(List<Movie> movieList)
        {
            Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("MOVIE DETAILS: ");
            Console.ResetColor();
            Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");

            foreach (Movie movie in movieList)
            {
             
                Console.WriteLine($"{movie.Id}.) MOVIE: {movie.Title} ||| GENRE: {movie.Genre} |||RUNTIME: {movie.Runtime} MINS");
             
            }
        }
    }
}

