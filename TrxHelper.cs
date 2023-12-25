using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.Xml.Linq;

namespace MsTestProject
{
    public class TrxHelper
    {
        public static void TrxToXml()
        {
            XDocument xml = XDocument.Load(@"C:\Users\Nares\Downloads\foo.trx");
            var TimeTagData = FetchAttributeDataFromNode(xml, "Times");
            var CountersTagData = FetchAttributeDataFromNode(xml, "Counters");
            var TestEntriesData = FetchAttributeDataFromNode(xml, "TestEntry");
            var TestOutputData = GetInnerNodeWithCondition(xml, TestEntriesData);


        }

        public static List<Dictionary<string, string>> GetInnerNodeWithCondition(XDocument xml, List<Dictionary<string, string>> dataNode)
        {
            var valuesDict = new List<Dictionary<string, string>>();
            foreach (var item in dataNode)
            {
                var testID = item["testId"];
                var dict = new Dictionary<string, string>();
                IEnumerable<XElement> ScenarioData = (from el in xml.Descendants()
                                                      where el.Name.LocalName == "UnitTestResult" &&
                                                      (string)el.Attribute("testId") == testID
                                                      select el).Descendants().Where(e => e.Name.LocalName == "StdOut");
                var data = FetchInnerXmlData(ScenarioData);
                dict.Add(testID, data);
                valuesDict.Add(dict);
            }
            return valuesDict;
        }

        public static string FetchInnerXmlData(IEnumerable<XElement> elemList)
        {
            var data = string.Empty;
            foreach (XElement node in elemList)
            {
                data = node.Value.ToString();
            }

            return data;
        }

        public static List<Dictionary<string, string>> FetchAttributeDataFromNode(XDocument document, string tageName)
        {
            var valuesDict = new List<Dictionary<string, string>>();
            var elementList = document.Descendants().Where(e => e.Name.LocalName == tageName);
            foreach (XElement node in elementList)
            {
                XElement elem = node as XElement;
                var datah = new Dictionary<string, string>();
                foreach (XAttribute attribute in elem.Attributes())
                {
                    datah.Add(attribute.Name.ToString(), attribute.Value);
                }

                valuesDict.Add(datah);
            }

            return valuesDict;
        }
    }
}
