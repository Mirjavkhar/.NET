// Mirjavkhar Djavkharov

using static System.Console;
using System;

abstract class Building {
    protected int setdef = -3;

    private double squareFootage;
    private double cost;
    private int floors;
    private double location;

    public Building() {
        initialize();
    }

    protected abstract void initialize();
    public abstract double calculateCost();

    public virtual double getSquareFootage() {
        return squareFootage;
    }
    public virtual void setSquareFootage(double v) {
        squareFootage = v;
    }

    public double getCost() {
        return cost;
    }
    public void setCost(double v) {
        cost = v;
    }

    public virtual int getFloors() {
        return floors;
    }
    public virtual void setFloors(int v) {
        floors = v;
    }

    public virtual double getLocation() {
        return location;
    }
    public virtual void setLocation(double v) {
        location = v;
    }

    public override string ToString() {
        return "The cost of the ";
    }
}


abstract class Home : Building {
    private int bedrooms;
    private int bathrooms;
    private int garage;

    public Home() : base() { }

    public virtual int getBedrooms() {
        return bedrooms;
    }
    public virtual void setBedrooms(int v) {
        bedrooms = v;
    }

    public virtual int getBathrooms() {
        return bathrooms;
    }
    public virtual void setBathrooms(int v) {
        bathrooms = v;
    }

    public virtual int getGarage() {
        return garage;
    }
    public virtual void setGarage(int v) {
        garage = v;
    }
}


class Apartment : Home {
    public Apartment() : base() { }

    public Apartment(double sqft, int beds, int baths, int floors, double loc, int garage) : base() {
        setSquareFootage(sqft);
        setBedrooms(beds);
        setBathrooms(baths);
        setFloors(floors);
        setLocation(loc);
        setGarage(garage);
    }

    protected override void initialize() {
        base.setSquareFootage(1500);
        base.setBedrooms(2);
        base.setBathrooms(1);
        base.setFloors(1);
        base.setLocation(15.0);
        base.setGarage(0);
    }

    public override void setSquareFootage(double v) {
        base.setSquareFootage(v >= 1000 && v <= 3600 ? v : 1500);
    }

    public override void setBedrooms(int v) {
        base.setBedrooms(v >= 1 && v <= 3 ? v : 2);
    }

    public override void setBathrooms(int v) {
        base.setBathrooms(v >= 1 && v <= 3 ? v : 1);
    }

    public override void setFloors(int v) {
        base.setFloors(v == 1 || v == 2 ? v : 1);
    }

    public override void setLocation(double v) {
        base.setLocation(v >= 0.0 ? v : 15.0);
    }

    public override void setGarage(int v) {
        base.setGarage(v >= 0 && v <= 2 ? v : 0);
    }

    public override double calculateCost() {
        double a = 400.0;
        if (getSquareFootage() > 1500) {
            a += Math.Ceiling((getSquareFootage() - 1500.0) / 100.0) * 50.0;
        }

        double sub = a + getBedrooms() * 200.0 + getBathrooms() * 100.0;

        if (getFloors() == 2) {
            sub *= 1.30;
        }

        sub += getGarage() * 100.0;

        if (getLocation() <= 5.0) {
            sub *= 1.40;
        } else if (getLocation() > 45.0) {
            sub *= 0.75;
        }

        setCost(sub);
        return sub;
    }

    public string additional() {
        return $"sqft={getSquareFootage()}, beds={getBedrooms()}, baths={getBathrooms()}, floors={getFloors()}, loc={getLocation()}, garage={getGarage()}";
    }

    public override string ToString() {
        return base.ToString() + $"apartment is {calculateCost():F2} per month";
    }
}


class Condo : Home {
    public Condo() : base() { }

    public Condo(double sqft, int beds, int baths, int floors, double loc, int garage) : base() {
        setSquareFootage(sqft);
        setBedrooms(beds);
        setBathrooms(baths);
        setFloors(floors);
        setLocation(loc);
        setGarage(garage);
    }

    protected override void initialize() {
        base.setSquareFootage(3000);
        base.setBedrooms(2);
        base.setBathrooms(2);
        base.setFloors(1);
        base.setLocation(15.0);
        base.setGarage(0);
    }

    public override void setSquareFootage(double v) {
        base.setSquareFootage(v >= 2500 && v <= 5500 ? v : 3000);
    }

