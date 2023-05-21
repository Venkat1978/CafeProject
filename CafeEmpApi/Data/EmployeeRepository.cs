using Microsoft.EntityFrameworkCore;

namespace CafeEmpApi.Data
{
    internal static class Employees
    {
        internal async static Task<List<Employee>> GetEmployeesAsync()
        {
            using (var db = new AppDBContext())
            {
                return await db.Employees.ToListAsync();
            }
        }

        internal async static Task<Employee> GetEmployeeByIdAsync(int ID)
        {
            using (var db = new AppDBContext())
            {
                return await db.Employees
                    .FirstOrDefaultAsync(Employee => Employee.Id == ID);
            }
        }

        internal async static Task<bool> CreateEmployeeAsync(Employee EmployeeToCreate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    await db.Employees.AddAsync(EmployeeToCreate);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> UpdateEmployeeAsync(Employee EmployeeToUpdate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    db.Employees.Update(EmployeeToUpdate);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        internal async static Task<bool> DeleteEmployeeAsync(int Id)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    Employee EmployeeToDelete = await GetEmployeeByIdAsync(Id);

                    db.Remove(EmployeeToDelete);

                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}
