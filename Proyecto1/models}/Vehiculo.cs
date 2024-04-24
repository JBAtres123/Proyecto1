namespace Proyecto1.models_
{
     public class Vehiculo
        {
            public string Placa { get; set; }
            public string Propietario { get; set; }
            public string Tipo { get; set; } // Puede ser "dama" o "caballero"

            public Vehiculo(string placa, string propietario, string tipo)
            {
                Placa = placa;
                Propietario = propietario;
                Tipo = tipo;
            }

            public override string ToString()
            {
                return $"Placa: {Placa}, Propietario: {Propietario}, Tipo: {Tipo}";
            }
        }
    }

