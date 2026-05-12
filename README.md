# FakeAPI
Fake Azure Function for testing

## Endpoints

This repository now includes a .NET 8 Azure Functions app at `/FakeAPI.Functions` with:

1. `GET /api/people-by-country?country={countryName}` - returns the people mapped to a country.
2. `GET /api/country-by-person?person={personName}` - returns the country for a person.
3. `GET /api/countries` - returns all countries in the static mapping.
