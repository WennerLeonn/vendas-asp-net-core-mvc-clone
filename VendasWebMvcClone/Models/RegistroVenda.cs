using System;
using VendasWebMvcClone.Models.Enums;

namespace VendasWebMvcClone.Models
{
    public class RegistroVenda
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public VendaStatus Status { get; set; }
        public Vendedor Vendedores { get; set; }

        public RegistroVenda()
        {

        }

        public RegistroVenda(int id, DateTime date, double amount, VendaStatus status, Vendedor vendedores)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Vendedores = vendedores;
        }
    }
}
