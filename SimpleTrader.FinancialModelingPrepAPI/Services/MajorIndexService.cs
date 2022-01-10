using Newtonsoft.Json;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI.Services {
    public class MajorIndexService : IMajorIndexService {
        public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType) {
            using (HttpClient client = new HttpClient()) {
                string uri = "https://financialmodelingprep.com//api/v3/majors-indexes/" + GetUriSuffix(indexType);

                HttpResponseMessage response = await client.GetAsync(uri);
                string jsonResponse = await response.Content.ReadAsStringAsync();

                MajorIndex majorIndex = JsonConvert.DeserializeObject<MajorIndex>(jsonResponse);
                majorIndex.Type = indexType;

                //return majorIndex;

                // Test data
                MajorIndex testIndex = new MajorIndex();
                testIndex.Type = MajorIndexType.DowJones;
                testIndex.Price = 10.20;
                testIndex.Changes = 3.42;
                testIndex.Type = indexType;
                return testIndex;
            }
        }

        private string GetUriSuffix(MajorIndexType indexType) {
            switch(indexType) {
                case MajorIndexType.DowJones:
                    return ".DJI";
                case MajorIndexType.Nasdaq:
                    return ".IXIC";
                case MajorIndexType.SP500:
                    return ".INX";
                default:
                    return ".DJI";
            }
        }
    }
}
