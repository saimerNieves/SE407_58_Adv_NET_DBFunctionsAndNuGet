using BlockBuster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBuster
{
    public class BlockBusterBasicFunctions
    {

        public static Movie GetMovieById(int id)
        {

            try
            {
                using (var context = new SE407_BlockBusterContext())
                {
                    return context.Movies.Find(id);//Basic select
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return null;

            }
        }

        public static List<Movie> GetAllMovies()
        {
            try
            {
                using (var context = new SE407_BlockBusterContext())
                {
                    return context.Movies.ToList();//Basic select
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return null;

            }
        }

        public static List<Movie> GetAllCheckedOutMovies()
        {

            try
            {
                using (var context = new SE407_BlockBusterContext())
                {

                    return context.Movies

                        .Join(context.Transactions,
                        m => m.MovieId,
                        t => t.MovieId,
                        (m, t) => new
                        {
                            MovieId = m.MovieId,
                            Title = m.Title,
                            ReleaseYear = m.ReleaseYear,
                            GenreId = m.GenreId,
                            DirectorId = m.DirectorId,
                            CheckedIn = t.CheckedIn
                        }).Where(w => w.CheckedIn == "N")
                        .Select(m => new Movie
                        {

                            MovieId = m.MovieId,
                            Title = m.Title,
                            ReleaseYear = m.ReleaseYear,
                            GenreId = m.GenreId,
                            DirectorId = m.DirectorId,

                        }).ToList();//Basic select
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return null;

            }
        }


        //Assignment Functions

        //Create get all Movies by Genre Description 
        public static List<Movie> GetAllMoviesByGenreDescription(string genreDescription)
        {

            try
            {
                using (var context = new SE407_BlockBusterContext())
                {

                    return context.Movies

                        .Join(context.Genres,
                        m => m.GenreId,
                        g => g.GenreId,
                        (m, g) => new
                        {
                            MovieId = m.MovieId,
                            Title = m.Title,
                            ReleaseYear = m.ReleaseYear,
                            GenreId = m.GenreId,
                            DirectorId = m.DirectorId,
                            GenreDescr = g.GenreDescr
                        }).Where(w => w.GenreDescr == genreDescription)
                        .Select(m => new Movie
                        {
                            MovieId = m.MovieId,
                            Title = m.Title,
                            ReleaseYear = m.ReleaseYear,
                            GenreId = m.GenreId,
                            DirectorId = m.DirectorId,

                        }).ToList();//Basic select
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return null;

            }

            
        }

        //Create get all Movies by Director Last Name

        public static List<Movie> GetAllMoviesByDirectorLastName(string directorLastName)
        {

            try
            {
                using (var database = new SE407_BlockBusterContext())
                {

                    return database.Movies

                        .Join(database.Directors,
                        m => m.DirectorId,
                        d => d.DirectorId,
                        (m, d) => new
                        {
                            MovieId = m.MovieId,
                            Title = m.Title,
                            ReleaseYear = m.ReleaseYear,
                            GenreId = m.GenreId,
                            DirectorId = m.DirectorId,
                            directorFirstName = d.FirstName,
                            directorLastName = d.LastName
                        }).Where(d => d.directorLastName == directorLastName)
                        .Select(m => new Movie
                        {

                            MovieId = m.MovieId,
                            Title = m.Title,
                            ReleaseYear = m.ReleaseYear,
                            GenreId = m.GenreId,
                            DirectorId = m.DirectorId,


                        }).ToList();//Basic select
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return null;

            }
        }

    

        //Create get all Movies by Director Last Name
    }
}

    
