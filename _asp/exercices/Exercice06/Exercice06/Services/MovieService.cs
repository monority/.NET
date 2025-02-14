using Exercice06.Entities;
using Exercice06.Data;
using Exercice06.Models;
using Microsoft.EntityFrameworkCore;
namespace Exercice06.Services;

public class MovieService : IMovieService
{
    private readonly ApplicationDbContext _db;
    private readonly IUploadPictureService _uploadService;

    public MovieService(ApplicationDbContext db, IUploadPictureService uploadService)
    {
        _db = db;
        _uploadService = uploadService;
    }


    public MovieViewModel? Create(MovieCreateViewModel vm)
    {
        var entity = ToEntity(vm);
        _db.Set<Movie>().Add(entity);
        _db.SaveChanges();

        return ToViewModel(entity);
    }


    public IEnumerable<MovieViewModel> GetAll()
    {
        return _db.Movies.Select(ToViewModel).ToHashSet();
    }

    public MovieViewModel? GetById(long id)
    {
        var movieFound = _db.Movies.FirstOrDefault(m => m.Id == id);
        if (movieFound == null)
        {
            return null;
        }
        return ToViewModel(movieFound);
    }
    private Picture ToEntity(MovieCreateViewModel vm)
    {
        return new Picture()
        {
            Id = (int)(_db.Movies.Max(x => x.Id) + 1), 
  

            PictureUrl = _uploadService.Upload(vm.Picture) 
        };
    }

    private MovieViewModel ToViewModel(MovieViewModel movie)
    {
        return new MovieViewModel()
        {
            Id = movie.Id,
            Title = movie.Title,
            Director = movie.Director,
            Duration = movie.Duration,
            Status = movie.Status,
            PictureUrl = movie.PictureUrl
        };
    }
    public MovieViewModel? Update(MovieViewModel entity)
    {
        var movieFound = _db.Movies.FirstOrDefault(c => c.Id == entity.Id);
        if (movieFound == null) return null;

        movieFound.Title = entity.Title;
        movieFound.Status = entity.Status;
        movieFound.Director = entity.Director;
        movieFound.Duration = entity.Duration;
        movieFound.PictureUrl = entity.PictureUrl;

        _db.SaveChanges();
        return movieFound;
    }


    public MovieViewModel? Delete(MovieViewModel entity)
    {
        var movieToDelete = _db.Movies.FirstOrDefault(m => m.Id == entity.Id);
        if (movieToDelete == null)
        {
            return null;
        }
        _db.Movies.Remove(movieToDelete);
        _db.SaveChanges();
        return movieToDelete;
    }
}
