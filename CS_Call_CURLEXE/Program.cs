using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace CS_Call_CURLEXE
{
    //資料來源: https://stackoverflow.com/questions/9718375/how-to-retrieve-data-from-curl-exe
    //資料來源: https://stackoverflow.com/questions/7172784/how-to-post-json-data-with-curl-from-terminal-commandline-to-test-spring-rest
    //curl -H "Content-Type: application/json" -X POST -d '{"username":"xyz","password":"xyz"}' http://localhost:3000/api/login
    class Program
    {
        static void pause()
        {
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
        static void Main(string[] args)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "curl.exe";  // Specify exe name.
            start.Arguments = "-k https://www.moi.gov.tw/";
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;

            // Start the process.
            using (Process p = Process.Start(start))
            {
                // Read in all the text from the process with the StreamReader
                using (StreamReader reader = p.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.Write(result);
                    StreamWriter sw = new StreamWriter("data.txt");
                    sw.WriteLine(result);// 寫入文字
                    sw.Close();// 關閉串流
                }
            }
            pause();
        }
    }
}
