// Mirjavkhar Djavkharov
// 03/13/2026

using static System.Console;

class Employee {
    protected int id_num;
    protected string first_name;
    protected string last_name;

    public Employee() { 
        init(); 
    }

    public Employee(int id_num, string first_name, string last_name) {
        init(id_num, first_name, last_name);
    }

    public void init() {
        id_num = 0;
        first_name = "No Name";
        last_name = "No Name";
    }

    public void init(int id_num, string first_name, string last_name) {
        this.id_num = id_num;
        this.first_name = first_name;
        this.last_name = last_name;
    }

    public virtual void setData(int id_num, string first_name, string last_name) {
        this.id_num = id_num;
        this.first_name = first_name;
        this.last_name = last_name;
    }

    public void setId(int id_num) { 
        this.id_num = id_num; 
    }

    public void setFirstName(string first_name) { 
        this.first_name = first_name; 
    }

    public void setLastName(string last_name) { 
        this.last_name = last_name; 
    }

    public int getId() { 
        return id_num; 
    }

    public string getFirstName() { 
        return first_name; 
    }

    public string getLastName() { 
        return last_name; 
    }

    public virtual string displayData() {
        return string.Format("{0,-6}{1,-12}{2,-12}", id_num, last_name, first_name);
    }

    public virtual string earnings() {
        return string.Format("{0,-16}{1,-6}{2,-12}{3,-12}{4,12}", "Employee", id_num, last_name, first_name, "0.00");
    }
}


class SalaryWorker : Employee {
    protected float salary;

    public SalaryWorker() : base() { 
        init(); 
    }

    public SalaryWorker(int id_num, string first_name, string last_name, float salary)
        : base(id_num, first_name, last_name) {
        init(id_num, first_name, last_name, salary);
    }

    public void init() {
        base.init();
        salary = 0.0f;
    }

    public void init(int id_num, string first_name, string last_name, float salary) {
        init(id_num, first_name, last_name);
        this.salary = salary;
    }

    public void setData(int id_num, string first_name, string last_name, float salary) {
        base.setData(id_num, first_name, last_name);
        this.salary = salary;
    }

    public void setSalary(float salary) { 
        this.salary = salary; 
    }

    public float getSalary() { 
        return salary; 
    }

    public override string displayData() {
        return base.displayData() + string.Format("{0}", salary.ToString("0.00"));
    }

    public override string earnings() {
        float weekly = salary / 52.0f;
        return string.Format("{0,-16}{1,-6}{2,-12}{3,-12}{4,12}",
            "SalaryWorker", id_num, last_name, first_name, weekly.ToString("0.00"));
    }
}

class HourlyWorker : Employee {
    protected float hoursworked;
    protected float payrate;

    public HourlyWorker() : base() { 
        init(); 
    }

    public HourlyWorker(int id_num, string first_name, string last_name, float hoursworked, float payrate)
        : base(id_num, first_name, last_name) {
        init(id_num, first_name, last_name, hoursworked, payrate);
    }

    public void init() {
        base.init();
        hoursworked = 0.0f;
        payrate = 0.0f;
    }

    public void init(int id_num, string first_name, string last_name, float hoursworked, float payrate) {
        base.init(id_num, first_name, last_name);
        this.hoursworked = hoursworked;
        this.payrate = payrate;
    }

    public void setData(int id_num, string first_name, string last_name, float hoursworked, float payrate) {
        base.setData(id_num, first_name, last_name);
        this.hoursworked = hoursworked;
        this.payrate = payrate;
    }

    public void setHoursworked(float hoursworked) { 
        this.hoursworked = hoursworked; 
    }

    public void setPayrate(float payrate) { 
        this.payrate = payrate; 
    }

    public float getHoursworked() { 
        return hoursworked; 
    }

    public float getPayrate() { 
        return payrate; 
    }

    public override string displayData() {
        return base.displayData() + string.Format("{0,-11}{1}", payrate.ToString("0.00"), hoursworked.ToString("0.##"));
    }

    public override string earnings()
    {
        float weekly;
        if (hoursworked <= 40.0f) {
            weekly = hoursworked * payrate;
        } else {
            float overtime = hoursworked - 40.0f;
            weekly = (40.0f * payrate) + (overtime * payrate * 1.5f);
        }
        return string.Format("{0,-16}{1,-6}{2,-12}{3,-12}{4,12}",
            "HourlyWorker", id_num, last_name, first_name, weekly.ToString("0.00"));
    }
}

class CommissionWorker : Employee {
    protected float salary;     
    protected float comm_rate;  
    protected float sales;     

    public CommissionWorker() : base() { 
        init(); 
    }

    public CommissionWorker(int id_num, string first_name, string last_name, float salary, float comm_rate, float sales)
        : base(id_num, first_name, last_name) {
        init(id_num, first_name, last_name, salary, comm_rate, sales);
    }

    public void init() {
        base.init();
        salary = 0.0f;
        comm_rate = 0.0f;
        sales = 0.0f;
    }

    public void init(int id_num, string first_name, string last_name, float salary, float comm_rate, float sales) {
        base.init(id_num, first_name, last_name);
        this.salary = salary;
        this.comm_rate = comm_rate;
        this.sales = sales;
    }

