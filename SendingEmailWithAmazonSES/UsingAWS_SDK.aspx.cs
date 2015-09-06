using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Amazon;
using Amazon.Runtime;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace SendingEmailWithAmazonSES
{
    public partial class UsingAWS_SDK : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string fromAddress = "SENDER@EXAMPLE.COM";  // Replace with your "From" address. This address must be verified.
            string recipientAddress = "chien.vh@gmail.com"; // Replace with a "To" address. If your account is still in the
            string subject = "Test sending email using AWS SDK with C#";
            string body = "This is the email content!";

            AWSCredentials credentials = new BasicAWSCredentials("YOUR_ACCESS_KEY", "YOUR_SECRET_KEY");

            using (var client = AWSClientFactory.CreateAmazonSimpleEmailServiceClient(credentials, RegionEndpoint.USEast1))
            {
                var request = new SendEmailRequest
                {
                    Source = fromAddress,
                    Destination = new Destination { ToAddresses = new List<string> { recipientAddress } },
                    Message = new Message
                    {
                        Subject = new Amazon.SimpleEmail.Model.Content(subject),
                        Body = new Body { Text = new Amazon.SimpleEmail.Model.Content(body) }
                    }
                };

                try
                {
                    // Send the email. 
                    var response = client.SendEmail(request);
                    Response.Write("Email sent!");
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }
    }
}