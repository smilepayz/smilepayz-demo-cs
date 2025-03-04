namespace indonesia.bean;

using System;

public class AreaEnum
{
    public static readonly AreaEnum INDONESIA = new AreaEnum(10, CurrencyEnum.IDR, 62);


    public int Code { get; }
    public CurrencyEnum Currency { get; }
    public int CountryId { get; }

    private AreaEnum(int code, CurrencyEnum currency, int countryId)
    {
        Code = code;
        Currency = currency;
        CountryId = countryId;
    }

    public static AreaEnum FromCode(int code)
    {
        switch (code)
        {
            case 10: return INDONESIA;
            default: throw new ArgumentException("Invalid code");
        }
    }
}