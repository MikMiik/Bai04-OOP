namespace Bai04.Models;

public class SalesEmployee : Employee
{
    private double _baseSalary = 0;
    private double _salesRevenue = 0;

    private double _commissionRate = 0;


    public double BaseSalary
    {
        get => _baseSalary;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            _baseSalary = value;
        }
    }

    public double SalesRevenue
    {
        get => _salesRevenue;
        set
        {
            _salesRevenue = value;
        }
    }

    public double CommissionRate
    {
        get => _commissionRate;
        set
        {
            if (value < 0 || value > 0.3)
            {
                Console.WriteLine("Commission rate must be between 0 and 0.3.");
                return;
            }
            _commissionRate = value;
        }
    }

    public SalesEmployee(string id, string fullName) : base(id, fullName) { }

    public SalesEmployee(string id, string fullName, string department, double baseSalary, double salesRevenue, double commissionRate) : base(id, fullName, department)
    {
        BaseSalary = baseSalary;
        SalesRevenue = salesRevenue;
        CommissionRate = commissionRate;
    }

    public override double CalculateGrossPay()
    {
        double grossPay = BaseSalary + (SalesRevenue * CommissionRate) + MonthlyBonus;
        return grossPay;
    }
    public override string GetEmployeeType()
    {
        return "Sales Employee";
    }

    public override void DisplayPayrollInfo()
    {
        Console.WriteLine($"Employee ID: {EmployeeId}");
        Console.WriteLine($"Full Name: {FullName}");
        Console.WriteLine($"Department: {Department}");
        Console.WriteLine($"Base Salary: {BaseSalary:N0}");
        Console.WriteLine($"Sales Revenue: {SalesRevenue:N0}");
        Console.WriteLine($"Commission Rate: {CommissionRate:N0}");
        Console.WriteLine($"Monthly Bonus: {MonthlyBonus:N0}");
        Console.WriteLine($"Gross Pay: {CalculateGrossPay():N0}");
    }

    ~SalesEmployee()
    {
        Console.WriteLine($"Destructor SalesEmployee {FullName}, ID: {EmployeeId}");
    }
}