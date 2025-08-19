namespace Portfolio.Models;

public class UserEntity
{
    public string Names { get; set; }
    public string LastNames { get; set; }
    public DateTime BirthDay { get; set; }

    public int GetAge()
    {
        var age = DateTime.Today.Year - BirthDay.Year;
        return DateTime.Today < BirthDay.AddYears(age) ? age - 1 : age;
    }

    public string GetFullNames()
    {
        return Names + " " + LastNames;
    }
}