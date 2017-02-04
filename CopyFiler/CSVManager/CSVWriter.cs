using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSVManager
{
    public static class CSVWriter
    {
        public static void WriteText(string text, string path, string delimiter)
        {
            List<string[]> tempList = new List<string[]>();
            string[] tempArr = new string[1] {text};
            tempList.Add(tempArr);

            WriteData(tempList, path, delimiter);

        }
        public static void WriteData(IEnumerable<string[]> data, string filePath, string delimiter)
        {
            IEnumerable<string[]> oldData = CSVReader.GetData(filePath, delimiter);
            StringBuilder sb = new StringBuilder();

            //check if file is empty
            if (!oldData.Any())
            {
                int index = 1;
                foreach (var items in data)
                {
                    sb.AppendLine(string.Format("{0}{1}{2}",
                        index.ToString(), delimiter, string.Join(delimiter, items)));

                    index++;
                }
            }
            else
            {
                //if file is not empty add the old data files
                foreach (var oldItem in oldData)
                {
                    sb.AppendLine(string.Join(delimiter, oldItem));
                }

                int index = int.Parse(oldData.Last().ToArray()[0]);

                foreach (var items in data)
                {
                    index++;
                    sb.AppendLine(string.Format("{0}{1}{2}",
                        index.ToString(), delimiter, string.Join(delimiter, items)));
                }
            }

            File.WriteAllText(filePath, sb.ToString());
        }
    }
}
