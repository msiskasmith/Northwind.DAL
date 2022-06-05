using System;
using System.Collections.Generic;

#nullable disable

namespace Northwind.DAL.EFModels
{
    public partial class Employee
    {
        public Employee()
        {
            InverseEmployeeSupervisor = new HashSet<Employee>();
            Orders = new HashSet<Order>();
        }

        public string EmployeeId { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeTitle { get; set; }
        public string EmployeeTitleOfCourtesy { get; set; }
        public DateTime? EmployeeBirthDate { get; set; }
        public DateTime? EmployeeHireDate { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeCity { get; set; }
        public short? RegionId { get; set; }
        public string EmployeePostalCode { get; set; }
        public string EmployeeCountry { get; set; }
        public string EmployeeHomePhone { get; set; }
        public string EmployeeExtension { get; set; }
        public byte[] EmployeePhoto { get; set; }
        public string EmployeeNotes { get; set; }
        public string EmployeeSupervisorId { get; set; }
        public string EmployeePhotoPath { get; set; }

        public virtual Employee EmployeeSupervisor { get; set; }
        public virtual Region Region { get; set; }
        public virtual ICollection<Employee> InverseEmployeeSupervisor { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
