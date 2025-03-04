namespace thailand.bean;

using System;

public class AreaEnum
{
    public static readonly AreaEnum THAILAND = new AreaEnum(11, CurrencyEnum.THB, 66);

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
            case 11: return THAILAND;
            default: throw new ArgumentException("Invalid code");
        }
    }
}