// See https://aka.ms/new-console-template for more information


using peru;
using peru.bean;

class ColombiaDemo
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
        string cashAccount = "";
        string cashAccountType = "CORRIENTE";
        string accountNo = "";
        string tradeNo = "";
        string orderNo = "";
        int tradeType = 1;

        
        await BalanceInquiryDemo.InquiryDemo(env, merchantId, merchantSecret, privateKey, accountNo);
        await OrderStatusInquiryDemo.InquiryDemo(env, merchantId, merchantSecret, privateKey, tradeNo, orderNo,
            tradeType);
        await PayInRequestDemo.PayInDemo(env, merchantId, merchantSecret, privateKey, paymentMethod, amount,
            email);
        
        ReceiverRequest receiverReq = new ReceiverRequest();
        receiverReq.identity = "123456";
        receiverReq.idType="DNI";
        receiverReq.email=("etets@gamil.com");
        receiverReq.phone=("123232323");
        receiverReq.name=("testName");
        await PayOutRequestDemo.PayOutDemo(env, merchantId, merchantSecret, privateKey, paymentMethod,
            cashAccount, cashAccountType,amount,receiverReq);
    }
}


