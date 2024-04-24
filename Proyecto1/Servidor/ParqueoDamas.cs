using Proyecto1.models_;
using System.Collections;
using System.Collections.Generic;

namespace Proyecto1.Servidor
{
    public class ParqueoDamas : IEnumerable
    {
        public Nodo? PrimerNodo { get; private set; }
        public Nodo? UltimoNodo { get; private set; }

        public bool ListaVacia()
        {
            return PrimerNodo == null;
        }

        public IEnumerator GetEnumerator()
        {
            Nodo? nodoActual = PrimerNodo;
            while (nodoActual != null)
            {
                yield return nodoActual;
                nodoActual = nodoActual.Referencia;
            }
        }

        public void IngresarVehiculo(Vehiculo vehiculo)
        {
            Nodo nuevoNodo = new Nodo(vehiculo);

            if (ListaVacia())
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                UltimoNodo.Referencia = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
        }

        public Vehiculo SalirVehiculo()
        {
            if (ListaVacia())
            {
                throw new InvalidOperationException("El parqueo está vacío.");
            }

            Vehiculo vehiculo = (Vehiculo)PrimerNodo.Informacion;
            PrimerNodo = PrimerNodo.Referencia;

            if (PrimerNodo == null)
            {
                UltimoNodo = null;
            }

            return vehiculo;
        }

        public string ListarVehiculos()
        {
            var resultado = "Vehículos en parqueo (FIFO):\n";
            foreach (Nodo nodo in this)
            {
                resultado += nodo.ToString() + "\n";
            }

            return resultado;
        }
    }
}





