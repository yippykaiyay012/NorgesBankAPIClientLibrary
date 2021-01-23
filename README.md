# NorgesBankAPIClientLibrary





## Install

```bash
Install-Package NorgesBankAPIClientLibrary -Version 1.0.1
```


## Usage Examples

```csharp

    using(var client = new BankClient())
    {
        // Single Currency Value
        var result = await client.GetCurrencyValue(CurrencyTypes.GBP);
        Console.WriteLine($"{result.Currency} {result.Value}");           
    
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
    }
            
```
