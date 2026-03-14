// Mirjavkhar Djavkharov
// 03/13/2026
// bussdata.txt

using static System.Console;

struct Business {
    public int rank;
    public string company;
    public decimal sales;     
    public int employees;
    public int founded;
    public string product;

    public override string ToString() {
        return string.Format("{0,6}  {1,-22}  {2,10}  {3,10}  {4,8}  {5,-18}",
            rank,
            company.Length > 22 ? company.Substring(0, 22) : company,
            sales.ToString("0"),
            employees,
            founded,
            product.Length > 18 ? product.Substring(0, 18) : product
        );
    }
}

class Program {
    static void Main() {
        List<Business> table = new List<Business>();

        Write("Enter input file name (bussdata.txt): ");
        string file = ReadLine();

        try {
            foreach (string raw in File.ReadAllLines(file)) {
                string line = raw.Trim();
                if (line.Length == 0) {
                    continue;
                }
                string[] p = line.Split('\t');
                List<string> parts = new List<string>();
                for (int i = 0; i < p.Length; i++) {
                    string t = p[i].Trim();
                    if (t.Length > 0) {
                        parts.Add(t);
                    }
                }
                if (parts.Count < 6) {
                    continue;
                }
                Business b = new Business();
                b.rank = int.Parse(parts[0]);
                b.company = parts[1];
                b.sales = decimal.Parse(parts[2]);
                b.employees = int.Parse(parts[3]);
                b.founded = int.Parse(parts[4]);
                b.product = parts[5];
                table.Add(b);
            }
            WriteLine("Loaded {0} records.\n", table.Count);
        } catch (Exception ex) {
            WriteLine("Error reading file: " + ex.Message);
            return;
        }

        while (true) {
            WriteLine("\nMENU");
            WriteLine("1) Delete first record");
            WriteLine("2) Sum Sales");
            WriteLine("3) Find record with largest employees");
            WriteLine("4) Sort by Company (asc)");
            WriteLine("5) Sort by Sales (desc)");
            WriteLine("6) Print report to report.txt");
            WriteLine("7) Delete record by rank");
            WriteLine("8) Add new record");
            WriteLine("9) Display all records");
            WriteLine("Q) Quit");
            Write("Choice: ");

            string choice = (ReadLine() ?? "").Trim().ToUpper();
            if (choice == "Q") 
                break;
            if (choice == "1") {
                if (table.Count == 0) {
                    WriteLine("Table empty.");
                } else { 
                    table.RemoveAt(0); 
                    WriteLine("First record deleted."); 
                }
            } else if (choice == "2") {
                decimal sum = 0m;
                foreach (var r in table) sum += r.sales;
                WriteLine("Sum of Sales: {0}", sum.ToString("0"));
            } else if (choice == "3") {
                if (table.Count == 0) { 
                    WriteLine("Table empty."); continue; 
                }
                int best = 0;
                for (int i = 1; i < table.Count; i++)
                    if (table[i].employees > table[best].employees) 
                    best = i;

                PrintHeader();
                WriteLine(table[best].ToString());
            } else if (choice == "4") {
                table.Sort((a, b) => string.Compare(a.company, b.company, StringComparison.OrdinalIgnoreCase));
                WriteLine("Sorted by Company ASC.");
            } else if (choice == "5") {
                table.Sort((a, b) => b.sales.CompareTo(a.sales));
                WriteLine("Sorted by Sales DESC.");
            } else if (choice == "6") {
                using (StreamWriter sw = new StreamWriter("report.txt")) {
                    sw.WriteLine("BUSS DATA REPORT\n");
                    sw.WriteLine(HeaderLine());
                    sw.WriteLine(new string('-', 92));
                    foreach (var r in table) sw.WriteLine(r.ToString());
                }
                WriteLine("Wrote report.txt");
            } else if (choice == "7") {
                Write("Enter Rank to delete: ");
                if (!int.TryParse(ReadLine(), out int key)) { 
                    WriteLine("Bad key."); continue; 
                }
                int loc = -1;
                for (int i = 0; i < table.Count; i++)
                    if (table[i].rank == key) { 
                        loc = i; break; 
                    }
                if (loc == -1) { 
                    WriteLine("Key not found."); 
                    continue; 
                }
                WriteLine("Delete this record?");
                PrintHeader();
                WriteLine(table[loc].ToString());
                Write("Confirm (Y/N): ");
                string c = (ReadLine() ?? "").Trim().ToUpper();
                if (c == "Y") { 
                    table.RemoveAt(loc); 
                    WriteLine("Deleted."); 
                } else {
                    WriteLine("Canceled.");
                }
            } else if (choice == "8") {
                Business b = new Business();
                while (true) {
                    Write("Enter new Rank (key): ");
                    if (!int.TryParse(ReadLine(), out int key)) { 
                        WriteLine("Bad key."); 
                        continue; 
                    }
                    bool exists = false;
                    foreach (var r in table) if (r.rank == key) { 
                        exists = true; 
                        break; 
                    }
                    if (exists) { 
                        WriteLine("Key already exists."); 
                        continue; 
                    }
                    b.rank = key;
                    break;
                }
                Write("Company: "); b.company = (ReadLine() ?? "").Trim();
                Write("Sales (Million): ");
                while (!decimal.TryParse(ReadLine(), out b.sales)) {
                    Write("Re-enter Sales: ");
                }
                Write("Employees: ");
                while (!int.TryParse(ReadLine(), out b.employees)) {
                    Write("Re-enter Employees: ");
                }
                Write("Year Founded: ");
                while (!int.TryParse(ReadLine(), out b.founded)) {
                    Write("Re-enter Year: ");
                }
                Write("Product Line: "); b.product = (ReadLine() ?? "").Trim();
                WriteLine("Add this record?");
                PrintHeader();
                WriteLine(b.ToString());
                Write("Confirm (Y/N): ");
                string c = (ReadLine() ?? "").Trim().ToUpper();
                if (c == "Y") { 
                    table.Add(b); 
                    WriteLine("Added."); 
                } else {
                    WriteLine("Canceled.");
                }
            } else if (choice == "9") {
                if (table.Count == 0) { 
                    WriteLine("Table empty."); 
                    continue; 
                }
                PrintHeader();
                foreach (var r in table) {
                    WriteLine(r.ToString());
                }
            } else {
                WriteLine("Invalid choice.");
            }
        }
    }

    static void PrintHeader() {
        WriteLine(HeaderLine());
        WriteLine(new string('-', 92));
    }

    static string HeaderLine() {
        return string.Format("{0,6}  {1,-22}  {2,10}  {3,10}  {4,8}  {5,-18}", "Rank", "Company", "Sales(M)", "Employees", "Founded", "Product");
    }
}