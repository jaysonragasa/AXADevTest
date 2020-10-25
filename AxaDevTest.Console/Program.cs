using AXADevTest.APIClient;
using AXADevTest.APIClient.Interfaces;

using System;
using System.IO;
using System.Threading.Tasks;

namespace AxaDevTest.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleApp c = new ConsoleApp();
            var t = Task.Run(async () =>
            {
                System.Console.WriteLine("Uploading resume....");
                await c.UploadResume();
            });
            t.Wait();

            System.Console.WriteLine("done");
            System.Console.ReadLine();
        }
    }

    public class ConsoleApp
    {
        static IServicesLocator _locator;

        public async Task UploadResume()
        {
            _locator = new ServicesLocator();
            _locator.RegisterServices();

            var cvfile = "AJRCV_March112020.pdf";
            FileInfo fileInfo = new FileInfo(cvfile);

            if (fileInfo.Exists)
            {
                // submit to axa
                var response = await _locator.ResumeService.UploadResume(fileInfo.FullName);
                if(response.Result == System.Net.HttpStatusCode.OK)
                {
                    System.Console.WriteLine("file uploaded");

                    System.Console.WriteLine(response.Result.ToString());
                    System.Console.WriteLine(response.Message);
                }
                else
                {
                    System.Console.WriteLine(response.Result.ToString());
                    System.Console.WriteLine(response.Message);
                }
            }
        }
    }
}
