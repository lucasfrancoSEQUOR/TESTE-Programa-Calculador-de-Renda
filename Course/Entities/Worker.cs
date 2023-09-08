using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Course.Entities.Enums;

namespace Course.Entities {
    class Worker {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department DepartmentName { get; set; }
        //prop 'Contracts' é uma lista de OBJETOS da CLASSE 'HourContract'
        public List<HourContract> Contracts { get; set; } = new List<HourContract>(); //um trabalhador tem varios contratos (uma lista de contratos)


        public Worker() { }

        public Worker(string name, WorkerLevel level, double baseSalary, Department departmentName) {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            DepartmentName = departmentName;
        }

        public void AddContract(HourContract contract) {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract) {  
            Contracts.Remove(contract); 
        }

        public double Income(int year, int month) {

            double sum = BaseSalary;

            foreach(HourContract contract in Contracts) {
                if(contract.Date.Year == year && contract.Date.Month == month) {
                    sum += contract.totalValue();
                }            
            }

            return sum;
        }
    }
}
