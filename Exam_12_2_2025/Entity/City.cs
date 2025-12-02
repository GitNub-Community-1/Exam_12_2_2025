namespace Exam_12_2_2025.Entity;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Population { get; set; }
    public int CountryId { get; set; }
    public Country Country { get; set; }
    public List<Person> People { get; set; } = new();
}