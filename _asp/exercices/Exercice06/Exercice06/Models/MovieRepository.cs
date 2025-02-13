using Exercice06.Models;
namespace Demo01.Data;

public class MovieRepository : BaseRepository, IRepository<Movie>
{
    public MovieRepository(ApplicationDbContext context) : base(context)
    {
    }

    public Movie Create(Movie entity)
    {
        _context.Movies.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public bool Delete(Movie entity)
    {
        var movieFound = _context.Movies.FirstOrDefault(c => c.Id == entity.Id);
        if (movieFound == null) return false;
        _context.Movies.Remove(movieFound);
        _context.SaveChanges();
        return true;
    }

    public IEnumerable<Movie> GetAll()
    {
        var movies = _context.Movies.ToHashSet();
        return movies;
    }

    public Movie? GetById(int id)
    {
        var movieFound = _context.Movies.FirstOrDefault(c => c.Id == id);
        var movieFoundSingle = _context.Movies.SingleOrDefault(c => c.Id == id);
        return movieFound;
    }

    public Movie? Update(Movie entity)
    {
        var movieFound = _context.Movies.FirstOrDefault(c => c.Id == entity.Id);
        if (movieFound == null) return null;

        movieFound.Title = entity.Title;
        movieFound.Status = entity.Status;
        movieFound.Director = entity.Director;
        movieFound.Duration = entity.Duration;

        _context.SaveChanges();
        return movieFound;
    }
}
