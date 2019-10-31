using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PivotGridCustomSummaryExample
{
    class TestData
    {
        public TestData(string name, DateTime date, decimal value, string type)
        {
            Name = name;
            Date = date;
            Value = value;
            Type = type;
        }

        public string Name { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public string Type { get; set; }


        public static List<TestData> GetData()
        {
            DateTime startDate = new DateTime(2019, 10, 15);
            List<TestData> dataList = new List<TestData>
            {
                new TestData("Aaa", startDate, 7, "Income"),
                new TestData("Aaa", startDate.AddDays(1), 4, "Outlay"),
                new TestData("Bbb", startDate, 12, "Outlay"),
                new TestData("Bbb", startDate.AddDays(1), 14, "Outlay"),
                new TestData("Ccc", startDate, 11, "Income"),
                new TestData("Ccc", startDate.AddDays(1), 10, "Income"),
                new TestData("Aaa", startDate.AddYears(1), 4, "Income"),
                new TestData("Aaa", startDate.AddYears(1).AddDays(1), 2, "Income"),
                new TestData("Bbb", startDate.AddYears(1), 3, "Income"),
                new TestData("Bbb", startDate.AddDays(1).AddYears(1), 1, "Outlay"),
                new TestData("Ccc", startDate.AddYears(1), 8, "Income"),
                new TestData("Ccc", startDate.AddDays(1).AddYears(1), 22, "Outlay")
            };
            return dataList;
        }
    }
}
