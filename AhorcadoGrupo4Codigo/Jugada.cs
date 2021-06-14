using System;
using System.Collections.Generic;

namespace AhorcadoGrupo4Codigo
{
    public class Jugada
    {
        public string palabraHardcodeada;
        public string estado;
        public string nombreJugador;
        public string dificultad;
        public char[] palabraParcial;
        public string GenerarPalabra()
        {
            return palabraHardcodeada;
        }

        public bool PerteneceLetraPalabra(string letra)
        {
            if(String.IsNullOrEmpty(letra))
            {
                return false;
            }
            else if(palabraHardcodeada.Contains(letra))
            {
                return true;
            }
            return false;
        }

        public char[] MostrarPalabra(string palabra, List<char> letrasIngresadas)
        {
            char[] palabraParcial = new char[palabra.Length];
            foreach (var letra in letrasIngresadas)
            {
                int minIndex = 0;
                if (palabra.Contains(letra))
                {
                    do
                    {
                        minIndex = palabra.IndexOf(letra, minIndex);
                        if (minIndex != -1)
                        {
                            palabraParcial[minIndex] = letra;
                            minIndex++;
                        }
                    } while (minIndex != -1);
                }
            }
            return palabraParcial;
        }

        public string TerminarPartida(char[] parcial, string harcodeada)
        {
            if (new String(parcial) == harcodeada)
                estado = "Terminado";
            return estado;
        }

        public string IngresoJugador()
        {
            return nombreJugador;
        }

        public string SeleccionarDificultad()
        {
            return dificultad;
        }
    }
}
