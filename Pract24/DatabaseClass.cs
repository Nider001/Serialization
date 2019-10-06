using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace Pract24
{
    [Serializable]
    public class Database
    {
        private List<Department> departments = new List<Department>();
        private List<Employee> employees = new List<Employee>();

        public int GetDepartmentCount()
        {
            return departments.Count();
        }

        public int GetEmployeeCount()
        {
            return employees.Count();
        }

        public void AddDepartment(Department department)
        {
            if (departments.Contains(department) == false)
            {
                departments.Add(department);
            }
        }

        public void AddEmployee(Employee employee)
        {
            if (employees.Contains(employee) == false)
            {
                employees.Add(employee);
            }
        }

        public void AddEmployee(string firstName, string secondName, string departmentName, string position, string bio)
        {
            bool check = false;

            foreach (Department item in departments)
            {
                if (item.name == departmentName)
                {
                    AddEmployee(new Employee(firstName, secondName, item, position, bio));
                    check = true;
                }
            }

            if (check == false)
            {
                Department temp = new Facility(departmentName, 0);
                AddDepartment(temp);
                AddEmployee(new Employee(firstName, secondName, temp, position, bio));
            }
        }

        public void ClearDepartment(Department department)
        {
            employees.RemoveAll(n => n.department == department);
        }

        public void ClearDepartment(string departmentName)
        {
            employees.RemoveAll(n => n.department.name == departmentName);
        }

        public void RemoveDepartment(Department department)
        {
            employees.RemoveAll(n => n.department == department);
            departments.RemoveAll(n => n == department);
        }

        public void RemoveDepartment(string departmentName)
        {
            employees.RemoveAll(n => n.department.name == departmentName);
            departments.RemoveAll(n => n.name == departmentName);
        }

        public void RemoveEmployee(Employee employee)
        {
            employees.RemoveAll(n => n == employee);
        }

        public void RemoveEmployee(string firstName, string secondName, string departmentName)
        {
            employees.RemoveAll(n => ((n.firstName == firstName) && (n.secondName == secondName)
                && (n.department.name == departmentName)));
        }

        public void MoveEmployeeToDepartment(string firstName, string secondName, Department department)
        {
            if (departments.Contains(department) == false)
            {
                departments.Add(department);
            }

            foreach (Employee item in employees)
            {
                if ((item.firstName == firstName) && (item.secondName == secondName))
                {
                    item.department = department;
                    return;
                }
            }
        }

        public void MoveEmployeeToDepartment(string firstName, string secondName, string departmentName)
        {

            foreach (Employee item in employees)
            {
                if ((item.firstName == firstName) && (item.secondName == secondName))
                {
                    foreach (Department item2 in departments)
                    {
                        if (item2.name == departmentName)
                        {
                            item.department = item2;
                            return;
                        }
                    }
                }
            }
        }

        public void EditDepartmentDescription(string departmentName, string description)
        {
            foreach (Department item in departments)
            {
                if (item.name == departmentName)
                {
                    item.info = description;
                    return;
                }
            }
        }

        public List<Employee> FindBySecondName(string secondName)
        {
            return employees.Where(n => n.secondName == secondName).Select(n => n).OrderBy(n => n.position).ToList<Employee>();
        }

        public List<Employee> FindByPosition(string position)
        {
            return employees.Where(n => n.position == position).Select(n => n).OrderBy(n => n.position).ToList<Employee>();
        }

        public List<Employee> FindByPositionAndDepartment(string position, Department department)
        {
            return employees.Where(n => ((n.position == position) && (n.department == department))).Select(n => n)
                .OrderBy(n => n.position).ToList<Employee>();
        }

        public List<Employee> FindByPositionAndDepartment(string position, string departmentName)
        {
            return employees.Where(n => ((n.position == position) && (n.department.name == departmentName))).Select(n => n)
                .OrderBy(n => n.position).ToList<Employee>();
        }

        public List<Employee> FindBySecondNameAndDepartment(string secondName, Department department)
        {
            return employees.Where(n => ((n.secondName == secondName) && (n.department == department))).Select(n => n)
                .OrderBy(n => n.position).ToList<Employee>();
        }

        public List<Employee> FindBySecondNameAndDepartment(string secondName, string departmentName)
        {
            return employees.Where(n => ((n.secondName == secondName) && (n.department.name == departmentName))).Select(n => n)
                .OrderBy(n => n.position).ToList<Employee>();
        }

        public List<Employee> GetAllEmployees()
        {
            return new List<Employee>(employees).OrderBy(n => n.position).ToList<Employee>();
        }

        public List<Department> GetAllDepartents()
        {
            return new List<Department>(departments).OrderBy(n => n.name).ToList<Department>();
        }

        public Database() { }

        public Database(List<Employee> listOfEmployees)
        {
            this.employees = new List<Employee>(listOfEmployees);
            foreach (Employee item in listOfEmployees)
            {
                if (this.departments.Contains(item.department) == false)
                {
                    this.departments.Add(item.department);
                }
            }
        }

        public Database(List<Department> listOfDepartments)
        {
            this.departments = new List<Department>(listOfDepartments);
        }

        public Database(List<Department> listOfDepartments, List<Employee> listOfEmployees)
        {
            this.departments = new List<Department>(listOfDepartments);
            this.employees = new List<Employee>(listOfEmployees);
            foreach (Employee item in listOfEmployees)
            {
                if (this.departments.Contains(item.department) == false)
                {
                    this.departments.Add(item.department);
                }
            }
        }
    }
}