    public void setData(int id_num, string first_name, string last_name, float salary, float comm_rate, float sales) {
        base.setData(id_num, first_name, last_name);
        this.salary = salary;
        this.comm_rate = comm_rate;
        this.sales = sales;
    }

    public void setSalary(float salary) { 
        this.salary = salary; 
    }

    public void setCommRate(float comm_rate) { 
        this.comm_rate = comm_rate; 
    }

    public void setSales(float sales) { 
        this.sales = sales; 
    }

    public float getSalary() { 
        return salary; 
    }

    public float getCommRate() { 
        return comm_rate; 
    }

    public float getSales() { 
        return sales; 
    }

    public override string displayData() {
        return base.displayData() + string.Format("{0,-18}{1,-18}{2}",
                salary.ToString("0.00"),
                comm_rate.ToString("0.###"),
                sales.ToString("0.00"));
    }

    public override string earnings() {
        float weekly = (sales * comm_rate) + (salary / 52.0f);
        return string.Format("{0,-16}{1,-6}{2,-12}{3,-12}{4,12}", "CommissionWkr", id_num, last_name, first_name, weekly.ToString("0.00"));
    }
}

class PieceWorker : Employee {
    protected float wage_per_piece;
    protected int quantity;

    public PieceWorker() : base() { 
        init(); 
    }

    public PieceWorker(int id_num, string first_name, string last_name, float wage_per_piece, int quantity)
        : base(id_num, first_name, last_name) {
        init(id_num, first_name, last_name, wage_per_piece, quantity);
    }

    public void init() {
        base.init();
        wage_per_piece = 0.0f;
        quantity = 0;
    }

    public void init(int id_num, string first_name, string last_name, float wage_per_piece, int quantity) {
        base.init(id_num, first_name, last_name);
        this.wage_per_piece = wage_per_piece;
        this.quantity = quantity;
    }

    public void setData(int id_num, string first_name, string last_name, float wage_per_piece, int quantity) {
        base.setData(id_num, first_name, last_name);
        this.wage_per_piece = wage_per_piece;
        this.quantity = quantity;
    }

    public void setWagePerPiece(float wage_per_piece) { 
        this.wage_per_piece = wage_per_piece; 
    }

    public void setQuantity(int quantity) { 
        this.quantity = quantity; 
    }

    public float getWagePerPiece() { 
        return wage_per_piece; 
    }

    public int getQuantity() { 
        return quantity; 
    }

    public override string displayData() {
        return base.displayData() + string.Format("{0,-16}{1}", wage_per_piece.ToString("0.00"), quantity);
    }

    public override string earnings() {
        float weekly = wage_per_piece * quantity;
        return string.Format("{0,-16}{1,-6}{2,-12}{3,-12}{4,12}", "PieceWorker", id_num, last_name, first_name, weekly.ToString("0.00"));
    }
}

class Program {
    static void Main() {
        Write("Enter input file name (employee.txt): ");
        string fileName = (ReadLine() ?? "").Trim();
        if (fileName.Length == 0) {
            fileName = "employee.txt";
        }

        List<Employee> staff = new List<Employee>();

        try {
            foreach (string raw in File.ReadAllLines(fileName)) {
                string line = raw.Trim();
                if (line.Length == 0) {
                    continue;
                }
                string[] p = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                char type = char.ToUpper(p[0][0]);
                if (type == 'S') {
                    int id = int.Parse(p[1]);
                    string first = p[2];
                    string last = p[3];
                    float salary = float.Parse(p[4]);
                    staff.Add(new SalaryWorker(id, first, last, salary));
                } else if (type == 'H') {
                    int id = int.Parse(p[1]);
                    string first = p[2];
                    string last = p[3];
                    float hours = float.Parse(p[4]);
                    float rate = float.Parse(p[5]);
                    staff.Add(new HourlyWorker(id, first, last, hours, rate));
                } else if (type == 'C') {
                    int id = int.Parse(p[1]);
                    string first = p[2];
                    string last = p[3];
                    float salary = float.Parse(p[4]);
                    float comm = float.Parse(p[5]);
                    float sales = float.Parse(p[6]);
                    staff.Add(new CommissionWorker(id, first, last, salary, comm, sales));
                } else if (type == 'P') {
                    int id = int.Parse(p[1]);
                    string first = p[2];
                    string last = p[3];
                    float wage = float.Parse(p[4]);
                    int qty = int.Parse(p[5]);
                    staff.Add(new PieceWorker(id, first, last, wage, qty));
                }
            }
        } catch (Exception ex) {
            WriteLine("File read/parse error: " + ex.Message);
            return;
        }

        string outFile = "report.txt";
        using (StreamWriter sw = new StreamWriter(outFile)) {
            sw.WriteLine("Gross-pay salary report");
            sw.WriteLine();
            sw.WriteLine("{0,-16}{1,7}{2,-12}{3,-12}{4,12}", "Employee Type", "Number ", "First Name", "Last Name", "Weekly Pay");
            sw.WriteLine(new string('-', 70));
            foreach (Employee e in staff) {
                sw.WriteLine(e.earnings());
            }
        }
        WriteLine("Loaded {0} employees.", staff.Count);
        WriteLine("Report written to: {0}", outFile);
    }
}