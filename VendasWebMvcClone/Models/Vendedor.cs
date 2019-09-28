using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VendasWebMvcClone.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Display (Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
        public ICollection<RegistroVenda> Vendas { get; set; } = new List<RegistroVenda>();
        

        public Vendedor()
        {

        }

        public Vendedor(int id, string name, string email, DateTime birthDate, double baseSalary, Departamento departamento)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Departamento = departamento;
        }

        public void AddVendas (RegistroVenda rv)
        {
            Vendas.Add(rv);
        }

        public void RemoveVendas(RegistroVenda rv)
        {
            Vendas.Remove(rv);
        }

        public double TotalVendas(DateTime inicial, DateTime final)
        {
            return Vendas.Where(rv => rv.Date >= inicial && rv.Date <= final).Sum(rv => rv.Amount);
        }
    }

}
