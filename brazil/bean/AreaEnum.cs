namespace brazil.bean;
using System;
public class AreaEnum
{
    public static readonly AreaEnum BRAZIL = new AreaEnum(13, CurrencyEnum.BRL, 55);

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
            case 13: return BRAZIL;
            default: throw new ArgumentException("Invalid code");
        }
    }
}