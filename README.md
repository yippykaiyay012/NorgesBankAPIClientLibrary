# NorgesBankAPIClientLibrary


[![Nuget](https://img.shields.io/nuget/v/NorgesBankAPIClientLibrary)](https://www.nuget.org/packages/NorgesBankAPIClientLibrary//)


## Install

```bash
Install-Package NorgesBankAPIClientLibrary -Version 1.0.5
```


## Usage Examples

```csharp

    using(var client = new BankClient())
    {
        // Single Currency Value
        var result = await client.GetCurrencyValue(CurrencyTypes.GBP);          
    
        //List of Currency Values
        var results = await client.GetCurrencyValues(new List<CurrencyTypes>
        {
            CurrencyTypes.DKK,
            CurrencyTypes.EUR,
            CurrencyTypes.GBP,
            CurrencyTypes.IDR,
            CurrencyTypes.SEK,
            CurrencyTypes.SGD,
            CurrencyTypes.USD
        });
        
         foreach (var resultItem in results)
         {
            //Available properties
            Console.WriteLine($"Currency: {resultItem.Currency} \t " +
                                $"Observation: {resultItem.Value} \t " +
                                $"Multiplier: {resultItem.Multiplier} \t " +
                                $"Corrected Value: {resultItem.CorrectedValue} \t " +
                                $"Observation Date: {resultItem.ObservationDate.ToShortDateString()}");
         }
    }
            
```
