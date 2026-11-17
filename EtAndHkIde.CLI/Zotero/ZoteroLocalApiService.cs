using System.Net.Http.Json;
using System.Text.Json;

namespace EtAndHkIde.CLI.Zotero
{
    internal class ZoteroLocalApiService
    {
        private readonly HttpClient _httpClient;

        public ZoteroLocalApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:23119/")
            };
        }

        public async Task<IEnumerable<Collection>> GetCollectionsAsync()
        {
            using var response = await _httpClient.GetAsync("api/users/0/collections");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadFromJsonAsync<JsonElement>();
            return json.EnumerateArray().Select(x => new Collection(x));
        }

        public async Task<IEnumerable<ZoteroItem>> GetByCollectionAsync(string collectionKey)
        {
            using var response = await _httpClient.GetAsync($"api/users/0/collections/{collectionKey}/items");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadFromJsonAsync<JsonElement>();
            return json.EnumerateArray().Select(ItemFactory.CreateItem);
        }
    }
}
