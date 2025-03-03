﻿using System.Text;
using indonesia.bean;
namespace indonesia;

public class BalanceInquiryDemo
{
     public static async Task InquiryDemo(string env,string merchantId,string merchantSecret,string privateKey,string accountNo)
    {
        // sandbox 
        string requestPath =Constant.baseUrlSanbox + "/v2.0/inquiry-balance";
        if (env.Equals("production"))
        {
            requestPath =Constant.baseUrl + "/v2.0/inquiry-balance";
        }
        
        DateTime date = DateTime.Now;
        string timestamp = date.ToString("yyyy-MM-dd'T'HH:mm:sszzz");
        Console.WriteLine("timestamp:" + timestamp);

        BalanceInquiryRequest balanceInquiryRequest = new BalanceInquiryRequest();
        balanceInquiryRequest.accountNo = accountNo;
        balanceInquiryRequest.balanceTypes = ["BALANCE"];
        
        // minify data
        string  minify = Newtonsoft.Json.JsonConvert.SerializeObject(balanceInquiryRequest);
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
            Console.WriteLine("requestPath:" + requestPath);

            // send request 
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
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Response Body:");
                Console.WriteLine(responseBody);
            }
        }
    }
}