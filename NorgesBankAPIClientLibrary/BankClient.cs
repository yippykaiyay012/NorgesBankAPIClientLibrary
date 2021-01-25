using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NorgesBankAPIClientLibrary
{
    public class BankClient : IDisposable, IBankClient
    {
        private HttpClient _client;
        public BankClient()
        {
            _client = new HttpClient { BaseAddress = new Uri("https://data.norges-bank.no") };
        }

        private string BuildURL(List<CurrencyTypes> currencies)
        {
            var url = new StringBuilder();
            url.Append("/api/data/EXR/B.");

            bool isFirstCurrency = true;
            foreach (var currency in currencies)
            {
                if (isFirstCurrency)
                {
                    url.Append($"{currency}");
                    isFirstCurrency = false;
                }
                else
                {
                    url.Append($"+{currency}");
                }
            }
            url.Append(".NOK.SP?format=sdmx-json&lastNObservations=1&locale=en");

            return url.ToString();
        }


        public async Task<CurrencyValue> GetCurrencyValue(CurrencyTypes currency)
        {
            var currencyAsList = new List<CurrencyTypes> { currency };

            var jsonString = await _client.GetStringAsync(BuildURL(currencyAsList));

            var rootObject = JsonConvert.DeserializeObject<BankResult>(jsonString);

            var value = rootObject.data.dataSets[0].series._0000.observations._0[0];
            var decimalValue = decimal.Parse(value);

            var multiplier = rootObject.data.structure.attributes.series[2].values[0].name;
            int multiplierInt;
            int.TryParse(rootObject.data.structure.attributes.series[2].values[0].id,  out multiplierInt);

            var correctedValue = decimalValue / (decimal)Math.Pow(10, multiplierInt);

            DateTime observationDate;
            DateTime.TryParse(rootObject.data.structure.dimensions.observation[0].values[0].name, out observationDate);

            var returnValue = new CurrencyValue { Currency = currency, Value = decimalValue, Multiplier = multiplier , CorrectedValue = correctedValue,  ObservationDate = observationDate };

            return returnValue;
        }

        public async Task<List<CurrencyValue>> GetCurrencyValues(List<CurrencyTypes> currencies)
        {
            var currencyValues = new List<CurrencyValue>();

            foreach (var currency in currencies)
            {
                currencyValues.Add(await GetCurrencyValue(currency));
            }

            return currencyValues;

        }

        public void Dispose()
        {
            _client.Dispose();
        }

    }
}
