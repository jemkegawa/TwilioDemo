using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace WebAPI2Demo.TheBusiness
{
    public class VoiceHelper
    {
        public static bool SendVoiceMessage(string toPhone, string xmlUrl)
        {
            try
            {
                const string accountSid = "clientId";
                const string authToken = "clientSecret";
                TwilioClient.Init(accountSid, authToken);

                var to = new PhoneNumber($"+1{toPhone}");
                //from phone must be a Twilio phone number
                var from = new PhoneNumber("+10000000000");
                var call = CallResource.Create(to, from,
                    url: new Uri(xmlUrl));
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
