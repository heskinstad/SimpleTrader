﻿using Newtonsoft.Json;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModelingPrepAPI.Results;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI.Services {
    public class StockPriceService : IStockPriceService {
        public async Task<double> GetPrice(string symbol) {
            using (FinancialModelingPrepHttpClient client = new FinancialModelingPrepHttpClient()) {
                string uri = "stock/real-time-price/" + symbol;

                StockPriceResult stockPriceResult/* = await client.GetAsync<StockPriceResult>(uri)*/;

                // Data since API now requires a key :(
                string jsonResponse;
                if (symbol.Equals(".AAPL")) {
                    jsonResponse = "{\"symbol\" : \"AAPL\", \"price\" : 318.2}";
                }
                else {
                    jsonResponse = "{ }";
                }
                stockPriceResult = JsonConvert.DeserializeObject<StockPriceResult>(jsonResponse);

                if (stockPriceResult.Price == 0) {
                    throw new InvalidSymbolException(symbol);
                }

                return stockPriceResult.Price;
            }
        }
    }
}