    public override void setBedrooms(int v) {
        base.setBedrooms(v >= 1 && v <= 4 ? v : 2);
    }

    public override void setBathrooms(int v) {
        base.setBathrooms(v >= 1 && v <= 3 ? v : 2);
    }

    public override void setFloors(int v) {
        base.setFloors(v == 1 || v == 2 ? v : 1);
    }

    public override void setLocation(double v) {
        base.setLocation(v >= 0.0 ? v : 15.0);
    }

    public override void setGarage(int v) {
        base.setGarage(v >= 0 && v <= 2 ? v : 0);
    }

    public override double calculateCost() {
        double a = 180000.0;
        if (getSquareFootage() > 2000) {
            a += Math.Ceiling((getSquareFootage() - 2000.0) / 100.0) * 2800.0;
        } else if (getSquareFootage() < 2000) {
            a -= Math.Ceiling((2000.0 - getSquareFootage()) / 100.0) * 1500.0;
        }

        double sub = a + getBedrooms() * 3400.0 + getBathrooms() * 1500.0;

        if (getFloors() == 2) {
            sub *= 1.40;
        }

        sub += getGarage() * 1500.0;

        if (getLocation() <= 5.0) {
            sub *= 1.60;
        } else if (getLocation() > 20.0 && getLocation() <= 45.0) {
            sub *= 0.90;
        } else if (getLocation() > 45.0) {
            sub *= 0.75;
        }

        setCost(sub);
        return sub;
    }

    public string additional() {
        return $"sqft={getSquareFootage()}, beds={getBedrooms()}, baths={getBathrooms()}, floors={getFloors()}, loc={getLocation()}, garage={getGarage()}";
    }

    public override string ToString() {
        return base.ToString() + $"condominium is {calculateCost():F2}";
    }
}


class House : Home {
    private int basement;
    private double lotSize;
    private int parkingSpaces;

    public House() : base() { }

    public House(double sqft, int beds, int baths, int floors, int bsmt, double loc, int garage, double lot, int parking) : base() {
        setSquareFootage(sqft);
        setBedrooms(beds);
        setBathrooms(baths);
        setFloors(floors);
        setBasement(bsmt);
        setLocation(loc);
        setGarage(garage);
        setLotSize(lot);
        setParkingSpaces(parking);
    }

    protected override void initialize() {
        base.setSquareFootage(3200);
        base.setBedrooms(3);
        base.setBathrooms(2);
        base.setFloors(1);
        basement = 2;
        base.setLocation(15.0);
        base.setGarage(2);
        lotSize = 0.25;
        parkingSpaces = 1;
    }

    public override void setSquareFootage(double v) {
        base.setSquareFootage(v >= 2400 && v <= 6400 ? v : 3200);
    }

    public override void setBedrooms(int v) {
        base.setBedrooms(v >= 1 && v <= 5 ? v : 3);
    }

    public override void setBathrooms(int v) {
        base.setBathrooms(v >= 1 && v <= 4 ? v : 2);
    }

    public override void setFloors(int v) {
        base.setFloors(v >= 1 && v <= 3 ? v : 1);
    }

    public override void setLocation(double v) {
        base.setLocation(v > 5.0 ? v : 15.0);
    }

    public override void setGarage(int v) {
        base.setGarage(v >= 1 && v <= 3 ? v : 2);
    }

    public int getBasement() {
        return basement;
    }
    public void setBasement(int v) {
        basement = v >= 0 && v <= 2 ? v : 2;
    }

    public double getLotSize() {
        return lotSize;
    }
    public void setLotSize(double v) {
        lotSize = v >= 0.25 && v <= 5.00 ? v : 0.25;
    }

    public int getParkingSpaces() {
        return parkingSpaces;
    }
    public void setParkingSpaces(int v) {
        parkingSpaces = v >= 1 && v <= 10 ? v : 1;
    }

    public double acres() {
        return lotSize;
    }

