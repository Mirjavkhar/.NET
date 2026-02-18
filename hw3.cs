// Mirjavkhar Djavkharov
// 02/17/2026

using static System.Console;

class Program {
    static void Main() {
        decimal loanAmount = 0m;
        decimal yearlyRatePercent = 0m;
        int years = 0;
        int paymentsPerYear = 0;

        WriteLine("Input Items to Generate Loan Repayment Schedule:\n");

        while (true) {
            Write("Loan Amount: ");
            string? s = ReadLine();
            try {
                if (string.IsNullOrWhiteSpace(s)) 
                    throw new FormatException();
                loanAmount = decimal.Parse(s);
                if (loanAmount < 5000m || loanAmount > 500000m)
                    throw new ArgumentOutOfRangeException();
                break;
            } catch (FormatException) {
                WriteLine("Invalid amount (E.g. 225000)");
            } catch (ArgumentOutOfRangeException) {
                WriteLine("Loan amount have to be between 5000 and 500000!");
            } catch (Exception) {
                WriteLine("Error occured. Try again!");
            }
        }

        while (true) {
            Write("Yearly Interest Rate: ");
            string? s = ReadLine();
            try {
                if (string.IsNullOrWhiteSpace(s)) 
                    throw new FormatException();
                yearlyRatePercent = decimal.Parse(s);
                if (yearlyRatePercent < 0m)
                    throw new ArgumentOutOfRangeException();
                break;
            } catch (FormatException) {
                WriteLine("Invalid rate (E.g. 5.6)");
            } catch (ArgumentOutOfRangeException) {
                WriteLine("Rate cannot be negative!");
            } catch (Exception) {
                WriteLine("Error occured. Try again!");
            }
        }

        while (true) {
            Write("Years: ");
            string? s = ReadLine();
            try {
                if (string.IsNullOrWhiteSpace(s)) 
                    throw new FormatException();
                years = int.Parse(s);
                if (years <= 0)
                    throw new ArgumentOutOfRangeException();
                break;
            } catch (FormatException) {
                WriteLine("Invalid years (E.g. 24)");
            } catch (ArgumentOutOfRangeException) {
                WriteLine("Years must be greater than 0!");
            } catch (Exception) {
                WriteLine("Error occured. Try again!");
            }
        }

        while (true) {
            Write("Payments per year: ");
            string? s = ReadLine();
            try {
                if (string.IsNullOrWhiteSpace(s)) 
                    throw new FormatException();
                paymentsPerYear = int.Parse(s);
                if (paymentsPerYear <= 0)
                    throw new ArgumentOutOfRangeException();
                break;
            } catch (FormatException) {
                WriteLine("Invalid number (E.g. 12)");
            } catch (ArgumentOutOfRangeException) {
                WriteLine("Payments per year must be greater than 0!");
            } catch (Exception) {
                WriteLine("Error occured. Try again!");
            }
        }

        int totalPayments = years * paymentsPerYear;
        decimal yearlyRateDecimal = yearlyRatePercent / 100m; 
        decimal payment = PMT(loanAmount, yearlyRateDecimal, totalPayments, paymentsPerYear); 

        decimal balance = loanAmount;
        decimal totalPaid = 0m;
        decimal totalInterestPaid = 0m;

        // Had to Google how to handle DateTime Format in C#
        // https://www.c-sharpcorner.com/article/datetime-in-c-sharp/
        DateTime date = DateTime.Today;

        WriteLine("\nTotal Payments:\t\t{0}", totalPayments);
        WriteLine("Periodic Payment:\t{0}\n", payment.ToString("C2"));
        WriteLine("\t\tLoan Repayment Schedule\n");
        WriteLine("{0,-12}{1,-14}{2,12}{3,14}{4,14}{5,16}", "Payment Num", "Date", "Payment", "Interest", "Principal", "Balance");
        WriteLine("{0,-12}{1,-14}{2,12}{3,14}{4,14}{5,16}",
            0,
            date.ToString("M/d/yyyy"),
            0m.ToString("C2"),
            0m.ToString("C2"),
            0m.ToString("C2"),
            balance.ToString("C2")
        );

        for (int i = 1; i <= totalPayments; i++) {
            if (paymentsPerYear == 12)
                date = date.AddMonths(1);
            else {
                int days = (int) Math.Round(365.0 / paymentsPerYear);
                date = date.AddDays(days);
            }

            decimal interest = balance * (yearlyRateDecimal / paymentsPerYear);
            decimal principal = payment - interest;

            if (principal > balance) {
                principal = balance;
                payment = principal + interest;
            }

            balance = balance - principal;
            totalPaid += payment;
            totalInterestPaid += interest;

            WriteLine("{0,-12}{1,-14}{2,12}{3,14}{4,14}{5,16}",
                i,
                date.ToString("M/d/yyyy"),
                payment.ToString("C2"),
                interest.ToString("C2"),
                principal.ToString("C2"),
                balance.ToString("C2")
            );
        }

        WriteLine("\nTotal Payment:  {0}", totalPaid.ToString("C2"));
        WriteLine("Total Interest: {0}", totalInterestPaid.ToString("C2"));
    }

    static decimal PMT(decimal pv, decimal yearlyRateDecimal, int totalPayments, int paymentsPerYear) {
        if (yearlyRateDecimal == 0m)
            return pv / totalPayments;
        double R = (double) (yearlyRateDecimal / paymentsPerYear);
        double n = totalPayments;
        double Pv = (double) pv;
        double payment = (Pv * R) / (1.0 - Math.Pow(1.0 + R, -n));
        return (decimal) payment;
    }
}