using System;
using System.Net.Mail;

namespace TestSMTPClient
{
    class Program
    {
        static void Main(string[] args)
        {

//            try
//            {
//                SmtpClient client1 = new SmtpClient()
//                {
//                    DeliveryMethod = SmtpDeliveryMethod.Network,
//                    UseDefaultCredentials = false,
//                    EnableSsl = false,
//                    Host = "mail.ezesoft.net"
//                };

//                MailMessage msg1 = new MailMessage("tcheemakurthy@ezesoft.com",
//                    "tcheemakurthy@ezesoft.com,nahmad@ezesoft.com")
//                {
//                    Body = @"DeliveryMethod = SmtpDeliveryMethod.Network,
//                UseDefaultCredentials = false,
//                EnableSsl = false,
//                Host = ""mail.ezesoft.net""",
//                    Subject = "Client1"
//                };

//                client1.Send(msg1);
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//            }

            try
            {
                SmtpClient client2 = new SmtpClient()
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    Host = "mail.ezesoft.net",
                   // Port = 25
                    //Port = 587
                };

                MailMessage msg2 = new MailMessage("tcheemakurthy@ezesoft.com",
                    "tcheemakurthy@ezesoft.com,nahmad@ezesoft.com")
                {
                    Body = @"                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                Host = ""mail02.ezesoft.net"",
                Port = 25",
                    Subject = "Client2"
                };

                client2.Send(msg2);

                Console.WriteLine(client2.EnableSsl);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }
    }
}
