using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;
using System.Net;
using XmlComparer;
using ReconActivity.Reporting;
using System.IO;

namespace ReconActivity
{
    public class TestReconActivities : CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        public InArgument<string> SourceFile { get; set; }

        [Category("Input")]
        public InArgument<string> TargetFile { get; set; }
        [Category("Input")]
        public InArgument<string> MappingFile { get; set; }
        [Category("Input")]
        public InArgument<string> FileKey { get; set; }
        [Category("Input")]
        public InArgument<string> ResultPath { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            try
            {
                var file1 = SourceFile.Get(context);
                var file2 = TargetFile.Get(context);

                var handler = new TestXmlCompareHandler();

                using (var comparer = new Comparer(handler))
                {
                    comparer.Compare(file1, file2, handler);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            try
            {
                ResultProcessor.CompleteDetailedReport(ResultPath.Get(context));
            }
            catch (Exception ex)
            {
               throw;
            }
            
        }
    }
}
