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

        public async Task<Collection> GetCollection(string collectionKey)
        {
            using var response = await _httpClient.GetAsync($"api/users/0/collections/{collectionKey}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadFromJsonAsync<JsonElement>();
            return new Collection(json);
        }

        public async Task<IEnumerable<Collection>> GetSubCollectionsAsync(string collectionKey)
        {
            using var response = await _httpClient.GetAsync($"api/users/0/collections/{collectionKey}/collections");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadFromJsonAsync<JsonElement>();
            return json.EnumerateArray().Select(x => new Collection(x));
        }

        public async Task<IEnumerable<ZoteroItem>> GetItemsByCollectionAsync(string collectionKey)
        {
            using var response = await _httpClient.GetAsync($"api/users/0/collections/{collectionKey}/items");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadFromJsonAsync<JsonElement>();
            return json.EnumerateArray().Select(ItemFactory.CreateItem);
        }

        public async Task<IDictionary<string, string>> GetItemFieldsAsync()
        {
            using var response = await _httpClient.GetAsync($"api/itemFields");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadFromJsonAsync<JsonElement>();
            return json.EnumerateArray().Select(x => new
            {
                key = x.GetProperty("field").GetString()!,
                value = x.GetProperty("localized").GetString()!,
            }).ToDictionary(x => x.key, v => v.value);
        }

    }
}
