using Newtonsoft.Json;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI.Services {
    public class MajorIndexService : IMajorIndexService {
        public async Task<MajorIndex> GetMajorIndex(MajorIndexType indexType) {
            using (FinancialModelingPrepHttpClient client = new FinancialModelingPrepHttpClient()) {
                string uri = "majors-indexes/" + GetUriSuffix(indexType);

                MajorIndex majorIndex/* = await client.GetAsync<MajorIndex>(uri)*/;
                //majorIndex.Type = indexType;

                // Data since API now requires a key :(
                string jsonResponse;
                if (GetUriSuffix(indexType).Equals(".DJI")) {
                    jsonResponse = "{\"ticker\" : \".DJI\", \"changes\" : 18.9785, \"price\" : 27881.7, \"indexName\" : \"Dow Jones\"}";
                }
                else if (GetUriSuffix(indexType).Equals(".IXIC")) {
                    jsonResponse = "{\"ticker\" : \".IXIC\", \"changes\" : 2.3246, \"price\" : 3516.0, \"indexName\" : \"Nasdaq\"}";
                }
                else if (GetUriSuffix(indexType).Equals(".INX")) {
                    jsonResponse = "{\"ticker\" : \".INX\", \"changes\" : 7.3424, \"price\" : 9236.3, \"indexName\" : \"S&P 500\"}";
                }
                else {
                    jsonResponse = "{ }";
                }
                majorIndex = JsonConvert.DeserializeObject<MajorIndex>(jsonResponse);

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
                    throw new Exception("MajorIndexType does not have a suffix defined.");
            }
        }
    }
}
