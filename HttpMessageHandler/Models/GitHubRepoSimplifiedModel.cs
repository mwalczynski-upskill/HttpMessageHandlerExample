namespace HttpMessageHandler.Models
{
    using Newtonsoft.Json;

    public class GitHubRepoSimplifiedModel
    {
        [JsonProperty("Name")]
        public string RepositoryName { get; set; }
        [JsonProperty("Url")]
        public string RepositoryUrl { get; set; }
    }
}
