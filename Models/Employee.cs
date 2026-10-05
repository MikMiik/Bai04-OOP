namespace Bai04.Models;

public class Employee
{
    private string _employeeId = string.Empty;
    private string _fullName = string.Empty;

    private string _department = "Unassigned";
    private double _monthlyBonus = 0;

    public string EmployeeId
    {
        get => _employeeId;
        set
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            _employeeId = value;
        }
    }

    public string FullName
    {
        get => _fullName;
        set
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            _fullName = value;
        }
    }

    public string Department
    {
        get => _department;
        set
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            _department = value;
        }
    }

    public double MonthlyBonus
    {
        get => _monthlyBonus;
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            _monthlyBonus = value;
        }
    }
    public Employee(string id, string fullName)
    {
        Console.WriteLine($"Employee created with ID: {id}, Name: {fullName}, Department: {Department}, Monthly Bonus: {MonthlyBonus}");
    }

    public Employee(string id, string fullName, string department)
    {
        EmployeeId = id;
        FullName = fullName;
        Department = department;
    }

    public Employee(string id, string fullName, string department, double monthlyBonus)
    {
        EmployeeId = id;
        FullName = fullName;
        Department = department;
        MonthlyBonus = monthlyBonus;
    }

    public void AddBonus(double amount)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
        MonthlyBonus += amount;
        Console.WriteLine($"Monthly bonus of {FullName} increased by {amount:N0}. New monthly bonus: {MonthlyBonus:N0}");
    }

    public void AddBonus(double amount, string reason)
    {
        if (string.IsNullOrWhiteSpace(reason))
        {
            throw new ArgumentException("Reason cannot be null or whitespace.", nameof(reason));
        }
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
        MonthlyBonus += amount;
        Console.WriteLine($"Monthly bonus of {FullName} increased by {amount:N0}. New monthly bonus: {MonthlyBonus:N0}. Reason: {reason}");
    }

    public void AddBonus(double rate, double referenceAmount, string reason)
    {
        if (string.IsNullOrWhiteSpace(reason))
        {
            throw new ArgumentException("Reason cannot be null or whitespace.", nameof(reason));
        }
        if (rate < 0 || rate > 0.5)
        {
            throw new ArgumentOutOfRangeException(nameof(rate), "Rate must be between 0 and 0.5.");
        }
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(referenceAmount);
        MonthlyBonus += rate * referenceAmount;
        Console.WriteLine($"Monthly bonus of {FullName} increased by {rate * referenceAmount}");
    }

    public virtual double CalculateGrossPay()
    {
        return MonthlyBonus;
    }
    public virtual string GetEmployeeType()
    {
        return "Employee";
    }
    public virtual void DisplayPayrollInfo()
    {
        Console.WriteLine($"ID: {EmployeeId}, Name: {FullName}, Department: {Department}, Monthly Bonus: {MonthlyBonus:N0}, Gross Pay: {CalculateGrossPay():N0}");
    }
    ~Employee()
    {
        Console.WriteLine($"Destructor Employee {FullName}, ID: {EmployeeId}");
    }
}