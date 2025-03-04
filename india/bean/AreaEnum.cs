namespace india.bean;

using System;

public class AreaEnum
{
    public static readonly AreaEnum INDIA = new AreaEnum(12, CurrencyEnum.INR, 91);

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
            case 12: return INDIA;
            default: throw new ArgumentException("Invalid code");
        }
    }
}