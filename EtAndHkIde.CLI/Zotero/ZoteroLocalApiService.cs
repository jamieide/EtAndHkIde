using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text.Json;

namespace EtAndHkIde.CLI.Zotero
{
    public class ZoteroLocalApiService
    {
        private readonly HttpClient _httpClient;

        public ZoteroLocalApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:23119/")
            };
#if DEBUG
            _httpClient.Timeout = TimeSpan.FromMinutes(10);
#endif
        }

        public async Task<ZoteroCollection> GetCollectionAsync(string collectionKey)
        {
            using var response = await _httpClient.GetAsync($"api/users/0/collections/{collectionKey}");
            response.EnsureSuccessStatusCode();
            return (await response.Content.ReadFromJsonAsync<ZoteroCollection>())!;
        }

        public async Task<List<ZoteroCollection>> GetSubCollectionsAsync(string collectionKey)
        {
            using var response = await _httpClient.GetAsync($"api/users/0/collections/{collectionKey}/collections");
            response.EnsureSuccessStatusCode();
            return (await response.Content.ReadFromJsonAsync<List<ZoteroCollection>>())!;
        }

        public async Task<List<ZoteroItem>> GetItemsByCollectionAsync(string collectionKey)
        {
            using var response = await _httpClient.GetAsync($"api/users/0/collections/{collectionKey}/items");
            response.EnsureSuccessStatusCode();
            return (await response.Content.ReadFromJsonAsync<List<ZoteroItem>>())!;
        }

        public async Task<List<ZoteroItem>> GetTopItemsByCollectionAsync(string collectionKey)
        {
            using var response = await _httpClient.GetAsync($"api/users/0/collections/{collectionKey}/items/top");
            response.EnsureSuccessStatusCode();
            return (await response.Content.ReadFromJsonAsync<List<ZoteroItem>>())!;
        }

        public async Task<IEnumerable<ZoteroItem>> GetChildrenByItemAsync(string itemKey)
        {
            using var response = await _httpClient.GetAsync($"api/users/0/items/{itemKey}/children");
            response.EnsureSuccessStatusCode();
            return (await response.Content.ReadFromJsonAsync <ZoteroItem[]>())!;
        } 

        public async Task<Dictionary<string, string>> GetItemTypesAsync()
        {
            using var response = await _httpClient.GetAsync($"api/itemTypes");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadFromJsonAsync<JsonElement>();
            return json.EnumerateArray()
                .ToDictionary(x => x.GetProperty("itemType").GetString()!, x => x.GetProperty("localized").GetString()!);
        }

        public async Task<Dictionary<string, string>> GetItemFieldsAsync()
        {
            using var response = await _httpClient.GetAsync($"api/itemFields");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadFromJsonAsync<JsonElement>();
            return json.EnumerateArray()
                .ToDictionary(x => x.GetProperty("field").GetString()!, x => x.GetProperty("localized").GetString()!);
        }

        public async Task<Dictionary<string, string>> GetItemTypeFieldsAsync(string itemType)
        {
            using var response = await _httpClient.GetAsync($"api/itemTypeFields?itemType={itemType}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadFromJsonAsync<JsonElement>();
            return json.EnumerateArray()
                .ToDictionary(x => x.GetProperty("field").GetString()!, x => x.GetProperty("localized").GetString()!);
        }

    }
}
