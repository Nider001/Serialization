using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace Pract24
{
    [Serializable]
    public abstract class Department
    {
        public string name;
        public string info;

        public abstract void SetValue(object valueName);
        public abstract object GetValue();
    }

    [Serializable]
    public class WorkPlace : Department
    {
        string productName;

        public WorkPlace(string name, string productName)
        {
            this.name = name;
            this.info = "";
            this.productName = productName;
        }

        public WorkPlace(string name, string info, string productName)
        {
            this.name = name;
            this.info = info;
            this.productName = productName;
        }

        public override void SetValue(object productName)
        {
            this.productName = (string)productName;
        }

        public override object GetValue()
        {
            return productName;
        }
    }

    [Serializable]
    public class Facility : Department
    {
        uint upkeepCost;

        public Facility(string name, uint upkeepCost)
        {
            this.name = name;
            this.info = "";
            this.upkeepCost = upkeepCost;
        }

        public Facility(string name, string info, uint upkeepCost)
        {
            this.name = name;
            this.info = info;
            this.upkeepCost = upkeepCost;
        }

        public override void SetValue(object upkeepCost)
        {
            this.upkeepCost = (uint)upkeepCost;
        }

        public override object GetValue()
        {
            return upkeepCost;
        }
    }

    [Serializable]
    public class Employee
    {
        public string firstName;
        public string secondName;
        public Department department;
        public string position;
        public string bio;

        public Employee(string firstName, string secondName, Department department, string position, string bio)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.department = department;
            this.position = position;
            this.bio = bio;
        }
    }

    [Serializable]
    public class InfoBuffer
    {
        public int EmployeeCount;
        public int DepartmentCount;

        public InfoBuffer() { }

        public InfoBuffer(int EmployeeCount, int DepartmentCount)
        {
            this.EmployeeCount = EmployeeCount;
            this.DepartmentCount = DepartmentCount;
        }
    }

    [DataContract]
    public class Label
    {
        [DataMember]
        public string LabelName;

        public Label() { }

        public Label(string LabelName)
        {
            if (LabelName.Length <= 20)
            {
                this.LabelName = LabelName;
            }
            else
            {
                this.LabelName = LabelName.Remove(19, LabelName.Length - 20);
            }
        }
    }
}