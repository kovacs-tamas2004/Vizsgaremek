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
    public class VisitorService : BaseService<Visitor, VisitorDto>, IVisitorService
    {
        public VisitorService(IHttpClientFactory? httpClientFactory, VisitorAssambler visitorAssambler) : base(httpClientFactory, visitorAssambler)
        {

        }

        public async Task<List<Visitor>> SearchAndFilterVisitorsAsync(VisitorQueryParameters visitorQueryParameters)
        {
            if (_httpClient is not null)
            {
                HttpResponseMessage? httpResponse = null;
                try
                {
                    httpResponse = await _httpClient.PostAsJsonAsync("api/Visitor/queryparameters", visitorQueryParameters.ToDto());
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        List<VisitorDto>? visitors = JsonConvert.DeserializeObject<List<VisitorDto>>(content);
                        if (visitors is not null)
                        {
                            return visitors.Select(visitorDto => visitorDto.ToModel()).ToList();
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
            return new List<Visitor>();
        }
    }
}
