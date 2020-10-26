using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlnckProyect.Services
{
    public class ExtendingGenericRepo
    {
    }

    /*
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        IEnumerable<Employee> GetEmployeesByGender(string Gender);
        IEnumerable<Employee> GetEmployeesByDepartment(string Dept);
    }*/


    /*
     public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public IEnumerable<Employee> GetEmployeesByGender(string Gender)
        {
            return _context.Employees.Where(emp => emp.Gender == Gender).ToList();
        }
        public IEnumerable<Employee> GetEmployeesByDepartment(string Dept)
        {
            return _context.Employees.Where(emp => emp.Dept == Dept).ToList();
        }
    }
     
     */
}