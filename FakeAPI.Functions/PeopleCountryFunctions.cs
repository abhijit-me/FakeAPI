using System.Net;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace FakeAPI.Functions;

public class PeopleCountryFunctions
{
    [Function("GetPeopleByCountry")]
    public async Task<HttpResponseData> GetPeopleByCountry(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "people-by-country")] HttpRequestData request)
    {
        var query = QueryHelpers.ParseQuery(request.Url.Query);
        if (!query.TryGetValue("country", out var countryValues) || string.IsNullOrWhiteSpace(countryValues[0]))
        {
            var badRequest = request.CreateResponse(HttpStatusCode.BadRequest);
            await badRequest.WriteAsJsonAsync(new { error = "Query parameter 'country' is required." });
            return badRequest;
        }

        var country = countryValues[0]!;
        var people = PeopleCountryMapping.PersonToCountry
            .Where(entry => string.Equals(entry.Value, country, StringComparison.OrdinalIgnoreCase))
            .Select(entry => entry.Key)
            .OrderBy(person => person)
            .ToList();

        var response = request.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(new { country, people });
        return response;
    }

    [Function("GetCountryByPerson")]
    public async Task<HttpResponseData> GetCountryByPerson(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "country-by-person")] HttpRequestData request)
    {
        var query = QueryHelpers.ParseQuery(request.Url.Query);
        if (!query.TryGetValue("person", out var personValues) || string.IsNullOrWhiteSpace(personValues[0]))
        {
            var badRequest = request.CreateResponse(HttpStatusCode.BadRequest);
            await badRequest.WriteAsJsonAsync(new { error = "Query parameter 'person' is required." });
            return badRequest;
        }

        var person = personValues[0]!;
        if (!PeopleCountryMapping.PersonToCountry.TryGetValue(person, out var country))
        {
            var notFound = request.CreateResponse(HttpStatusCode.NotFound);
            await notFound.WriteAsJsonAsync(new { error = $"No country mapping found for person '{person}'." });
            return notFound;
        }

        var response = request.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(new { person, country });
        return response;
    }

    [Function("GetCountries")]
    public async Task<HttpResponseData> GetCountries(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "countries")] HttpRequestData request)
    {
        var response = request.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(PeopleCountryMapping.Countries);
        return response;
    }
}
