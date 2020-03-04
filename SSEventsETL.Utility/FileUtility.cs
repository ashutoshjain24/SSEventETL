using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;


namespace SSEventsETL.Utility
{
    public class FileUtility
    {
        public static void WriteToFile(string path, string text)
        {
            try
            {
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                    using (TextWriter tw = new StreamWriter(path))
                    {
                        tw.WriteLine(text);
                    }

                }
                else
                {
                    using (TextWriter tw = new StreamWriter(path))
                    {
                        tw.WriteLine(text);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static string ReadAllTextFromFile(string path)
        {
            string outValue = "";
            try
            {
                if (File.Exists(Environment.CurrentDirectory + path))
                {
                    if ((File.ReadAllText(Environment.CurrentDirectory + path).Trim()).Length>0)
                        outValue = File.ReadAllLines(Environment.CurrentDirectory + path)[0];

                    else
                        outValue = "0";
                }
                {
                    WriteToFile(Environment.CurrentDirectory + path, outValue);
                    outValue = File.ReadAllLines(Environment.CurrentDirectory + path)[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return outValue;
        }

        public static string  GetItFromAppConfig(string key)
        {
            return ConfigurationManager.AppSettings[key]; 
        }

        public static string GetNextStreamPosnFromFile()
        {
            return ReadAllTextFromFile(GetItFromAppConfig("NextStreamPositionFilePath"));
        }

        public static string GetSinceValueFromFile()
        {
            return ReadAllTextFromFile(GetItFromAppConfig("SinceFilePath"));
        }
    }
}
