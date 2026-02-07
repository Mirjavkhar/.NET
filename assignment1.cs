// Mirjavkhar Djavkharov
// 02/06/2026

using static System.Console;

class Program {
    static void Main() {
        Write("Enter Age                      : ");
        int age = 0;
        while (true) {
            string? input = ReadLine();
            try {
                if (string.IsNullOrWhiteSpace(input)) throw new FormatException();
                age = int.Parse(input);
                if (age < 0) throw new ArgumentOutOfRangeException();
                break;
            } catch (FormatException) {
                Write("Invalid age. Enter a whole number: ");
            } catch (ArgumentOutOfRangeException) {
                Write("Age cannot be negative. Try again: ");
            } catch (Exception) {
                Write("Error occured. Try again: ");
            }
        }

        Write("Enter years at current address : ");
        int yearsAddress = 0;
        while (true) {
            string? input = ReadLine();
            try {
                if (string.IsNullOrWhiteSpace(input)) throw new FormatException();
                yearsAddress = int.Parse(input);
                if (yearsAddress < 0) throw new ArgumentOutOfRangeException();
                break;
            } catch (FormatException) {
                Write("Invalid number. Enter whole number of years: ");
            } catch (ArgumentOutOfRangeException) {
                 Write("Years cannot be negative. Try again: ");
            } catch (Exception) {
                Write("Error occured. Try again: ");
            }
        }

        Write("Enter Annual Income            : ");
        decimal income = 0m;
        while (true) {
            string? input = ReadLine();
            try {
                if (string.IsNullOrWhiteSpace(input)) throw new FormatException();
                income = decimal.Parse(input);
                if (income < 0m) throw new ArgumentOutOfRangeException();
                break;
            } catch (FormatException) {
                Write("Invalid income. Enter a number: ");
            } catch (ArgumentOutOfRangeException) {
                Write("Income cannot be negative. Try again: ");
            } catch (Exception) {
                Write("Error occured. Try again: ");
            }
        }

        Write("Enter years at current Job     : ");
        int yearsJob = 0;
        while (true) {
            string? input = ReadLine();
            try {
                if (string.IsNullOrWhiteSpace(input)) throw new FormatException();
                yearsJob = int.Parse(input);
                if (yearsJob < 0) throw new ArgumentOutOfRangeException();
                break;
            } catch (FormatException) {
                Write("Invalid number. Enter whole number of years: ");
            } catch (ArgumentOutOfRangeException) {
                Write("Years cannot go negative. Try again: ");
            } catch (Exception) {
                Write("Error occured. Try again: ");
            }
        }

        int points = 0;

        // Age points 
        if (age <= 20) 
            points += -10;
        else if (age >= 21 && age <= 30) 
            points += 0;
        else if (age >= 31 && age <= 50) 
            points += 20;
        else 
            points += 25; 

        // Year address points
        if (yearsAddress < 1) 
            points += -5;
        else if (yearsAddress >= 1 && yearsAddress <= 3) 
            points += 5;
        else if (yearsAddress >= 4 && yearsAddress <= 8) 
            points += 12;
        else 
            points += 20; 

        // Income points
        if (income <= 15000m) 
            points += 0;
        else if (income >= 15001m && income <= 25000m) 
            points += 12;
        else if (income >= 25001m && income <= 40000m) 
            points += 24;
        else 
            points += 30; 

        // Years job points
        if (yearsJob < 2) 
            points += -4;
        else if (yearsJob >= 2 && yearsJob <= 4) 
            points += 8;
        else 
            points += 15; 

        WriteLine();
        if (points >= -19 && points <= 20) 
            WriteLine("Sorry, we weren't able to issue you a card.");
        else if (points >= 21 && points <= 35)
            WriteLine("Card issued with $500 credit limit");
        else if (points >= 36 && points <= 60)
            WriteLine("Card issued with $2000 credit limit");
        else 
            WriteLine("Card issued with $5000 credit limit");
        WriteLine();
    }
}