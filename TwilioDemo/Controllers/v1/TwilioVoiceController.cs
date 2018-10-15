using System.Collections.Generic;
using System.Web.Http;
using Twilio.AspNet.Common;
using WebAPI2Demo.TheBusiness;

namespace WebAPI2Demo.Controllers.v1
{
    [RoutePrefix("api/twilio/voice/v1")]
    public class V1TwilioVoiceController : ApiController
    {
        [Route("test")]
        [HttpGet]
        /// A simple test endpoint to verify the API is working
        public IHttpActionResult GetTest()
        {
            return Ok("good!");
        }

        [Route("send/{phoneNumber}")]
        [HttpGet]
        public IHttpActionResult TwilioVoice(string phoneNumber)
        {
            var helloXMLUrl = "http://dogfoodjs.azurewebsites.net/Voice-Hello.xml";
            var withAudioXMLUrl = "http://dogfoodjs.azurewebsites.net/Voice-WithAudio.xml";

            var toPhones = new List<string>{
                "0000000000"
            };

            toPhones.Add(phoneNumber);

            //send message to each phone in list
            foreach (var phone in toPhones)
            {
                VoiceHelper.SendVoiceMessage(phone, helloXMLUrl);
            }

            //API response
            return Ok("voice messages sent!");
        }
    }
}
