using System;
using System.Collections.Generic;

namespace Smarest.ViewModel
{
    public class OrderStatistics
    {
        // Daily statistics for orders
        public List<DailyStatistics> DailyStatistics { get; set; }

        // Monthly statistics for orders
        public List<MonthlyStatistics> MonthlyStatistics { get; set; }

        // Yearly statistics for orders
        public List<YearlyStatistics> YearlyStatistics { get; set; }
    }
    public class DailyStatistics
    {
        public DateTime Date { get; set; }
        public int TotalOrders { get; set; }
        public double TotalSales { get; set; }
        public double AverageOrderValue { get; set; }
    }

    public class MonthlyStatistics
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int TotalOrders { get; set; }
        public double TotalSales { get; set; }
        public double AverageOrderValue { get; set; }
    }

    public class YearlyStatistics
    {
        public int Year { get; set; }
        public int TotalOrders { get; set; }
        public double TotalSales { get; set; }
        public double AverageOrderValue { get; set; }
    }
}
