using System;
using System.Threading;
using System.Net.Mail;

/// <summary>
/// Email Library Class
/// </summary>
namespace Saython.Library
{
    public class Email
    {
        public Email()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void SendMailText(string smtpServer, int smtpPort, string pFrom, string pTo, string pCC, string pSubject, string pBody, bool isAsync = false)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
                smtpClient.EnableSsl = false;
                MailMessage mailMessage = new MailMessage(pFrom, pTo, pSubject, pBody);


                if (pCC.Trim() != "")
                {
                    MailAddress ccAddress = new MailAddress(pCC);
                    mailMessage.CC.Add(ccAddress);
                }
                if (isAsync)
                {
                    Thread emailThread = new Thread(delegate ()
                    {
                        try
                        {
                            smtpClient.Send(mailMessage);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(DateTime.Now.ToString() + " | ERROR | " + ex.Message);
                        }
                    });

                    emailThread.IsBackground = true;
                    emailThread.Start();
                }
                else
                {
                    smtpClient.Send(mailMessage);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now.ToString() + " | ERROR | " + ex.Message);
            }
        }
    }
}
