using Exam_12_2_2025.Entity;
using Exam_12_2_2025.Service;

AllServices allServices = new AllServices();
var countries = new List<Country>
{
    new() { Id = 1, Name = "Таджикистан" },
    new() { Id = 2, Name = "Узбекистан" },
    new() { Id = 3, Name = "Россия" },
    new() { Id = 4, Name = "Казахстан" },
    new() { Id = 5, Name = "Киргизия" },
    new() { Id = 6, Name = "Туркменистан" },
    new() { Id = 7, Name = "Афганистан" },
    new() { Id = 8, Name = "Китай" },
    new() { Id = 9, Name = "Иран" },
    new() { Id = 10, Name = "Украина" }
};


var cities = new List<City>
{
    
    new City { Id = 1, Name = "Душанбе", Population = 950_000, CountryId = 1, Country = countries[0], People = new List<Person>
    {
        new() { Id = 1, FullName = "Алиев Шариф",      Age = 34, CityId = 1 },
        new() { Id = 2, FullName = "Рахмонова Зарина", Age = 28, CityId = 1 },
        new() { Id = 3, FullName = "Содиков Джамшед",  Age = 95, CityId = 1 }, 
        new() { Id = 4, FullName = "Хасанов Фаррух",   Age = 19, CityId = 1 },
        new() { Id = 5, FullName = "Курбонова Малика", Age = 67, CityId = 1 }
    }},

    
    new City { Id = 2, Name = "Москва", Population = 13_200_000, CountryId = 3, Country = countries[2], People = new List<Person>
    {
        new() { Id = 6,  FullName = "Иванов Пётр",        Age = 45, CityId = 2 },
        new() { Id = 7,  FullName = "Сидорова Анна",      Age = 31, CityId = 2 },
        new() { Id = 8,  FullName = "Козлов Дмитрий",     Age = 29, CityId = 2 },
        new() { Id = 9,  FullName = "Морозова Екатерина", Age = 27, CityId = 2 },
        new() { Id = 10, FullName = "Петров Алексей",     Age = 52, CityId = 2 }
    }},

    
    new City { Id = 3, Name = "Пекин", Population = 22_000_000, CountryId = 6, Country = countries[5], People = new List<Person>
    {
        new() { Id = 11, FullName = "Ли Ван",         Age = 33, CityId = 3 },
        new() { Id = 12, FullName = "Чжан Мин",       Age = 27, CityId = 3 },
        new() { Id = 13, FullName = "Ван Лэй",        Age = 40, CityId = 3 },
        new() { Id = 14, FullName = "Чжао Хуэй",      Age = 29, CityId = 3 },
        new() { Id = 15, FullName = "Лю Янь",         Age = 35, CityId = 3 }
    }},

    
    new City { Id = 4, Name = "Ташкент", Population = 2_700_000, CountryId = 2, Country = countries[1], People = new List<Person>
    {
        new() { Id = 16, FullName = "Усманов Бекзод",   Age = 30, CityId = 4 },
        new() { Id = 17, FullName = "Каримова Гульнора",Age = 25, CityId = 4 },
        new() { Id = 18, FullName = "Ахмедов Дильшод",  Age = 41, CityId = 4 }
    }},

    
    new City { Id = 5, Name = "Алматы", Population = 2_200_000, CountryId = 4, Country = countries[3], People = new List<Person>
    {
        new() { Id = 19, FullName = "Нурланов Азамат", Age = 34, CityId = 5 },
        new() { Id = 20, FullName = "Садыкова Айгуль", Age = 28, CityId = 5 }
    }},

    
    new City { Id = 6, Name = "Бишкек", Population = 1_200_000, CountryId = 5, Country = countries[4], People = new List<Person>
    {
        new() { Id = 21, FullName = "Токтобеков Нурлан", Age = 32, CityId = 6 },
        new() { Id = 22, FullName = "Жумабекова Айжан", Age = 26, CityId = 6 }
    }},

    
    new City { Id = 7, Name = "Кабул", Population = 4_500_000, CountryId = 8, Country = countries[7], People = new List<Person>
    {
        new() { Id = 23, FullName = "Ахмади Мохаммад", Age = 40, CityId = 7 },
        new() { Id = 24, FullName = "Халил Фатима",   Age = 29, CityId = 7 }
    }},

    
    new City { Id = 8, Name = "Киев", Population = 2_900_000, CountryId = 9, Country = countries[8], People = new List<Person>
    {
        new() { Id = 25, FullName = "Шевченко Анна",   Age = 27, CityId = 8 },
        new() { Id = 26, FullName = "Коваленко Игорь", Age = 45, CityId = 8 }
    }},

    
    new City { Id = 9, Name = "Дели", Population = 32_000_000, CountryId = 10, Country = countries[9], People = new List<Person>
    {
        new() { Id = 27, FullName = "Сингх Амар",    Age = 38, CityId = 9 },
        new() { Id = 28, FullName = "Кумар Прия",    Age = 31, CityId = 9 },
        new() { Id = 29, FullName = "Гупта Рахул",   Age = 29, CityId = 9 }
    }},

    
    new City { Id = 10, Name = "Худжанд", Population = 200_000, CountryId = 1, Country = countries[0], People = new List<Person>
    {
        new() { Id = 30, FullName = "Мирзоев Фарход", Age = 44, CityId = 10 }
    }}
};


foreach (var city in cities)
{
    foreach (var person in city.People)
    {
        person.City = city;           
    }
    city.Country.Cities ??= new List<City>();
    if (!city.Country.Cities.Contains(city))
        city.Country.Cities.Add(city);
}
var people = new List<Person>
{
    new() { Id = 1, FullName = "Алиев Шариф Джумович", Age = 34, CityId = 1 },
    new() { Id = 2, FullName = "Рахимова Зарина", Age = 28, CityId = 1 },
    new() { Id = 3, FullName = "Мирзоев Фарход", Age = 45, CityId = 2 },
    new() { Id = 4, FullName = "Саидов Далер", Age = 19, CityId = 1 },
    new() { Id = 5, FullName = "Каримова Малика", Age = 67, CityId = 3 },
    new() { Id = 6, FullName = "Иванов Сергей Петрович", Age = 52, CityId = 4 },
    new() { Id = 7, FullName = "Нурматов Бекзод", Age = 31, CityId = 5 },
    new() { Id = 8, FullName = "Ахмедова Гульнора", Age = 23, CityId = 6 },
    new() { Id = 9, FullName = "Амиров Фарход", Age = 40, CityId = 2 },
    new() { Id = 10, FullName = "Содиков Джамшед", Age = 95, CityId = 1 } 
};

allServices.Task_1(cities);
allServices.Task_2(cities);
allServices.Task_3(cities);
allServices.Task_4(cities);
allServices.Task_5(countries);
allServices.Task_6(countries);
allServices.Task_7(countries);
allServices.Task_8(countries);
allServices.Task_9(countries);
allServices.Task_10(countries);
