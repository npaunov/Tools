using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace CSVManager
{
    public static class CSVReader
    {      
        public static IEnumerable<string[]> GetData(string filepath, string delimiter)
        {
            List<string[]> myData = new List<string[]>();

            using (TextFieldParser parser = new TextFieldParser(filepath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(delimiter);
                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] fields = parser.ReadFields();
                    myData.Add(fields);
                }
            }

            return myData;
        }
    }
}
