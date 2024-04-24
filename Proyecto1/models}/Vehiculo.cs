namespace Proyecto1.models_
{
    public class Vehiculo
    {
        public string Placa { get; set; }
        public string Propietario { get; set; }
        public string Tipo { get; set; } // Puede ser "dama" o "caballero"
        public string Modelo { get; set; } // Nuevo campo para el modelo del vehículo
        public string Color { get; set; } // Nuevo campo para el color del vehículo

        public Vehiculo(string placa, string propietario, string tipo, string modelo, string color)
        {
            Placa = placa;
            Propietario = propietario;
            Tipo = tipo;
            Modelo = modelo;
            Color = color;
        }

        public override string ToString()
        {
            return $"Placa: {Placa}, Propietario: {Propietario}, Tipo: {Tipo}, Modelo: {Modelo}, Color: {Color}";
        }
    }
}


