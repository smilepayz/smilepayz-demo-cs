// See https://aka.ms/new-console-template for more information

using india;

class IndiaDemo
{
    static async Task Main(string[] args)
    {
        string env = "";
        string merchantId = "";
        string merchantSecret = "";
        string privateKey = "";
        string paymentMethod = "";
        int amount = 100;
        string email = "";
        string ifsCode = "";
        string cashAccount = "";
        string accountNo = "";
        string tradeNo = "";
        string orderNo = "";
        int tradeType = 1;
        await BalanceInquiryDemo.InquiryDemo(env, merchantId, merchantSecret, privateKey, accountNo);
        await OrderStatusInquiryDemo.InquiryDemo(env, merchantId, merchantSecret, privateKey, tradeNo, orderNo,
            tradeType);
        await PayInRequestDemo.PayInDemo(env, merchantId, merchantSecret, privateKey, paymentMethod, amount,
            email);
        await PayOutRequestDemo.PayOutDemo(env, merchantId, merchantSecret, privateKey, paymentMethod, ifsCode,
            cashAccount, amount);
    }
}