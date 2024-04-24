using Proyecto1.models_;
using System.Collections;
using System.Collections.Generic;

namespace Proyecto1.Servidor
{
    // La clase ParqueoCaballeros implementa la interfaz IEnumerable para permitir la iteración.
    public class ParqueoCaballeros : IEnumerable
    {
        // Referencias a los nodos que representan el primer y último elemento de la lista enlazada.
        public Nodo PrimerNodo { get; private set; }
        public Nodo UltimoNodo { get; private set; }

        // Método para verificar si la lista está vacía. Devuelve true si PrimerNodo es null.
        public bool ListaVacia()
        {
            return PrimerNodo == null;
        }

        // Método para ingresar un nuevo vehículo al parqueo.
        // Como el parqueo es LIFO, se inserta al inicio de la lista enlazada.
        public void IngresarVehiculo(Vehiculo vehiculo)
        {
            Nodo nuevoNodo = new Nodo(vehiculo);

            if (ListaVacia())
            {
                // Si la lista está vacía, el nuevo nodo se convierte en el primer y el último nodo.
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                // De lo contrario, el nuevo nodo apunta al actual PrimerNodo, y se convierte en el nuevo PrimerNodo.
                nuevoNodo.Referencia = PrimerNodo;
                PrimerNodo = nuevoNodo;
            }
        }

        // Método para sacar el primer vehículo del parqueo.
        // Si el parqueo está vacío, lanza una excepción.
        public Vehiculo SalirVehiculo()
        {
            if (ListaVacia())
            {
                throw new InvalidOperationException("El parqueo está vacío.");
            }

            // Obtenemos la información del primer nodo, lo removemos y actualizamos el PrimerNodo.
            Vehiculo vehiculo = (Vehiculo)PrimerNodo.Informacion;
            PrimerNodo = PrimerNodo.Referencia;

            // Si después de remover, el PrimerNodo es null, también actualizamos UltimoNodo.
            if (PrimerNodo == null)
            {
                UltimoNodo = null;
            }

            return vehiculo; // Devolvemos el vehículo que salió.
        }

        // Método para sacar un vehículo por emergencia dado su placa.
        public Vehiculo SalirPorEmergencia(string placa)
        {
            if (ListaVacia())
            {
                throw new InvalidOperationException("El parqueo está vacío.");
            }

            Nodo nodoActual = PrimerNodo;
            Nodo nodoAnterior = null;

            // Recorremos la lista para encontrar el nodo con la placa específica.
            while (nodoActual != null && ((Vehiculo)nodoActual.Informacion).Placa != placa)
            {
                nodoAnterior = nodoActual;
                nodoActual = nodoActual.Referencia;
            }

            // Si no encontramos el nodo, lanzamos una excepción.
            if (nodoActual == null)
            {
                throw new InvalidOperationException("El vehículo con la placa especificada no se encontró.");
            }

            // Eliminamos el nodo encontrado.
            if (nodoAnterior != null)
            {
                // Si no es el primer nodo, actualizamos la referencia del nodo anterior.
                nodoAnterior.Referencia = nodoActual.Referencia;
            }
            else
            {
                // Si es el primer nodo, actualizamos el PrimerNodo.
                PrimerNodo = nodoActual.Referencia;
            }

            // Si el nodo eliminado era el último, actualizamos UltimoNodo.
            if (nodoActual == UltimoNodo)
            {
                UltimoNodo = nodoAnterior;
            }

            return (Vehiculo)nodoActual.Informacion; // Devolvemos el vehículo que salió por emergencia.
        }

        // Método para listar todos los vehículos en el parqueo.
        // Se utiliza un foreach para recorrer todos los nodos.
        public string ListarVehiculos()
        {
            var resultado = "Vehículos en parqueo (LIFO):\n";
            foreach (Nodo nodo in this)
            {
                resultado += ((Vehiculo)nodo.Informacion).ToString() + "\n";
            }

            return resultado; // Devuelve la lista de vehículos en formato de texto.
        }

        // Método para implementar IEnumerable y permitir la iteración con foreach.
        public IEnumerator GetEnumerator()
        {
            Nodo nodoActual = PrimerNodo; // Comenzamos desde el primer nodo.
            while (nodoActual != null)
            {
                yield return nodoActual; // Devolvemos el nodo actual.
                nodoActual = nodoActual.Referencia; // Pasamos al siguiente nodo.
            }
        }
    }
}



