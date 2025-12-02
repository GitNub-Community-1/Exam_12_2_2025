namespace Exam_12_2_2025.Entity;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public List<City> Cities { get; set; } = new();
}