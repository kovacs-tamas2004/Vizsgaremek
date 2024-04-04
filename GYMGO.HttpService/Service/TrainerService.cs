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
    public class TrainerService : BaseService<Trainer, TrainerDto>, ITrainerService
    {
        public TrainerService(IHttpClientFactory? httpClientFactory, TrainerAssambler trainerAssambler) : base(httpClientFactory, trainerAssambler)
        {

        }

        public async Task<List<Trainer>> SearchAndFilterTrainersAsync(TrainerQueryParameters trainerQueryParameters)
        {
            if (_httpClient is not null)
            {
                HttpResponseMessage? httpResponse = null;
                try
                {
                    httpResponse = await _httpClient.PostAsJsonAsync("api/Trainer/queryparameters", trainerQueryParameters.ToDto());
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        string content = await httpResponse.Content.ReadAsStringAsync();
                        List<TrainerDto>? trainers = JsonConvert.DeserializeObject<List<TrainerDto>>(content);
                        if (trainers is not null)
                        {
                            return trainers.Select(trainerDto => trainerDto.ToModel()).ToList();
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
            return new List<Trainer>();
        }
    }
}
