using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace SendingEmailWithAmazonSES
{
    public partial class UsingSMTP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            var fromAddress = new MailAddress("SENDER@EXAMPLE.COM");
            var recipientAddress = new MailAddress("chien.vh@gmail.com");
            // sandbox, this address must be verified.

            string subject = "Amazon SES test (SMTP interface accessed using C#)";
            string body = "This email was sent through the <b>Amazon</b> SES SMTP interface by using C#.";

            // Supply your SMTP credentials below. Note that your SMTP credentials are different from your AWS credentials.
            string smtpUsername = "SMTP_USER";  // Replace with your SMTP username. 
            string smtpPassword = "SMTP_PW";  // Replace with your SMTP password.

            // Amazon SES SMTP host name. This example uses the US West (Oregon) region.
            string smtpHost = "email-smtp.us-west-2.amazonaws.com";

            // Port we will connect to on the Amazon SES SMTP endpoint. We are choosing port 587 because we will use
            // STARTTLS to encrypt the connection.
            const int smtpPort = 587;

            // Create an SMTP client with the specified host name and port.
            using (System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(smtpHost, smtpPort))
            {
                // Create a network credential with your SMTP user name and password.
                client.Credentials = new System.Net.NetworkCredential(smtpUsername, smtpPassword);

                // Use SSL when accessing Amazon SES. The SMTP session will begin on an unencrypted connection, and then 
                // the client will issue a STARTTLS command to upgrade to an encrypted connection using SSL.
                client.EnableSsl = true;

                var emailMessage = new System.Net.Mail.MailMessage(fromAddress, recipientAddress)
                {
                    IsBodyHtml = true,
                    Subject = subject,
                    Body = body,
                };

                // Send the email. 
                try
                {
                    client.Send(emailMessage);
                    Response.Write("Sent!");
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }
    }
}