    public override double calculateCost() {
        double a = 160000.0;
        if (getSquareFootage() > 2400) {
            a += Math.Ceiling((getSquareFootage() - 2400.0) / 100.0) * 2800.0;
        } else if (getSquareFootage() < 2400) {
            a -= Math.Ceiling((2400.0 - getSquareFootage()) / 100.0) * 1000.0;
        }

        double b = getBedrooms() * 8200.0;
        double c = getBathrooms() * 3600.0;

        double d = 0;
        if (basement == 2) {
            d = a * 0.136;
        } else if (basement == 1) {
            d = a * 0.082;
        }

        double e = getGarage() * 1750.0;

        double f = 0;
        if (lotSize > 0.25) {
            f = (lotSize - 0.25) * 40000.0;
        }

        double sub = a + b + c + d + e + f;

        if (getLocation() > 20.0 && getLocation() <= 45.0) {
            sub *= 0.95;
        } else if (getLocation() > 45.0) {
            sub *= 0.875;
        }

        setCost(sub);
        return sub;
    }

    public string additional() {
        return $"sqft={getSquareFootage()}, beds={getBedrooms()}, baths={getBathrooms()}, floors={getFloors()}, basement={basement}, loc={getLocation()}, garage={getGarage()}, lot={lotSize} acres, parking={parkingSpaces}";
    }

    public override string ToString() {
        return base.ToString() + $"house is {calculateCost():F2}";
    }
}


class Program {
    static void PrintResult(string label, string extra, string result) {
        WriteLine($"  {label,-12} | {extra}");
        WriteLine($"  {"Result",-12} | {result}");
        WriteLine();
    }

    static void RunApartmentTests() {
        WriteLine("\n==========================================================");
        WriteLine("  APARTMENT TESTS");
        WriteLine("==========================================================");

        Apartment apt0 = new Apartment();
        PrintResult("Default", apt0.additional(), apt0.ToString());

        Apartment apt1 = new Apartment(1200, 1, 1, 1, 46.0, 0);
        PrintResult("Test 1", apt1.additional(), apt1.ToString());

        Apartment apt2 = new Apartment(2301, 2, 2, 1, 1.0, 0);
        PrintResult("Test 2", apt2.additional(), apt2.ToString());

        Apartment apt3 = new Apartment(2699, 3, 2, 1, 15.0, 1);
        PrintResult("Test 3", apt3.additional(), apt3.ToString());

        Apartment apt4 = new Apartment(3600, 3, 3, 2, 2.0, 2);
        PrintResult("Test 4", apt4.additional(), apt4.ToString());

        Apartment apt5 = new Apartment(4300, 4, 4, 3, 15.0, 3);
        PrintResult("Test 5", apt5.additional(), apt5.ToString());
    }

    static void RunCondoTests() {
        WriteLine("\n==========================================================");
        WriteLine("  CONDO TESTS");
        WriteLine("==========================================================");

        Condo con0 = new Condo();
        PrintResult("Default", con0.additional(), con0.ToString());

        Condo con1 = new Condo(2899, 3, 2, 1, 1.0, 0);
        PrintResult("Test 1", con1.additional(), con1.ToString());

        Condo con2 = new Condo(3801, 3, 2, 2, 44.9, 2);
        PrintResult("Test 2", con2.additional(), con2.ToString());

        Condo con3 = new Condo(2500, 1, 1, 1, 45.1, 1);
        PrintResult("Test 3", con3.additional(), con3.ToString());

        Condo con4 = new Condo(5500, 4, 3, 2, 3.0, 2);
        PrintResult("Test 4", con4.additional(), con4.ToString());

        Condo con5 = new Condo(2499, 0, 4, 3, 15.0, 3);
        PrintResult("Test 5", con5.additional(), con5.ToString());
    }

    static void RunHouseTests() {
        WriteLine("\n==========================================================");
        WriteLine("  HOUSE TESTS");
        WriteLine("==========================================================");

        House hou0 = new House();
        PrintResult("Default", hou0.additional(), hou0.ToString());

        House hou1 = new House(1000, 1, 1, 1, 0, 50.6, 0, 0, 1);
        PrintResult("Test 1", hou1.additional(), hou1.ToString());

        House hou2 = new House(3200, 2, 1, 1, 0, 27.6, 0, 0, 2);
        PrintResult("Test 2", hou2.additional(), hou2.ToString());

        House hou3 = new House(1840, 2, 1, 1, 0, 45.0, 0, 0, 1);
        PrintResult("Test 3", hou3.additional(), hou3.ToString());

        House hou4 = new House(2000, 3, 2, 2, 0, 38.4, 1, 0, 3);
        PrintResult("Test 4", hou4.additional(), hou4.ToString());

        House hou5 = new House(1760, 2, 1, 1, 0, 45.1, 0, 0, 2);
        PrintResult("Test 5", hou5.additional(), hou5.ToString());
    }

