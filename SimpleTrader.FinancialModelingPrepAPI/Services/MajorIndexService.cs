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

                // Data since API now requires a key :(
                if (GetUriSuffix(indexType).Equals(".DJI")) {
                    jsonResponse = "{\"ticker\" : \".DJI\", \"changes\" : 18.9785, \"price\" : 27881.7, \"indexName\" : \"Dow Jones\"}";
                }
                if (GetUriSuffix(indexType).Equals(".IXIC")) {
                    jsonResponse = "{\"ticker\" : \".IXIC\", \"changes\" : 2.3246, \"price\" : 3516.0, \"indexName\" : \"Nasdaq\"}";
                }
                if (GetUriSuffix(indexType).Equals(".INX")) {
                    jsonResponse = "{\"ticker\" : \".INX\", \"changes\" : 7.3424, \"price\" : 9236.3, \"indexName\" : \"S&P 500\"}";
                }

                MajorIndex majorIndex = JsonConvert.DeserializeObject<MajorIndex>(jsonResponse);
                majorIndex.Type = indexType;

                return majorIndex;
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
