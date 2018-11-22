using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using paytm;

namespace PaytmCheckSum.Controller
{
    public class CheckSumController : ApiController
    {
        public string Post([FromBody]Parameters pt)
         {
            //var ppt = pt.MID;
            Dictionary<String, String> paytmParams = new Dictionary<string, string>();
            String merchantKey = "";
            if(pt != null){
                paytmParams.Add("MID", pt.MID);
                paytmParams.Add("CHANNEL_ID",pt.CHANNEL_ID );
                paytmParams.Add("WEBSITE", pt.WEBSITE);
                paytmParams.Add("CALLBACK_URL", pt.CALLBACK_URL);
                paytmParams.Add("CUST_ID", pt.CUST_ID);
                paytmParams.Add("MOBILE_NO",pt.MOBILE_NO );
                paytmParams.Add("EMAIL", pt.EMAIL);
                paytmParams.Add("ORDER_ID", pt.ORDER_ID);
                paytmParams.Add("INDUSTRY_TYPE_ID", pt.INDUSTRY_TYPE_ID);
                paytmParams.Add("TXN_AMOUNT", pt.TXN_AMOUNT );
                merchantKey = pt.merchantKey;
            }
            string checkSumKey = paytm.CheckSum.generateCheckSum(merchantKey, paytmParams);
            return checkSumKey;
         }
        public string Get()
        {
            return "mudff";
        }
    }
}
