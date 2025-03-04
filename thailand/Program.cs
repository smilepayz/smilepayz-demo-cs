// See https://aka.ms/new-console-template for more information

using thailand;

class ThailandDemo
{
    static async Task Main(string[] args)
    {
        string env = "";
        string merchantId = "";
        string merchantSecret = "";
        string privateKey = "";
        string paymentMethod = "";
        int amount = 100;
        string cashAccount = "";
        string accountNo = "";
        string tradeNo = "";
        string orderNo = "";
        int tradeType = 1;
        string payerName = "";
        string payerAccount = "";
        string payerBank = "";
        await PayInRequestDemo.PayInDemo(env, merchantId, merchantSecret, privateKey, paymentMethod, amount,
            payerAccount, payerBank, payerName);
        await BalanceInquiryDemo.InquiryDemo(env, merchantId, merchantSecret, privateKey, accountNo);
        await OrderStatusInquiryDemo.InquiryDemo(env, merchantId, merchantSecret, privateKey, tradeNo, orderNo,
            tradeType);
        await PayOutRequestDemo.PayOutDemo(env, merchantId, merchantSecret, privateKey, paymentMethod, cashAccount,
            amount);
    }
}