    static void EnterApartment() {
        WriteLine("\n--- APARTMENT (default) ---");
        Apartment def = new Apartment();
        WriteLine(def.ToString());

        WriteLine("\n--- APARTMENT (your values) ---");
        Write("Square footage (1000-3600): ");
        double.TryParse(ReadLine(), out double sqft);

        Write("Bedrooms (1-3): ");
        int.TryParse(ReadLine(), out int beds);

        Write("Bathrooms (1-3): ");
        int.TryParse(ReadLine(), out int baths);

        Write("Floors (1-2): ");
        int.TryParse(ReadLine(), out int floors);

        Write("Location (miles from downtown): ");
        double.TryParse(ReadLine(), out double loc);

        Write("Garages (0-2): ");
        int.TryParse(ReadLine(), out int garage);

        Apartment user = new Apartment(sqft, beds, baths, floors, loc, garage);
        WriteLine(user.additional());
        WriteLine(user.ToString());
    }

    static void EnterCondo() {
        WriteLine("\n--- CONDO (default) ---");
        Condo def = new Condo();
        WriteLine(def.ToString());

        WriteLine("\n--- CONDO (your values) ---");
        Write("Square footage (2500-5500): ");
        double.TryParse(ReadLine(), out double sqft);

        Write("Bedrooms (1-4): ");
        int.TryParse(ReadLine(), out int beds);

        Write("Bathrooms (1-3): ");
        int.TryParse(ReadLine(), out int baths);

        Write("Floors (1-2): ");
        int.TryParse(ReadLine(), out int floors);

        Write("Location (miles from downtown): ");
        double.TryParse(ReadLine(), out double loc);

        Write("Garages (0-2): ");
        int.TryParse(ReadLine(), out int garage);

        Condo user = new Condo(sqft, beds, baths, floors, loc, garage);
        WriteLine(user.additional());
        WriteLine(user.ToString());
    }

    static void EnterHouse() {
        WriteLine("\n--- HOUSE (default) ---");
        House def = new House();
        WriteLine(def.ToString());

        WriteLine("\n--- HOUSE (your values) ---");
        Write("Square footage (2400-6400): ");
        double.TryParse(ReadLine(), out double sqft);

        Write("Bedrooms (1-5): ");
        int.TryParse(ReadLine(), out int beds);

        Write("Bathrooms (1-4): ");
        int.TryParse(ReadLine(), out int baths);

        Write("Floors (1-3): ");
        int.TryParse(ReadLine(), out int floors);

        Write("Basement (0=none, 1=partial, 2=full): ");
        int.TryParse(ReadLine(), out int bsmt);

        Write("Location (miles from downtown, must be > 5.0): ");
        double.TryParse(ReadLine(), out double loc);

        Write("Garages (1-3): ");
        int.TryParse(ReadLine(), out int garage);

        Write("Lot size in acres (0.25-5.00): ");
        double.TryParse(ReadLine(), out double lot);

        Write("Parking spaces (1-10): ");
        int.TryParse(ReadLine(), out int parking);

        House user = new House(sqft, beds, baths, floors, bsmt, loc, garage, lot, parking);
        WriteLine(user.additional());
        WriteLine(user.ToString());
    }

    static void Main() {
        while (true) {
            WriteLine("\n========== BUILDING COST CALCULATOR ==========");
            WriteLine("1) Apartment");
            WriteLine("2) Condo");
            WriteLine("3) House");
            WriteLine("4) Run all tests");
            WriteLine("Q) Quit");
            Write("Choice: ");

            string choice = (ReadLine() ?? "").Trim().ToUpper();

            if (choice == "Q") {
                break;
            } else if (choice == "1") {
                EnterApartment();
            } else if (choice == "2") {
                EnterCondo();
            } else if (choice == "3") {
                EnterHouse();
            } else if (choice == "4") {
                RunApartmentTests();
                RunCondoTests();
                RunHouseTests();
            } else {
                WriteLine("Invalid choice.");
            }
        }
    }
}