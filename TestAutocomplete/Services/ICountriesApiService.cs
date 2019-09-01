using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAutocomplete.Models;

namespace TestAutocomplete.Services
{
    public interface ICountriesApiService
    {
        [Get("/all")]
        Task<List<Country>> GetAllCountriesAsync();
    }
}
