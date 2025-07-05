using System.ComponentModel.DataAnnotations;

namespace Kiosco.Entidades
{
    public enum MarcaCigarrillo
    {
        Marlboro,
        Camel,
        LuckyStrike,
        PallMall,
        Chesterfield
    }
    public class Cigarrillo: Producto
    {
        private int CantidadPorAtado;

        public int Cantidad
        {
            get { return CantidadPorAtado; }
            set
            {
                if (value == 10 || value == 20)
                {
                    CantidadPorAtado = value;
                }
                else
                {
                    throw new ArgumentException("La cantidad por atado debe ser 10 o 20.");
                }
            }
        }
        public bool esImportado { get; set; }
        public override decimal calcularPrecioFinal()
        {
            if (esImportado)
            {
                return PrecioBase + 1000;
            }
            else
            {
                return PrecioBase;
            }
        }
        public MarcaCigarrillo Marca { get; set; }

        public override string InformarDatosEspecifico()
        {
            return $" - Marca: {Marca} - Cantidad por atado: {CantidadPorAtado} - {(esImportado ? "Importado" : "Nacional")}";
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            foreach (var error in ValidarAtributosComunes())
            {
                yield return error;
            }
        }
    }
}
