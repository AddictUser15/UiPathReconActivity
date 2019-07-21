using System;
using System.Collections.Generic;
using XmlComparer;

namespace ReconActivity
{
    public class TestXmlCompareHandler : IXmlCompareHandler
    {
        public static List<ReportData> Differences = new List<ReportData>();

        public void ElementAdded(ElementAddedEventArgs e)
        {
            Console.WriteLine("++E: {0,-8}: {1}", e.LineNumber, e.XPath);
            Console.WriteLine("   : {0}", e.Element);
            Console.WriteLine();
            Differences.Add(new ReportData()
            {
                DifferenceType = DifferenceType.ElementAdded,
                Xpath = e.XPath,
                RightLineNumber = e.LineNumber,
                NewValue = e.Element.Value
            });
        }

        public void ElementRemoved(ElementRemovedEventArgs e)
        {
            Console.WriteLine("--E: {0,-8}: {1}", e.LineNumber, e.XPath);
            Console.WriteLine("   : {0}", e.Element);
            Console.WriteLine();
            Differences.Add(new ReportData()
            {
                DifferenceType = DifferenceType.ElementMissing,
                Xpath = e.XPath,
                LeftLineNumber = e.LineNumber,
                OldValue = e.Element.Value
            });
        }

        public void ElementChanged(ElementChangedEventArgs e)
        {
            Console.WriteLine("<>E: {0}", e.XPath);
            Console.WriteLine("  o: {0,-8}: {1}", e.LeftLineNumber, e.LeftElement.Value);
            Console.WriteLine("  n: {0,-8}: {1}", e.RightLineNumber, e.RightElement.Value);
            Console.WriteLine();
            Differences.Add(new ReportData()
            {
                DifferenceType = DifferenceType.ElementChange,
                Xpath = e.XPath,
                LeftLineNumber = e.LeftLineNumber,
                RightLineNumber = e.RightLineNumber,
                OldValue = e.LeftElement.Value,
                NewValue = e.RightElement.Value
            });
        }

        public void AttributeAdded(AttributeAddedEventArgs e)
        {
            Console.WriteLine("++A: {0,-8}: {1}", e.LineNumber, e.XPath);
            Console.WriteLine("   : {0}", e.Attribute.Value);
            Console.WriteLine();
            Differences.Add(new ReportData()
            {
                DifferenceType = DifferenceType.AttributeAdded,
                Xpath = e.XPath,
                RightLineNumber = e.LineNumber,
                NewValue = e.Attribute.Value
            });
        }

        public void AttributeRemoved(AttributeRemovedEventArgs e)
        {
            Console.WriteLine("--A: {0,-8}: {1}", e.LineNumber, e.XPath);
            Console.WriteLine("   : {0}", e.Attribute.Value);
            Console.WriteLine();
            Differences.Add(new ReportData()
            {
                DifferenceType = DifferenceType.AttributeMissing,
                Xpath = e.XPath,
                LeftLineNumber = e.LineNumber,
                OldValue = e.Attribute.Value
            });
        }

        public void AttributeChanged(AttributeChangedEventArgs e)
        {
            Console.WriteLine("<>A: {0}", e.XPath);
            Console.WriteLine("  o: {0,-8}: {1}", e.LeftLineNumber, e.LeftAttribute.Value);
            Console.WriteLine("  n: {0,-8}: {1}", e.RightLineNumber, e.RightAttribute.Value);
            Console.WriteLine();
            Differences.Add(new ReportData()
            {
                DifferenceType = DifferenceType.AttributeChange,
                Xpath = e.XPath,
                LeftLineNumber = e.LeftLineNumber,
                RightLineNumber = e.RightLineNumber,
                OldValue = e.LeftAttribute.Value,
                NewValue = e.RightAttribute.Value
            });
        }

    }
}
