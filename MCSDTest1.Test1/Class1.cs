using System;

namespace MCSDTest1.Test1
{
    /// <summary>
    /// Internal property cannot be accessed by other assemblies
    /// </summary>
    public class Employee
    {
        protected string EmployeeType { get; set; }
    }

    public class Contractor : Employee
    {
        public void PrintEmployeeType()
        {
            Console.WriteLine(EmployeeType);
        }
    }

    public class AnotherClass
    {
        /// <summary>
        /// The EmployeeType property value must be accessed and modified
        ///  only by code within the Employee class or within a class derived
        ///  from the Employee class.You need to ensure that the implementation
        ///  of the EmployeeType property meets the requirements
        /// </summary>
        public void AnotherClassTest()
        {
            var employee = new Employee();
            //Console.WriteLine(employee.EmployeeType);
            //test passed
        }
    }
}
