namespace Bai04.Models;

public class SalariedEmployee : Employee
{
    private double _monthlySalary = 0;
    private double _responsibilityAllowance = 0;


    public double MonthlySalary
    {
        get => _monthlySalary;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            _monthlySalary = value;
        }
    }

    public double ResponsibilityAllowance
    {
        get => _responsibilityAllowance;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            _responsibilityAllowance = value;
        }
    }
    public SalariedEmployee(string id, string fullName, string department, double monthlyBonus) : base(id, fullName, department, monthlyBonus)
    {
    }



    public SalariedEmployee(string id, string fullName, string department, double monthlyBonus, double monthlySalary, double responsibilityAllowance) : base(id, fullName, department, monthlyBonus)
    {
        MonthlySalary = monthlySalary;
        ResponsibilityAllowance = responsibilityAllowance;
    }

    public override double CalculateGrossPay()
    {
        double grossPay = MonthlySalary + ResponsibilityAllowance + MonthlyBonus;
        return grossPay;
    }

    public override string GetEmployeeType()
    {
        return "Salaried Employee";
    }

    public override void DisplayPayrollInfo()
    {
        Console.WriteLine($"Employee ID: {EmployeeId}");
        Console.WriteLine($"Full Name: {FullName}");
        Console.WriteLine($"Department: {Department}");
        Console.WriteLine($"Monthly Salary: {MonthlySalary:N0}");
        Console.WriteLine($"Responsibility Allowance: {ResponsibilityAllowance:N0}");
        Console.WriteLine($"Monthly Bonus: {MonthlyBonus:N0}");
        Console.WriteLine($"Gross Pay: {CalculateGrossPay():N0}");
    }


    ~SalariedEmployee()
    {
        Console.WriteLine($"Destructor SalariedEmployee {FullName}, ID: {EmployeeId}");
    }
}