using System.ComponentModel.DataAnnotations;

namespace Kiosco.Entidades
{
    public enum TipoGolosina
    {
        Chocolate,
        Caramelos,
        Galletas,
        Chicles
    }
    public enum marcaGolosina
    {
        huamallen,
        colocolo,
        menta,
        trululu
    }
    public class Golosina : Producto
    {
        public TipoGolosina Tipo { get; set; }
        public marcaGolosina Marca { get; set; }

        public override decimal calcularPrecioFinal()
        {
            if (Marca is (marcaGolosina)TipoGolosina.Chocolate)
            {
                return PrecioBase + 200;
            }
            else
            {
                return PrecioBase;
            }
        }
        public override string InformarDatosEspecifico()
        {
            return $" - TipoGolosina: {Tipo} - Marca de Golosina {Marca}"  ;
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
