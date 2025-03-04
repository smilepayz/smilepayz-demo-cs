// See https://aka.ms/new-console-template for more information


using brazil;

class BrazilApiDemo
{
    static async Task Main(string[] args)
    {
        string env = "";
        string merchantId = "";
        string merchantSecret = "";
        string privateKey = "";
        string paymentMethod = "";
        int amount = 100;
        string pixAccount = "";
        string taxNumber = "";
        string cashAccount = "";
        await PayInRequestDemo.PayInDemo(env, merchantId, merchantSecret, privateKey, paymentMethod, amount, pixAccount);
        await BalanceInquiryDemo.InquiryDemo(env, merchantId, merchantSecret, privateKey, "");
        await OrderStatusInquiryDemo.InquiryDemo(env, merchantId, merchantSecret, privateKey, "", "", 1);
        await PayOutRequestDemo.PayOutDemo(env, merchantId, merchantSecret, privateKey, paymentMethod, taxNumber, cashAccount, amount);
    }
}