//using PdfSharp.Charting;
//using PdfSharp.Pdf;
using PdfSharp.Pdf;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "InvDocument";
            var html = @"<h1>Hello World!</h1><br><p>This is IronPdf.</p>";

            StringBuilder sb1 = new StringBuilder();
            for (int i = 0; i < 100; i++)
            {
                sb1.Append(html + "\n");
            }

            long bytes1 = GC.GetTotalMemory(false);
            for (int i=0; i < 100; i++)
            {
                var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(sb1.ToString(), PdfSharp.PageSize.A4);
                pdf.Save(Path.Combine(@"c:\projects\test\", filename + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".pdf"));
            }

            long bytes2 = GC.GetTotalMemory(false);

            Console.WriteLine(bytes1);
            Console.WriteLine(bytes2);
            Console.WriteLine(bytes2 - bytes1);

            long bytes3 = GC.GetTotalMemory(false);

            var stopWatch = Stopwatch.StartNew();

            Parallel.For(0, 100, j =>
            {
                using(var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(sb1.ToString(), PdfSharp.PageSize.A4))
                {
                    pdf.Save(Path.Combine(@"c:\projects\test\", filename + Guid.NewGuid().ToString() + ".pdf"));
                }
          
            });

            long bytes4 = GC.GetTotalMemory(false);

            Console.WriteLine(bytes3);
            Console.WriteLine(bytes4);
            Console.WriteLine(bytes4 - bytes3);

            Console.WriteLine("Parallel.ForEach() execution time = {0} seconds", stopWatch.Elapsed.TotalSeconds);
            Console.Read();

            //var stopWatch = Stopwatch.StartNew();
            //PointF firstLocation = new PointF(10f, 10f);
            //PointF secondLocation = new PointF(10f, 50f);
            //Parallel.ForEach(Directory.GetFiles(@"c:\projects\test"), file =>
            //{
            //    Bitmap bitmap = (Bitmap)Image.FromFile(file);
            //    using (Graphics graphics = Graphics.FromImage(bitmap))
            //    {
            //        using (Font arialFont = new Font("Arial", 10))
            //        {
            //            graphics.DrawString("Banketeshvar", arialFont, Brushes.Blue, firstLocation);
            //            graphics.DrawString("Narayan", arialFont, Brushes.Red, secondLocation);
            //        }
            //    }
            //    bitmap.Save(Path.GetDirectoryName(file) + "Parallel" + "\\" + Path.GetFileNameWithoutExtension(file) + Guid.NewGuid()
            //        .ToString() + ".jpg");
            //});
            //Console.WriteLine("Parallel.ForEach() execution time = {0} seconds", stopWatch.Elapsed.TotalSeconds);
            //Console.Read();

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
