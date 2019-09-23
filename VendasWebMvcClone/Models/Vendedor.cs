using System;
using System.Collections.Generic;
using System.Linq;

namespace VendasWebMvcClone.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Departamento Departamento { get; set; }
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
