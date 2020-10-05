using PdfSharp.Charting;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "InvDocument";
           var html = @"<h1>Hello World!</h1><br><p>This is IronPdf.</p>";

           for(int i=0; i<100; i++)
           {
                var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
                pdf.Save(Path.Combine(@"c:\projects\test\",filename + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".pdf"));
            }
                
            
            // turn html to pdf

            //using (var message = new MailMessage())
            //{
            //    message.To.Add(new MailAddress("prabhu.tvk@gmail.com", "Prabhu"));
            //    message.From = new MailAddress("localtesting@gmail.com", "Prabhu");
            //    message.Subject = "TestMessage";
            //    message.Body = "Body";
            //    message.IsBodyHtml = true;
            //    if (ms.Length > 0)
            //        message.Attachments.Add(new System.Net.Mail.Attachment(ms, "Invoice.pdf", "application/pdf"));

            //    using (var client = new SmtpClient("smtp.gmail.com"))
            //    {
            //        client.Port = 587;
            //        client.Credentials = new NetworkCredential("prabhu.tvk@gmail.com", "xxxx");
            //        client.EnableSsl = true;
            //        client.Send(message);
            //    }
            //}

        }
    }
}
