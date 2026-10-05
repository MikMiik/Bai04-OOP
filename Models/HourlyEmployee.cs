namespace Bai04.Models;

public class HourlyEmployee : Employee
{
    private double _hourlyRate = 0;
    private double _workedHours = 0;


    public double HourlyRate
    {
        get => _hourlyRate;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            _hourlyRate = value;
        }
    }

    public double WorkedHours
    {
        get => _workedHours;
        set
        {
            if (value < 0 || value > 250)
            {
                Console.WriteLine("Worked hours must be between 0 and 250.");
                return;
            }
            _workedHours = value;
        }
    }

    public HourlyEmployee(string id, string fullName) : base(id, fullName) { }

    public HourlyEmployee(string id, string fullName, string department, double hourlyRate, double workedHours) : base(id, fullName, department)
    {
        HourlyRate = hourlyRate;
        WorkedHours = workedHours;
    }

    public HourlyEmployee(string id, string fullName, string department, double monthlyBonus, double hourlyRate, double workedHours) : base(id, fullName, department, monthlyBonus)
    {
        HourlyRate = hourlyRate;
        WorkedHours = workedHours;
    }

    public override double CalculateGrossPay()
    {
        double basePay;
        if (WorkedHours <= 160)
        {
            basePay = WorkedHours * HourlyRate;
        }
        else
        {
            basePay = 160 * HourlyRate + (WorkedHours - 160) * HourlyRate * 1.5;

        }
        double grossPay = basePay + MonthlyBonus;
        return grossPay;
    }

    public override string GetEmployeeType()
    {
        return "Hourly Employee";
    }

    public override void DisplayPayrollInfo()
    {
        Console.WriteLine($"Employee ID: {EmployeeId}");
        Console.WriteLine($"Full Name: {FullName}");
        Console.WriteLine($"Department: {Department}");
        Console.WriteLine($"Hourly Rate: {HourlyRate:N0}");
        Console.WriteLine($"Worked Hours: {WorkedHours:N0}");
        Console.WriteLine($"Monthly Bonus: {MonthlyBonus:N0}");
        Console.WriteLine($"Gross Pay: {CalculateGrossPay():N0}");
    }

    ~HourlyEmployee()
    {
        Console.WriteLine($"Destructor HourlyEmployee {FullName}, ID: {EmployeeId}");
    }
}