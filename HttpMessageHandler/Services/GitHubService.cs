namespace HttpMessageHandler.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Models;
    using Newtonsoft.Json;

    public interface IGitHubService
    {
        Task<IEnumerable<GitHubRepoSimplifiedModel>> GetRepositories(string userName);
    }

    public class GitHubService : IGitHubService
    {
        private readonly HttpClient _httpClient;

        private const string _reposUrl = "https://api.github.com/users/{0}/repos";

        public GitHubService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36");
            _httpClient.DefaultRequestHeaders.Add("SECRET-API-HEADER", "SECRET-API-HEADER-VALUE");
        }

        public async Task<IEnumerable<GitHubRepoSimplifiedModel>> GetRepositories(string userName)
        {
            var response = await _httpClient.GetAsync(string.Format(_reposUrl, userName));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var listOfRepos = JsonConvert.DeserializeObject<ICollection<GitHubRepoSimplifiedModel>>(content);
                return listOfRepos;
            }

            return Enumerable.Empty<GitHubRepoSimplifiedModel>();
        }
    }
}
