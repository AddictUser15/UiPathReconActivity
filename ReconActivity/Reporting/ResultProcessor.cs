using System;
using System.IO;
using System.Reflection;

namespace ReconActivity.Reporting
{
    class ResultProcessor
    {
        static ResultProcessor()
        {
            CompileTemplate("ResultReport");
        }

        private static void CompileTemplate(string name)
        {
            string template = LoadTemplate(typeof(ResultProcessor).Assembly,
                typeof(ResultProcessor).Namespace + ".ReportTemplates." + name + ".cshtml");
            using (var razor = new RazorSynchronizedServices())
            {
               razor.CompileWithAnonymous(template, name);
            }
        }

        private static string LoadTemplate(Assembly assembly, string address)
        {
            using (Stream stream = assembly.GetManifestResourceStream(address))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    stream.Position = 0;
                    return streamReader.ReadToEnd();
                }
            }

        }

        public static void CompleteDetailedReport(string outputPath)
        {
            using (var razor = new RazorSynchronizedServices())
            {
                File.WriteAllText(outputPath, razor.Run(TestXmlCompareHandler.Differences, "ResultReport"));
            }
        }
    }

}
