using System.Text;
using vietanm.bean;
namespace vietanm;

public class OrderStatusInquiryDemo
{
    public static async Task InquiryDemo(string env, string merchantId, string merchantSecret, string privateKey,
        string tradeNo, string orderNo, int tradeType)
    {
        // sandbox 
        string requestPath = Constant.baseUrlSanbox + "/v2.0/inquiry-status";
        if (env.Equals("production"))
        {
            requestPath = Constant.baseUrl + "/v2.0/inquiry-balance";
        }

        DateTime date = DateTime.Now;
        string timestamp = date.ToString("yyyy-MM-dd'T'HH:mm:sszzz");
        Console.WriteLine("timestamp:" + timestamp);

        OrderStatusInquiryRequest inquiryRequest = new OrderStatusInquiryRequest();
        inquiryRequest.tradeType = tradeType;
        inquiryRequest.tradeNo = tradeNo;
        inquiryRequest.orderNo = orderNo;

        // minify data
        string minify = Newtonsoft.Json.JsonConvert.SerializeObject(inquiryRequest);
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

            //send post request
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