using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

// This controller renders Movies and TV series fetched from the TMdb APi
// The following endpoints are used:
// - https://developers.themoviedb.org/3/account/get-movie-watchlist
// - https://developers.themoviedb.org/3/account/get-tv-show-watchlist

namespace MvcMovie.Controllers
{
    public class TmdbController : Controller
    {
        private IConfiguration configuration;

        static HttpClient client = new HttpClient();

        // Receives the configuration using DI which is used for the TMdb API
        public TmdbController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // GET: /<controller>/
        // Redirects to the home page
        public IActionResult Index()
        {
            return RedirectToRoute(new { controller = "Default" });
        }

        // GET: /<controller>/FavoriteMovies
        // Shows the Favorite movies which are fetched from the TMdb API
        public async Task<IActionResult> FavoriteMovies()
        {
            // Default empty response
            Responses.Movies model = new Responses.Movies();
            // Fetch the movies
            HttpResponseMessage response = await this.FetchFromTmdb("watchlist/movies");

            if (response.IsSuccessStatusCode)
            {
                // Read the response and automatically parse the JSON response and convert it to a Movies response.
                model = await response.Content.ReadAsAsync<Responses.Movies>();
            }

            return View(model);
        }

        // GET: /<controller>/FavoriteSeries
        // Shows the Favorite TV series which are fetched from the TMdb API
        public async Task<IActionResult> FavoriteSeries()
        {
            // Default empty response
            Responses.Series model = new Responses.Series();
            // Fetch the TV series
            HttpResponseMessage response = await this.FetchFromTmdb("watchlist/tv");

            if (response.IsSuccessStatusCode)
            {   
                // Read the response and automatically parse the JSON response and convert it to a Series response.
                model = await response.Content.ReadAsAsync<Responses.Series>();
            }

            return View(model);
        }

        // Create the API request to TMdb using a given path, it reads the configuration from appsettings.json/Azure Application settings
        private async Task<HttpResponseMessage> FetchFromTmdb(string path) {
            String apiKey = this.configuration.GetSection("tmdb:api_key").Value;
            String sessionId = this.configuration.GetSection("tmdb:session_id").Value;
            String accountId = this.configuration.GetSection("tmdb:account_id").Value;
            // Construct the API url
            String watchlistUrl = $"https://api.themoviedb.org/3/account/{accountId}/{path}?api_key={apiKey}&language=en-US&session_id={sessionId}&sort_by=created_at.asc&page=1";;
            // Do the request
            HttpResponseMessage response = await client.GetAsync(watchlistUrl);

            return response;
        }
    }
}
