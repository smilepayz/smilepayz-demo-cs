using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using indonesia.bean;
namespace indonesia;


public class PayInRequestDemo
{
    public static async Task PayInDemo(string env, string merchantId, string merchantSecret, string privateKey,
        string paymentMethod, int amount, string ovoAccount)
    {
        // sandbox 
        string requestPath = Constant.baseUrlSanbox + "/v2.0/transaction/pay-in";
        if (env.Equals("production"))
        {
            requestPath = Constant.baseUrl + "/v2.0/transaction/pay-in";
        }


        DateTime date = DateTime.Now;
        string timestamp = date.ToString("yyyy-MM-dd'T'HH:mm:sszzz");
        Console.WriteLine("timestamp:" + timestamp);

        string orderNo = merchantId.Replace("sandbox-", "S") + Guid.NewGuid().ToString("N");

        MoneyRequest moneyRequest = new MoneyRequest();
        moneyRequest.amount = amount;
        moneyRequest.currency = CurrencyEnum.IDR.ToString();

        PayerRequest payer = new PayerRequest();
        payer.phone = ovoAccount;

        MerchantRequest merchantRequest = new MerchantRequest();
        merchantRequest.merchantId = merchantId;

        PayInRequest payInRequest = new PayInRequest();
        payInRequest.merchant = merchantRequest;
        payInRequest.money = moneyRequest;
        payInRequest.paymentMethod = paymentMethod;
        payInRequest.area = AreaEnum.INDONESIA.Code;
        payInRequest.purpose = "for test";
        payInRequest.payer = payer;
        payInRequest.orderNo = orderNo.Substring(0, 32);

        Console.WriteLine("request path:" + requestPath);

        // minifi data
        string minify = Newtonsoft.Json.JsonConvert.SerializeObject(payInRequest);
        Console.WriteLine("minify:" + minify);

        string signContent = $"{timestamp}|{merchantSecret}|{minify}";

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

            // post request 
            HttpResponseMessage response =
                await client.PostAsync(requestPath, content);

            //  is success code ?
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