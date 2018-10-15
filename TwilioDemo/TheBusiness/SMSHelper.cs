using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace WebAPI2Demo.TheBusiness
{
    public class SMSHelper
    {
        public static bool SendSmsMessage(List<string> phones, string message)
        {
            var ownedPhones = new List<string>();
            ownedPhones.Add("+10000000000");
            int phoneI = 0;

            try
            {
                TwilioClient.Init("clientSecret", "clientSecret");

                //send messages to all phones
                foreach (string phone in phones)
                {
                    //from phone must be a Twilio phone number
                    var tMessage = MessageResource.Create(
                        new PhoneNumber("+" + phone),
                        from: new PhoneNumber(ownedPhones[phoneI]),
                        body: message
                    );
                    
                    //increment to next owned phone
                    phoneI++;
                    if (phoneI > ownedPhones.Count - 1)
                        phoneI = 0;
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}