using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ape_lifo
{
    class Procesador
    {
        Proceso primero, ultimo, temp, procesoActual;
            int contProcTerminados = 0, ciclosPendientes = 0, procPendientes = 0, procFormados = 0;

        public Procesador()
        {
            primero = null;
            ultimo = null;
            procesoActual = null;
        }

        public void push(Proceso nuevoP)
        {
            if (primero == null)
            {
                primero = nuevoP;
                ultimo = nuevoP;
                procesoActual = primero;
            }
            else
            {
                ultimo.siguiente = nuevoP;
                nuevoP.anterior = ultimo;
                nuevoP.siguiente = primero;
                ultimo = nuevoP;
                primero.anterior = ultimo;
            }

            ciclosPendientes++;
            procFormados++;
        }

        public Proceso peek()
        {
            return ultimo;
        }

        public void pop(Proceso procAEliminar)
        {
            if (procAEliminar == primero)
            {
                if (ultimo == primero)      //Si ultimo y primero son iguales, entonces sólo hay un proceso
                {
                    primero = null;
                    ultimo = null;
                }
                else
                {
                    primero = primero.siguiente;        //Si no, hay más de uno
                    primero.anterior = ultimo;
                    ultimo.siguiente = primero;
                }
            }
            else if (procAEliminar == ultimo)
            {
                if (ultimo == primero)      //Si ultimo y primero son iguales, entonces sólo hay un proceso
                {
                    primero = null;
                    ultimo = null;
                }
                else
                {
                    ultimo = ultimo.anterior;
                    ultimo.siguiente = primero;
                    primero.anterior = ultimo;
                }
            }
            else
            {
                procAEliminar.anterior.siguiente = procAEliminar.siguiente;
                procAEliminar.siguiente.anterior = procAEliminar.anterior;
            }
        }

        public void atender()
        {
            if (procesoActual != null)
            {
                procesoActual.ciclos--;

                if (procesoActual.ciclos == 0)
                {
                    pop(procesoActual);
                    contProcTerminados++;
                    ciclosPendientes--;
                }
            }
        }

        public string procPendientesYTerminados()
        {
            temp = primero;

            while (temp.siguiente != primero)
            {
                ciclosPendientes += temp.ciclos;
                procPendientes++;
                temp = temp.siguiente;
            }

            string pendientes = "Número máximo de procesos formados: " + procFormados.ToString() + Environment.NewLine +
                                "Procesos pendientes: " + procPendientes.ToString() + Environment.NewLine +
                                "Suma de los ciclos pendientes: " + ciclosPendientes.ToString() + Environment.NewLine +
                                "Procesos terminados en su totalidad:" + contProcTerminados.ToString();

            return pendientes;
        }
    }
}
