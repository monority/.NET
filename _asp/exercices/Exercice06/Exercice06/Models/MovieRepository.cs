using Exercice06.Models;
using Microsoft.EntityFrameworkCore;
namespace Exercice06.Data;

public class MovieRepository : BaseRepository, IRepository<MovieViewModel>
{
    public MovieRepository(ApplicationDbContext context) : base(context)
    {
    }

    public MovieViewModel Create(MovieViewModel entity)
    {
        _context.Movies.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public bool Delete(MovieViewModel entity)
    {
        var movieFound = _context.Movies.FirstOrDefault(c => c.Id == entity.Id);
        if (movieFound == null) return false;
        _context.Movies.Remove(movieFound);
        _context.SaveChanges();
        return true;
    }
    public IEnumerable<MovieViewModel> GetAll(Func<MovieViewModel, bool> predicate)
    {
        return _context.Movies.Where(predicate);
    }

    public IEnumerable<MovieViewModel> GetAll()
    {
        var movies = _context.Movies.ToHashSet();
        return movies;
    }

    public MovieViewModel? GetById(int id)
    {
        var movieFound = _context.Movies.FirstOrDefault(c => c.Id == id);
        var movieFoundSingle = _context.Movies.SingleOrDefault(c => c.Id == id);
        return movieFound;
    }

    public MovieViewModel? Update(MovieViewModel entity)
    {
        var movieFound = _context.Movies.FirstOrDefault(c => c.Id == entity.Id);
        if (movieFound == null) return null;

        movieFound.Title = entity.Title;
        movieFound.Status = entity.Status;
        movieFound.Director = entity.Director;
        movieFound.Duration = entity.Duration;
        movieFound.PictureUrl = entity.PictureUrl;

        _context.SaveChanges();
        return movieFound;
    }
}
