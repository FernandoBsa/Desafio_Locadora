using System.Text.RegularExpressions;
using Locadora.Core.DomainObjects;

namespace Locadora.Domain.Entities;

public class Director : Entity
{
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public const int MIN_LENGTH = 3;
    public const int MAX_LENGTH = 30;
    private List<Dvd> _dvds = new List<Dvd>();
    public IReadOnlyList<Dvd> Dvds => _dvds;
    
    protected Director()
    {
        
    }

    public Director(string name, string surname)
    {
        UpdateName(name);
        UpdateSurName(surname);
    }

    public string FullName()
    {
        return $"{Name} {Surname}";
    }

    public void UpdateName(string name)
    {
        if (!ValidateName(name))
            throw new DomainException($"Invalid name for director");
        
        Name = name;
    }

    public void UpdateSurName(string surName)
    {
        if (!ValidateName(surName))
            throw new DomainException($"Invalid surname for director");
        
        Surname = surName;
    }

    private bool ValidateName(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length < MIN_LENGTH || value.Length > MAX_LENGTH)
            return false;

        return Regex.IsMatch(value, "^(?=.*[A-ZÀ-ÿ~])(?=.*[a-zà-ÿ~])[A-Za-zÀ-ÿ~]+$");
    }
}