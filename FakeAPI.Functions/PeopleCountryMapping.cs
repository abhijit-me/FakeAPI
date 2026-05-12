namespace FakeAPI.Functions;

public static class PeopleCountryMapping
{
    public static readonly IReadOnlyDictionary<string, string> PersonToCountry =
        new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            ["Aarav"] = "India",
            ["Vivaan"] = "India",
            ["Aditya"] = "India",
            ["Arjun"] = "India",
            ["Sai"] = "India",
            ["Charlotte"] = "Australia",
            ["Oliver"] = "Australia",
            ["Amelia"] = "Australia",
            ["Noah"] = "Australia",
            ["Matilda"] = "Australia",
            ["Liam"] = "United States",
            ["Emma"] = "United States",
            ["Mason"] = "United States",
            ["Olivia"] = "United States",
            ["Ethan"] = "United States",
            ["George"] = "England",
            ["Harry"] = "England",
            ["Jack"] = "England",
            ["Sophia"] = "England",
            ["Isla"] = "England",
            ["Louis"] = "France",
            ["Gabriel"] = "France",
            ["Jules"] = "France",
            ["EmmaFrance"] = "France",
            ["Lea"] = "France",
            ["Lukas"] = "Germany",
            ["Leon"] = "Germany",
            ["Finn"] = "Germany",
            ["MiaGermany"] = "Germany",
            ["Emilia"] = "Germany",
            ["Kabir"] = "India",
            ["Rohan"] = "India",
            ["Ishaan"] = "India",
            ["Aryan"] = "India",
            ["Kiran"] = "India",
            ["William"] = "Australia",
            ["Ruby"] = "Australia",
            ["James"] = "Australia",
            ["Sophie"] = "Australia",
            ["Henry"] = "Australia",
            ["Ava"] = "United States",
            ["Logan"] = "United States",
            ["Ella"] = "United States",
            ["Lucas"] = "United States",
            ["MiaUS"] = "United States",
            ["Arthur"] = "England",
            ["Freddie"] = "England",
            ["Theo"] = "England",
            ["Nora"] = "France",
            ["Hannah"] = "Germany"
        };

    public static readonly IReadOnlyList<string> Countries =
        PersonToCountry.Values
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(country => country)
            .ToList();
}
