using Locadora.Core.DomainObjects;
using Locadora.Domain.Entities.Enums;

namespace Locadora.Domain.Entities;

public class Dvd : Entity
{
    public string Title { get; private set; }
    public EGenre Genre { get; private set; }
    public DateTime Published { get; private set; }
    public bool Available { get; private set; }
    public int Copies { get; private set; }
    public Guid DirectorId { get; private set; }
    public Director Director { get; set; }

    public const int MIN_TITLE_LENGTH = 2;
    public const int MAX_TITLE_LENGTH = 50;

    protected Dvd() { }

    public Dvd(string title, int genre, DateTime published, int copies, Guid directorId)
    {
        Available = true;
        UpdateTitle(title);
        UpdateGenre(genre);
        UpdatePublishedDate(published);
        UpdateCopies(copies);
        UpdateDirector(directorId);
    }

    public void RentCopy()
    {
        if(Copies == 0 || !Available)
            throw new DomainException($"DVD {Title} is not available to rent");
        
        var copies = Copies - 1;
        UpdateCopies(copies);
    }

    public void ReturnCopy()
    {
        if (!Available)
            throw new  DomainException($"DVD {Title} is not available");
        
        var copies = Copies + 1;
        UpdateCopies(copies);   
    }

    public void UpdateTitle(string title)
    {
        if (!Available)
            throw new DomainException($"DVD {Title} is not available");

        if (string.IsNullOrWhiteSpace(title) || title.Length < MIN_TITLE_LENGTH || title.Length > MAX_TITLE_LENGTH)
            throw new DomainException($"Invalid name {title} to a DVD");
        
        Title = title;
        UpdateAt = DateTime.UtcNow;
    }

    public void UpdateGenre(int genre)
    {
        if (!Available)
            throw new DomainException($"DVD {Title} is not available");
        
        Genre = genre switch
        {
            1 => EGenre.Action,
            2 => EGenre.Adventure,
            3 => EGenre.Animation,
            4 => EGenre.Comedy,
            5 => EGenre.Crime,
            6 => EGenre.Documentary,
            7 => EGenre.Drama,
            8 => EGenre.Fantasy,
            9 => EGenre.Family,
            10 => EGenre.Horror,
            11 => EGenre.Musical,
            12 => EGenre.Mystery,
            13 => EGenre.Romance,
            14 => EGenre.SciFi,
            15 => EGenre.Thriller,
            16 => EGenre.Western,
            17 => EGenre.Biography,
            18 => EGenre.Historic,
            19 => EGenre.War,
            _ => throw new DomainException("Invalid genre option!")
        };
        
        UpdateAt = DateTime.UtcNow;
    }

    public void UpdatePublishedDate(DateTime date)
    {
        if (!Available)
            throw new  DomainException($"DVD {Title} is not available");

        var todayDate = DateTime.UtcNow;

        if (todayDate < date)
            throw new  DomainException("Invalid published date");
        
        Published = date;
        UpdateAt = todayDate;
    }

    public void UpdateDirector(Guid directorId)
    {
        if (!Available)
            throw new DomainException($"DVD {Title} is not available");
        
        if (directorId == Guid.Empty)
            throw new DomainException("Invalid director's id");
        
        DirectorId = directorId;
        UpdateAt = DateTime.UtcNow;
    }

    public void UpdateCopies(int copies)
    {
        if (!Available)
            throw new DomainException($"DVD {Title} is not available");

        if (copies < 0)
            throw new DomainException("Number of copies must be greater than zero.");
        
        Copies = copies;
        UpdateAt = DateTime.UtcNow;
    }

    public void DeleteDvd()
    {
        if (!Available)
            throw new DomainException("DVD is already deleted");
        
        Available = false;
        Copies = 0;
        DeleteAt = DateTime.UtcNow;
    }



}