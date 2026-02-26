// Mirjavkhar Djavkharov
// 02/25/2026

// Passed the local test successfully!

using static System.Console;
using System.IO;
using System;

class Program {
    const decimal GrandMean = 57.3m;

    static void Main() {
        string fileName = "trend.txt";
        string[] lines;

        try {
            lines = File.ReadAllLines(fileName);
        } catch (Exception) {
            WriteLine("Could not read file: " + fileName);
            WriteLine("Could not find the file. Please make sure trend.txt is in the same folder as the program.");
            return;
        }

        // Arrays for months and data
        string[] months = new string[lines.Length];
        int[,] data = new int[lines.Length, 5];

        // Parse that file's lines
        for (int i = 0; i < lines.Length; i++) {
            string line = lines[i].Trim();
            if (line.Length == 0) 
                continue;
            string[] parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); // Split by whitespace
            months[i] = parts[0];
            for (int y = 0; y < 5; y++) {
                data[i, y] = int.Parse(parts[y + 1]);
            }
        }

        decimal[] monthlyAvg = new decimal[12];
        decimal[] monthlyDev = new decimal[12];

        for (int m = 0; m < 12; m++) {
            monthlyAvg[m] = CalcMonthlyAverage(data, m);
            monthlyDev[m] = CalcDeviation(GrandMean, monthlyAvg[m]); 
        }

        decimal[] quarterlyDevAtMonth = new decimal[12]; 
        for (int qEnd = 2; qEnd < 12; qEnd += 3) {
            decimal qAvg = CalcQuarterlyAverage(monthlyAvg, qEnd - 2, qEnd);
            quarterlyDevAtMonth[qEnd] = CalcDeviation(GrandMean, qAvg);
        }

        decimal[] yearlyAvg = new decimal[5];
        decimal[] yearlyDev = new decimal[5];

        for (int y = 0; y < 5; y++) {
            decimal avg = CalcYearlyAverage(data, y);
            yearlyAvg[y] = Math.Round(avg, 2);
            yearlyDev[y] = Math.Round(CalcDeviation(GrandMean, yearlyAvg[y]), 2);
        }

        WriteLine("\n\t\t\tTREND-SEASONAL-NOISE ANALYSIS\n");
        WriteLine("{0,-8}{1,6}{2,6}{3,6}{4,6}{5,6}{6,12}{7,14}{8,18}", "", "2020", "2021", "2022", "2023", "2024", "Monthly Avg", "Monthly Dev", "Quarterly Dev");

        for (int m = 0; m < 12; m++) {
            string qDevText = "";
            if (m == 2 || m == 5 || m == 8 || m == 11)
                qDevText = quarterlyDevAtMonth[m].ToString("0.00");

            WriteLine("{0,-10}{1,6}{2,6}{3,6}{4,6}{5,6}{6,12}{7,14}{8,18}",
                months[m],
                data[m, 0],
                data[m, 1],
                data[m, 2],
                data[m, 3],
                data[m, 4],
                monthlyAvg[m].ToString("0.0"),
                monthlyDev[m].ToString("0.00"),
                qDevText
            );
        }

        WriteLine(new string('-', 90));
        WriteLine("Yearly");
        WriteLine("Average   {0,8}{1,12}{2,8}{3,12}{4,12}",
            yearlyAvg[0].ToString("0.00"),
            yearlyAvg[1].ToString("0.00"),
            yearlyAvg[2].ToString("0.00"),
            yearlyAvg[3].ToString("0.00"),
            yearlyAvg[4].ToString("0.00")
        );

        WriteLine("\nYearly");
        WriteLine("Deviation {0,8}{1,12}{2,8}{3,12}{4,12}",
            yearlyDev[0].ToString("0.00"),
            yearlyDev[1].ToString("0.00"),
            yearlyDev[2].ToString("0.00"),
            yearlyDev[3].ToString("0.00"),
            yearlyDev[4].ToString("0.00")
        );
    }

    // Method for monthly calculations
    static decimal CalcMonthlyAverage(int[,] data, int monthIndex) {
        decimal sum = 0m;
        for (int y = 0; y < 5; y++)
            sum += data[monthIndex, y];
        return Math.Round(sum / 5m, 1);
    }

    // Method for yearly calculations
    static decimal CalcYearlyAverage(int[,] data, int yearIndex) {
        decimal sum = 0m;
        for (int m = 0; m < 12; m++)
            sum += data[m, yearIndex];
        return sum / 12m;
    }

    // Method for quarterly calculations
    static decimal CalcQuarterlyAverage(decimal[] monthlyAvg, int startMonth, int endMonth){
        decimal sum = 0m;
        for (int m = startMonth; m <= endMonth; m++)
            sum += monthlyAvg[m];
        return Math.Round(sum / 3m, 1);
    }

    // Method for deviation calculations
    static decimal CalcDeviation(decimal grandMean, decimal avg) {
        decimal diff = grandMean - avg;
        decimal dev = diff * diff;
        return Math.Round(dev, 2);
    }
}