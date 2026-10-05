/*
Mã sinh viên: 202418946
Họ tên: Phạm Văn Minh
*/

using Bai04.Models;

// Nhân viên lương cố định 
SalariedEmployee salariedEmployee1 = new("E001", "Nguyễn Minh An", "Đào tạo", monthlyBonus: 1000000, monthlySalary: 15000000, responsibilityAllowance: 2000000);
var grossPaySalariedEmployee1 = salariedEmployee1.CalculateGrossPay();
Console.WriteLine($"Gross Pay of {salariedEmployee1.FullName}: {grossPaySalariedEmployee1:N0}");

// Nhân viên theo giờ, không có giờ vượt ngưỡng 
HourlyEmployee hourlyEmployee1 = new("E002", " Trần Thu Bình", "Hỗ trợ", monthlyBonus: 500000, hourlyRate: 100000, workedHours: 150);
var grossPayHourlyEmployee1 = hourlyEmployee1.CalculateGrossPay();
Console.WriteLine($"Gross Pay of {hourlyEmployee1.FullName}: {grossPayHourlyEmployee1:N0}");

// Nhân viên theo giờ, có giờ vượt ngưỡng 
HourlyEmployee hourlyEmployee2 = new("E003", "Lê Hoàng Chi", "Hỗ trợ", hourlyRate: 100000, workedHours: 170);
var grossPayHourlyEmployee2 = hourlyEmployee2.CalculateGrossPay();
Console.WriteLine($"Gross Pay of {hourlyEmployee2.FullName}: {grossPayHourlyEmployee2:N0}");

// Nhân viên kinh doanh 
SalesEmployee salesEmployee1 = new("E004", "Phạm Quốc Dũng", "Kinh doanh", baseSalary: 8000000, salesRevenue: 200000000, commissionRate: 0.05);
salesEmployee1.AddBonus(0.02, 50000000, "Được thưởng");
var grossPaySalesEmployee1 = salesEmployee1.CalculateGrossPay();
Console.WriteLine($"Gross Pay of {salesEmployee1.FullName}: {grossPaySalesEmployee1:N0}");

// Tổng của phòng Hỗ trợ 
double totalGrossPaySupportDepartment = hourlyEmployee1.CalculateGrossPay() + hourlyEmployee2.CalculateGrossPay();
Console.WriteLine($"Total Gross Pay of Support Department: {totalGrossPaySupportDepartment:N0}");
//  Kiểm thử biên và kiểm thử lỗi 
// 1. Tạo nhân viên với ID rỗng
try
{
    SalariedEmployee invalidEmp = new("", "Test", "IT", 0);
}
catch (Exception ex)
{
    Console.WriteLine($"[Test 1] ID không hợp lệ: {ex.Message}");
}

// 2. Gán MonthlyBonus số âm 
try
{
    salariedEmployee1.MonthlyBonus = -5000;
}
catch (Exception ex)
{
    Console.WriteLine($"[Test 2] MonthlyBonus âm: {ex.Message}");
}

// 3. AddBonus số tiền <= 0 
try
{
    salariedEmployee1.AddBonus(0);
}
catch (Exception ex)
{
    Console.WriteLine($"[Test 3] AddBonus số tiền <= 0: {ex.Message}");
}

// 4. AddBonus lý do rỗng 
try
{
    salariedEmployee1.AddBonus(500000, "");
}
catch (Exception ex)
{
    Console.WriteLine($"[Test 4] AddBonus lý do rỗng: {ex.Message}");
}

// 5. AddBonus tỷ lệ vượt ngưỡng > 0.5
try
{
    salariedEmployee1.AddBonus(0.6, 10000000, "Thưởng dự án");
}
catch (Exception ex)
{
    Console.WriteLine($"[Test 5] AddBonus tỷ lệ > 50%: {ex.Message}");
}

// 6. Biên: HourlyEmployee tại đúng ngưỡng 160 giờ 
HourlyEmployee hourlyExact160 = new("E101", "Nguyễn Biên 160h", "Kỹ thuật", hourlyRate: 100000, workedHours: 160);
Console.WriteLine($"[Test 6] Biên WorkedHours = 160h: {hourlyExact160.CalculateGrossPay():N0}");

// 7. Biên & Lỗi: HourlyEmployee giờ làm việc vượt 250 giờ 
HourlyEmployee hourlyOverLimit = new("E102", "Trần Quá Giờ", "Kỹ thuật", hourlyRate: 100000, workedHours: 0);
hourlyOverLimit.WorkedHours = 260;
Console.WriteLine($"[Test 7] WorkedHours sau khi gán 260h: {hourlyOverLimit.WorkedHours}h");

// 8. Biên & Lỗi: SalesEmployee hoa hồng vượt 0.3
SalesEmployee salesInvalidCommission = new("E103", "Lê Hoa Hồng Cao", "Sales", baseSalary: 5000000, salesRevenue: 10000000, commissionRate: 0);
salesInvalidCommission.CommissionRate = 0.35;
Console.WriteLine($"[Test 8] CommissionRate sau khi gán 0.35: {salesInvalidCommission.CommissionRate}");

// 9. Thêm nhân viên trùng lặp
Payroll payroll = new("10/2026");

payroll.AddEmployee(salariedEmployee1);
bool isDuplicateAdded = payroll.AddEmployee(salariedEmployee1);
Console.WriteLine($"[Test 9] Kết quả thêm nhân viên trùng: {isDuplicateAdded}");

// 10. Biên: Payroll rỗng tìm lương cao nhất 
Payroll emptyPayroll = new("11/2026");
double highestEmpty = emptyPayroll.FindHighestPaidEmployee();
Console.WriteLine($"[Test 10] Lương cao nhất trong Payroll rỗng: {highestEmpty}");
