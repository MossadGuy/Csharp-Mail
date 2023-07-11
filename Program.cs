using System;
using System.Net;
using System.Net.Mail;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gönderici e-posta adresini girin: ");
            string gonderEmail = Console.ReadLine();

            Console.WriteLine("Gönderici parolasını girin: ");
            string gonderSifre = Console.ReadLine();

            Console.WriteLine("Alıcı e-posta adresini girin: ");
            string aliciEmail = Console.ReadLine();

            Console.WriteLine("E-posta konusunu girin: ");
            string Konu = Console.ReadLine();

            Console.WriteLine("E-posta içeriğini girin: ");
            string metin = Console.ReadLine();

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(gonderEmail, gonderSifre);

            MailMessage mailMessage = new MailMessage(gonderEmail, aliciEmail, Konu, metin);
            mailMessage.IsBodyHtml = true;

            try
            {
                smtpClient.Send(mailMessage);
                Console.WriteLine("E-posta gönderildi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("E-posta gönderilirken hata oluştu: " + ex.Message);
            }
        }
    }
}
