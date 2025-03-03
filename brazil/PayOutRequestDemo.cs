
using System.Text;

using brazil.bean;
namespace brazil;

public class PayOutRequestDemo
{
    public static async Task PayOutDemo(string env, string merchantId, string merchantSecret, string privateKey,
        string paymentMethod, string taxNumber, string cashAccount, int amount)
    {
        // sandbox 
        string requestPath = Constant.baseUrlSanbox + "/v2.0/disbursement/pay-out";
        if (env.Equals("production"))
        {
            requestPath = Constant.baseUrl + "/v2.0/disbursement/pay-out";
        }


        string orderNo = merchantId.Replace("sandbox-", "S") + Guid.NewGuid().ToString("N");


        DateTime date = DateTime.Now;
        string timestamp = date.ToString("yyyy-MM-dd'T'HH:mm:sszzz");
        Console.WriteLine("timestamp:" + timestamp);

        MoneyRequest moneyRequest = new MoneyRequest();
        moneyRequest.amount = amount;
        moneyRequest.currency = CurrencyEnum.BRL.ToString();

        MerchantRequest merchantRequest = new MerchantRequest();
        merchantRequest.merchantId = merchantId;

        ReceiverRequest receiver = new ReceiverRequest();
        receiver.taxNumber = taxNumber;

        TradePayOutRequest payOutRequest = new TradePayOutRequest();
        payOutRequest.receiver = receiver;
        payOutRequest.cashAccount = cashAccount;
        payOutRequest.merchant = merchantRequest;
        payOutRequest.money = moneyRequest;
        payOutRequest.paymentMethod = paymentMethod;
        payOutRequest.area = AreaEnum.BRAZIL.Code;
        payOutRequest.purpose = "for test";
        payOutRequest.orderNo = orderNo.Substring(0, 32);

        // minify data 
        string minify = Newtonsoft.Json.JsonConvert.SerializeObject(payOutRequest);
        Console.WriteLine("minify:" + minify);

        string signContent = $"{timestamp}|{merchantSecret}|{minify}";
        Console.WriteLine("request path:" + requestPath);

        var signature = SignatureUtils.sha256RsaSignature(signContent, privateKey);
        using (HttpClient client = new HttpClient())
        {
            // request headers 
            client.DefaultRequestHeaders.Add("ContentType", "application/json");
            client.DefaultRequestHeaders.Add("X-TIMESTAMP", timestamp);
            client.DefaultRequestHeaders.Add("X-SIGNATURE", signature);
            client.DefaultRequestHeaders.Add("X-PARTNER-ID", merchantId);
            StringContent content = new StringContent(minify, Encoding.UTF8, "application/json");

            Console.WriteLine("content:" + Newtonsoft.Json.JsonConvert.SerializeObject(content));

            // request post
            HttpResponseMessage response =
                await client.PostAsync(requestPath, content);

            // is success ?
            if (response.IsSuccessStatusCode)
            {
                // read response body 
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Response Body:");
                Console.WriteLine(responseBody);
            }
            else
            {
                // read response body 
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Response Body:");
                Console.WriteLine(responseBody);
            }
        }
    }
}