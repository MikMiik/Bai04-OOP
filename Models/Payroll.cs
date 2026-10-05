namespace Bai04.Models;

public class Payroll
{
    private string _period = string.Empty;
    public List<Employee> Employees { get; } = new();
    public Payroll(string period)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(period);
        _period = period;
    }

    public bool AddEmployee(Employee employee)
    {
        ArgumentNullException.ThrowIfNull(employee);
        if (Employees.Contains(employee))
        {
            Console.WriteLine($"Employee {employee.FullName} is already in the payroll.");
            return false;
        }
        Employees.Add(employee);
        Console.WriteLine($"Added employee {employee.FullName} to the payroll for period {_period}.");
        return true;
    }

    public bool FindEmployee(string employeeId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(employeeId);
        bool result = Employees.Any(m => m.EmployeeId == employeeId);
        return result;
    }

    public double CalculateTotalPayroll()
    {
        double totalPayroll = Employees.Sum(employee => employee.CalculateGrossPay());
        return totalPayroll;
    }

    public double CalculatePayrollByDepartment(string department)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(department);
        double totalPayroll = Employees
            .Where(employee => employee.Department.Equals(department, StringComparison.OrdinalIgnoreCase))
            .Sum(employee => employee.CalculateGrossPay());
        return totalPayroll;
    }

    public double FindHighestPaidEmployee()
    {
        if (Employees.Count == 0)
        {
            return 0;
        }
        double highestPay = Employees.Max(employee => employee.CalculateGrossPay());
        return highestPay;
    }

    public void DisplayPayroll()
    {
        Console.WriteLine($"Payroll for period: {_period}");
        foreach (var employee in Employees)
        {
            Console.WriteLine($"Employee ID: {employee.EmployeeId}, Name: {employee.FullName}, Department: {employee.Department}, Gross Pay: {employee.CalculateGrossPay():N0}");
        }
    }

    ~Payroll()
    {
        Console.WriteLine($"Destructor Payroll");
    }
}