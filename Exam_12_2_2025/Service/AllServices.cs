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

    public void Task_5(List<Country> countries)
    {
        var result = from country in countries
            from city in country.Cities
            where city.People.Any(p => p.FullName == "Фарход")
            select city;
        result.Dump($"Города в которых есть хотя бы один человек с именем 'Фарход'");
    }

    public void Task_6(List<Country> countries)
    {
        var result = from country in countries
            from city in country.Cities
            select city.People.OrderBy(p => p.Age).First();
        result.Dump($"Старшый человек в каждом городе");
        
    }

    public void Task_7(List<Country> countries)
    {
        var result = from country in countries
            let maxPopulation = country.Cities.Max(c => c.Population)
            from city in country.Cities
            where city.Population == maxPopulation
            from person in city.People
            select person;
        result.Dump($"Люди которые живуть в самом густонаселёном городе");
        
    }

    public void Task_8(List<Country> countries)
    {
        var result = from country in countries
            from city in country.Cities
            where city.Name.Length == 5 
            from person in city.People
            select person;
        result.Dump($"Все люди которые живут в городах чьё имя больше по  длине 5");
        
    }

    public void Task_9(List<Country> countries)
    {
        var result = from country in countries
            let youngest = (from city in country.Cities
                from person in city.People
                orderby person.Age
                select new { CountryName = country.Name, CityName = city.Name, person.Age }).First()
            select youngest;
        result.Dump($"Молодй челвоек в каждой стране");
        
    }

    public void Task_10(List<Country> countries)
    {
        var result = from country in countries
            from city in country.Cities
            from person in city.People
            where person.Age >= 20 && person.Age <= 30
            group person by country
            into g
            select g;
        result.Dump($"Люди которые попадают в диапазон 25-30 лет");
        
    }
}