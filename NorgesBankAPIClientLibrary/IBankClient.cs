using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorgesBankAPIClientLibrary
{
    public interface IBankClient
    {
        void Dispose();
        Task<CurrencyValue> GetCurrencyValue(CurrencyTypes currency);
        Task<List<CurrencyValue>> GetCurrencyValues(List<CurrencyTypes> currencies);
    }
}