using Exam_12_2_2025.Entity;

namespace Exam_12_2_2025.Service;

public class AllServices
{
    public void Task_1(List<City> cities)
    {
        var populationarCity = cities
            .Where(p => p.Population > 3000000)
            .SelectMany(c => c.People)
            .Select(s => new
            {
                personName = s.FullName, personAge = s.Age, personCity = s.City.Name,
                personCountry = s.City.Country.Name
            });
        populationarCity.Dump("Города милионики по населению");
        // foreach (var item in populationarCity)
        // {
        //     Console.WriteLine(item.personName);
        // }
    }
    
    public void Task_2(List<City> cities)
    {
        var result = cities
            .GroupBy(c => c.Country)
            .Select(g => new
            {
                CountryName = g.Key.Name,
                AvgPopulation = g.Average(c => c.Population),
                BigCities = g
                    .Where(c => c.Population > g.Average(x => x.Population))
                    .Select(c => new { c.Name, c.Population })
                    .ToList()
            })
            .Where(x => x.BigCities.Any())
            .Select(x => new
            {
                x.CountryName,
                Среднее_население = x.AvgPopulation,
                Города_выше_среднего = string.Join(" | ", 
                    x.BigCities.Select(c => $"{c.Name} ({c.Population})"))
            });
        result.Dump("Города с населением выше среднего по своей стране");
    }

    public void Task_3(List<City> cities)
    {
        var result = cities
            .GroupBy(c => c.Country.Name)
            .Select(g => g.OrderByDescending(c => c.Population)
                .First())
            .Select(c => new
            {
                Country = c.Country.Name,
                City = c.Name,
                Population = c.Population
            });

        result.Dump("Самый большой город в стране");
    }
    
    public void Task_4(List<City> cities)
    {
        var result = cities
            .SelectMany(c => c.People)              
            .Select(p => new
            {
                FullName = p.FullName,
                CityName = p.City.Name,
                CountryName = p.City.Country.Name
            });

        result.Dump("Все люди + их город и страна");
    }
    
    public void Task_5()
}