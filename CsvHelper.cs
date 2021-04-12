using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CsvHelper
{
    public static class CsvHelper
    {
        public static void FindLongestCsvColumnData(string file)
        {
            var inputLines = File.ReadAllLines(file);
            Dictionary<int, int> dictIndexLenght = new Dictionary<int, int>();
            List<string> columnHeaders = inputLines.FirstOrDefault().Split(',').ToList();
            int maxColumn = 0;
            int maxRow = 0;
            string maxValue = "";
            int maxLength = 0;
            int lineCounter = 1;// Skips headers

            foreach (var line in inputLines)
            {
                lineCounter++;
                List<string> columList = line.Split(',').ToList();

                for (int i = 0; i < columList.Count; i++)
                {
                    int tempVal = 0;
                    if (dictIndexLenght.TryGetValue(i, out tempVal))
                    {
                        if (tempVal < columList[i].Length)
                        {
                            dictIndexLenght[i] = columList[i].Length;

                            if (maxLength < columList[i].Length)
                            {
                                maxLength = columList[i].Length;
                                maxColumn = i;
                                maxRow = lineCounter;
                                maxValue = columList[i];
                            }
                        }
                    }
                    else
                        dictIndexLenght[i] = columList[i].Length;
                }
            }

            for (int i = 0; i < dictIndexLenght.Count; i++)
            {
                Console.WriteLine("Column {0} : {1}", i, dictIndexLenght[i]);
            }

            Console.WriteLine($"MaxValue: {maxValue}, MaxRow:{maxRow}, MaxColumnName:{columnHeaders[maxColumn]}");
        }
    }
}
