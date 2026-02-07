// Mirjavkhar Djavkharov
// 02/06/2026

using static System.Console;

class Program {
    static void Main() {
        WriteLine("===== Tax Payable Calculator =====");

        decimal income = 0m;

        while (true) {
            Write("Enter taxable income amount: ");
            string? input = ReadLine();
            try {
                if (string.IsNullOrWhiteSpace(input))
                    throw new FormatException();
                income = decimal.Parse(input);
                if (income < 0m)
                    throw new ArgumentOutOfRangeException();
                break; 
            } catch (FormatException) {
                WriteLine("Invalid input. Enter a number!");
            } catch (ArgumentOutOfRangeException) {
                WriteLine("Income cannot be negative. Try again!");
            } catch (Exception) {
                WriteLine("Error occured. Try again!");
            }
        }

        decimal tax;

        if (income >= 1.00m && income <= 4461.99m) 
            tax = 0m;
        else if (income >= 4462.00m && income <= 17893.99m)
            tax = 0m + 0.30m * (income - 4462.00m);
        else if (income >= 17894.00m && income <= 29499.99m)
            tax = 4119.00m + 0.35m * (income - 17894.00m);
        else if (income >= 29500.00m && income <= 45787.99m)
            tax = 8656.00m + 0.46m * (income - 29500.00m);
        else if (income >= 45788.00m)
            tax = 11179.00m + 0.60m * (income - 45788.00m);
        else
            tax = 0m;

        WriteLine();
        WriteLine("Tax payable: {0}", tax.ToString("C2"));
        WriteLine("=========== Thank you! ===========");
    }
}
