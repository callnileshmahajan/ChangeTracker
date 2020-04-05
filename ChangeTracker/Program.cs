using ChangeMapper;
using System;
using System.Reflection;

namespace ChangeTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            var employee = GetEmployeeDto();
            var employeeEntity = GetEmployeeEntity();
            // PrintObjectViaReflection(employee);
            var propertyMapper = GetPropertyMapper();
             var changeDetector = new ChangeDetector();

            Console.WriteLine(changeDetector.HasChanges(employee, employeeEntity, propertyMapper));

            Console.ReadKey();
        }

        private static IPropertyMapper GetPropertyMapper()
        {
            var propertyMapper = new PropertyMapper();
            propertyMapper.MapProperty("EmployeeId", "EmpId");
            propertyMapper.MapProperty("EmployeeName", "EmployeeName");
            propertyMapper.MapProperty("Department", "Dep");

            return propertyMapper;
        }

        private static object GetEmployeeEntity()
        {
             return new EmployeeEntity { EmpId = 1,  EmployeeName = "Nilesh Mahajan", Dep = "Healthcare" };
        }

        private static EmployeeDto GetEmployeeDto()
        {
            return new EmployeeDto { EmployeeId = 1, EmployeeName = "Nilesh Mahajan", Department = "Commodities" };
        }

        private static void PrintObjectViaReflection(EmployeeDto employee)
        {
            var properties = employee.GetType().GetProperties();

            foreach (var item in properties)
            {
                Console.WriteLine(item.GetValue(employee));
            }
        }
    }
}
