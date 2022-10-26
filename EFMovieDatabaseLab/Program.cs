using EFMovieDatabaseLab.Models;

namespace EFMovieDatabaseLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MoviesDbContext db = new MoviesDbContext();

            List<Movie> movies = db.Movies.ToList();

            PrintMovies(movies);

            Console.WriteLine("Would you like to search for a movie by 'title' or by 'genre'?");
            string input = Console.ReadLine().ToLower();

            if(input == "title")
            {
                SearchByTitle(movies);
            }
            else if(input == "genre")
            {
                SearchByGenre(movies);
            }
            else
            {
                Console.WriteLine("You needed to enter 'title' or 'genre'.");
            }
        }

        public static void PrintMovies(List<Movie> movies)
        {
            int i = 1;
            foreach(Movie movie in movies)
            {
                Console.WriteLine(i + " " + movie.Title);
                i++;
            }
        }

        public static void SearchByGenre(List<Movie> movies)
        {
            Console.WriteLine("Which genre are you searching for?");
            string genre = Console.ReadLine().ToLower();
            List<Movie> sorted = movies.Where(m => m.Genre.ToLower() == genre).ToList();
            Console.WriteLine($"Okay, here is your new list of {genre} movies:");
            int i = 1;
            foreach(Movie m in sorted)
            {
                Console.WriteLine($"{i}: {m.Title}");
                i++;
            }
            Console.WriteLine("Use the indexes to select which movie's details you'd like to see.");
            int pick = int.Parse(Console.ReadLine());
            PrintMovie(sorted[pick - 1]);
        }

        public static void SearchByTitle(List<Movie> movies)
        {
            Console.WriteLine("Which title are you searching for?");
            string title = Console.ReadLine();
            List<Movie> sorted = movies.Where(m => m.Title.ToLower().Contains(title)).ToList();
            Console.WriteLine($"Here are the movies containing {title}");
            int i = 1;
            foreach (Movie m in sorted)
            {
                Console.WriteLine($"{i}: {m.Title}");
                i++;
            }
            Console.WriteLine("Use the indexes to select which movie's details you'd like to see.");
            int pick = int.Parse(Console.ReadLine());
            PrintMovie(sorted[pick-1]);
        }

        public static void PrintMovie(Movie m)
        {
            Console.WriteLine($"Title: {m.Title}");
            Console.WriteLine($"Genre: {m.Genre}");
            Console.WriteLine($"Runtime: {m.Runtime}");
        }
    }
}