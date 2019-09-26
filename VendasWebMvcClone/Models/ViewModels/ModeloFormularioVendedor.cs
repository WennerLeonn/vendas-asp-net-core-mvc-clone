using System.Collections.Generic;

namespace VendasWebMvcClone.Models.ViewModels
{
    public class ModeloFormularioVendedor
    {
        public Vendedor Vendedor { get; set; }
        public ICollection<Departamento> Departamentos { get; set; }
    }
}
