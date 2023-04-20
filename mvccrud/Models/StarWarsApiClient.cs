using Newtonsoft.Json;



namespace mvccrud.Models
{
    public class StarWarsApiClient
    {
        private readonly HttpClient _httpClient;

        public StarWarsApiClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<StarWarsApiResponse> GetCharacters()
        {
            var response = await _httpClient.GetAsync("https://swapi.dev/api/people/");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<StarWarsApiResponse>(content);

            return result;
        }
    }

    public class StarWarsApiResponse
    {
        public string Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public StarWarsCharacter[] Results { get; set; }
    }

    public class StarWarsCharacter
    {
        public string Name { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
        public string HairColor { get; set; }
        public string SkinColor { get; set; }
        public string EyeColor { get; set; }
        public string BirthYear { get; set; }
        public string Gender { get; set; }
    }
}
