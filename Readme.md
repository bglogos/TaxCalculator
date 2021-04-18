# Tax Calculator

## How to use

Use the following syntax in the console:

```
TaxCalculator.Cli.exe [option] [value]
```

Available options:

|Long syntax                |Short syntax       |Description|
|---------------------------|-------------------|-----------|
|--help                     |-h                 |Show help information.|
|--gross \<amount\>         |-g \<amount\>      |Enter the gross salary amount.|
|--currency \<currencyCode\>|-c \<currencyCode\>|Enter the currency. If no currency is provided the default IDR will be used.|
---
### Examples
Calculate the net amount from 1000 IDR:
```
TaxCalculator.Cli.exe -g 1000
```

Calculate the net amount from 3000 USD:
```
TaxCalculator.Cli.exe -g 1000 -c USD
```