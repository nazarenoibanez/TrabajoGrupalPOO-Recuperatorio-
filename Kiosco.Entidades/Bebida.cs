using System.ComponentModel.DataAnnotations;

namespace Kiosco.Entidades
{
    public enum MarcaB
    {
        CocaCola,
        Pepsi,
        Sprite,
        Fanta,
        AguaMineral,
        JugoNatural
    }
    public class Bebida : Producto
    {
        public MarcaB Marca { get; set; }
        public int litros { get; set; }
        public bool EsAlcoholica { get; set; }

        public override decimal calcularPrecioFinal()
        {
            if (EsAlcoholica)
            {
                return PrecioBase + 200 + (litros * 100) + 500;
            }
            else
            {
                return PrecioBase + 200 + (litros * 100);
            }
            ;
        }
        public override string InformarDatosEspecifico()
        {
            return $" - Litros {litros} - {(EsAlcoholica ? "Con alcohol" : "Sin alcohol")} - Marca de la Bebida {Marca}";
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            foreach (var error in ValidarAtributosComunes())
            {
                yield return error;
            }
            if (litros <= 0)
            {
                yield return new ValidationResult("Los litros deben ser mayores que 0");
            }
        }
    }
}
