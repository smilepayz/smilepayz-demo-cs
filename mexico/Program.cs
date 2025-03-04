﻿// See https://aka.ms/new-console-template for more information


using mexico;

class IndonesiaDemo
{
    static async Task Main(string[] args)
    {
        string env = "";
        string merchantId = "";
        string merchantSecret = "";
        string privateKey = "";
        string paymentMethod = "";
        int amount = 100;
        await PayInRequestDemo.PayInDemo(env, merchantId, merchantSecret, privateKey, paymentMethod, amount);
        await BalanceInquiryDemo.InquiryDemo(env, merchantId, merchantSecret, privateKey, "");
        await OrderStatusInquiryDemo.InquiryDemo(env, merchantId, merchantSecret, privateKey, "", "", 1);
        await PayOutRequestDemo.PayOutDemo(env, merchantId, merchantSecret, privateKey, paymentMethod, "", amount);
    }
}