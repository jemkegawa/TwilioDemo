using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Xml.Linq;
using Twilio.AspNet.Common;
using Twilio.AspNet.Mvc;
using Twilio.TwiML;
using WebAPI2Demo.TheBusiness;
using WebAPI2Demo.TheData;

namespace WebAPI2Demo.Controllers.v1
{
    [RoutePrefix("api/twilio/sms/v1")]
    public class V1TwilioSMSController : ApiController
    {
        [Route("test")]
        [HttpGet]
        /// A simple test endpoint to verify the API is working
        public IHttpActionResult GetTest()
        {
            return Ok("good!");
        }

        [Route("reply")]
        [HttpPost]
        public HttpResponseMessage TwilioSMS([FromBody]SmsRequest request)
        {
            var responseString = SMSParsing.ParseSmsMessage(request);
            
            if(string.IsNullOrEmpty(responseString))
            {
                //TODO: use TwiML Bin to send no response
                //Current code throws an error on Twilio's side - a response is required
                return null;
            }

            var response = new MessagingResponse();
            response.Message(responseString);

            return Request.CreateResponse(HttpStatusCode.OK, XElement.Parse(response.ToString()),
                new XmlMediaTypeFormatter());
        }

        private void SendMessage(SmsRequest request)
        {
            var toPhone = "0000000000";

            //example of sending an sms message directly (not as a response to a webhook, as above)
            var success = SMSHelper.SendSmsMessage(new List<string> { toPhone }, request.Body + "\nFrom: " + request.From);
        }
    }
}
