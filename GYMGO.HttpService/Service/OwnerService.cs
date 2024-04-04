using GYMGO.Shared.Assamblers;
using GYMGO.Shared.Models;
using GYMGO.Shared.Dtos;
using System.Diagnostics;
using System.Net.Http.Json;
using Newtonsoft.Json;
using GYMGO.Shared.Extensions;
using GYMGO.Shared.Parameters;

namespace GYMGO.HttpService.Service
{
    public class OwnerService : BaseService<Owner, OwnerDto>, IOwnerService
    {
        public OwnerService(IHttpClientFactory? httpClientFactory, OwnerAssambler ownerAssambler) : base(httpClientFactory, ownerAssambler)
        {

        }

        public async Task<List<Owner>> SearchAndFilterOwnersAsync(OwnerQueryParameters ownerQueryParameters)
        {
            if (_httpClient is not null)
            {
                HttpResponseMessage? httpResponse = null;
                try
                {
                    httpResponse = await _httpClient.PostAsJsonAsync("api/Owner/queryparameters", ownerQueryParameters.ToDto());
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        List<OwnerDto>? owners = JsonConvert.DeserializeObject<List<OwnerDto>>(content);
                        if (owners is not null)
                        {
                            return owners.Select(ownerDto => ownerDto.ToModel()).ToList();
                        }
                    }
                    else if (!httpResponse.IsSuccessStatusCode)
                    {
                        httpResponse.EnsureSuccessStatusCode();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
            return new List<Owner>();
        }
    }
}
