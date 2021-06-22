using AhorcadoGrupo4Codigo;
using System;
using System.Collections.Generic;
using Xunit;

namespace AhorcadoGrupo4
{
    public class AhorcadoTest
    {
        //Ingreso Jugador

        //Jugador anonimo
        [Fact]
        public void JugadorAnonimo()
        {
            //Arrange
            var juego = new Jugada();
            juego.nombreJugador = "Anónimo";
            //Act
            var jugador = juego.IngresoJugador();
            //Assert
            Assert.Equal(juego.nombreJugador, jugador);
        }


        //Seleccionar dificultad

        //Jugada sin dificultad 
        [Fact]
        public void JugadaSinDificultad()
        {
            //Arrange
            var juego = new Jugada();
            juego.dificultad = "SinDificultad";
            //Act
            var dificultad = juego.SeleccionarDificultad();
            //Assert
            Assert.Equal(juego.dificultad, dificultad);
        }


        //Generar palabra hardcodeada

        //Probar palabra generada
        [Fact]
        public void ProbarPalabraGenerada()
        {
            //Arrange
            var juego = new Jugada();
            juego.palabraHardcodeada = "gato";
            //Act
            string palabraGenerada = juego.GenerarPalabra();
            //Assert
            Assert.Equal(juego.palabraHardcodeada, palabraGenerada);
        }

        //Ingresar letra y verificar si pertenece a la palabra

        //String vacio
        [Fact]
        public void ProbarIngresarLetraStringVacio()
        {
            //Arrange
            string letra = string.Empty;
            var juego = new Jugada();
            juego.palabraHardcodeada = "gato";
            //Act
            bool pertenece = juego.PerteneceLetraPalabra(letra);
            //Assert
            Assert.False(pertenece);
        }
        //Letra pertenece
        [Fact]
        public void ProbarIngresarLetraPertenece()
        {
            //Arrange
            string letra = "g";
            var juego = new Jugada();
            juego.palabraHardcodeada = "gato";
            //Act
            bool pertenece = juego.PerteneceLetraPalabra(letra);
            //Assert
            Assert.True(pertenece);
        }
        //Letra no pertenece
        [Fact]
        public void ProbarIngresarLetraNoPertenece()
        {
            //Arrange
            string letra = "h";
            var juego = new Jugada();
            juego.palabraHardcodeada = "gato";
            //Act
            bool pertenece = juego.PerteneceLetraPalabra(letra);
            //Assert
            Assert.False(pertenece);
        }

        //Mostrar palabra

        //Comparar la palabra generada con la parcial
        [Fact]
        public void CompararPalabra()
        {
            //Arrange
            var juego = new Jugada();
            juego.palabraHardcodeada = "gatoga";
            juego.palabraParcial = new char[juego.palabraHardcodeada.Length];
            juego.palabraParcial[0] = 'g';
            juego.palabraParcial[1] = 'a';
            juego.palabraParcial[4] = 'g';
            juego.palabraParcial[5] = 'a';
            juego.letrasIngresadas = new List<char>() { 'e', 'p', 'g', 'a' };
            //Act
            var palabraParcial = juego.MostrarPalabra(juego.palabraHardcodeada, juego.letrasIngresadas);
            //Assert
            Assert.Equal(juego.palabraParcial, palabraParcial);
        }

        //Terminar la partida

        //Partida terminada
        [Fact]
        public void PartidaTerminada()
        {
            //Arrange
            var juego = new Jugada();
            juego.palabraHardcodeada = "gato";
            juego.palabraParcial = new char[juego.palabraHardcodeada.Length];
            juego.palabraParcial[0] = 'g';
            juego.palabraParcial[1] = 'a';
            juego.palabraParcial[2] = 't';
            juego.palabraParcial[3] = 'o';
            juego.estado = "En curso";
            var estadoFinal = "Terminado";
            //Act
            var estadoPartida = juego.TerminarPartida(juego.palabraParcial, juego.palabraHardcodeada);
            //Assert
            Assert.Equal(estadoFinal, estadoPartida);
        }

        //Partida no terminada
        [Fact]
        public void PartidaNoTerminada()
        {
            //Arrange
            var juego = new Jugada();
            juego.palabraHardcodeada = "gato";
            juego.palabraParcial = new char[juego.palabraHardcodeada.Length];
            juego.palabraParcial[0] = 'g';
            juego.palabraParcial[1] = 'a';
            juego.estado = "En curso";
            //Act
            var estadoPartida = juego.TerminarPartida(juego.palabraParcial, juego.palabraHardcodeada);
            //Assert
            Assert.Equal(juego.estado, estadoPartida);
        }

        //Generar palabra random
        [Fact]
        public void PalabraGeneradaRandom()
        {
            //Arrange
            var juego = new Jugada();

            //Act
            string palabraGenerada = juego.GenerarPalabraRandom();

            //Assert
            Assert.NotEmpty(palabraGenerada);
        }

        //Listar Letras usadas

        //Jugador no ingreso ninguna letra
        [Fact]
        public void NingunaLetraIngresada()
        {
            //Arrange
            var juego = new Jugada();

            //Act
            List<char> lista = juego.ListaLetrasIngresadas();

            //Assert
            Assert.Empty(lista);
        }

        //Jugador ingreso letras
        [Fact]
        public void LetrasIngresada()
        {
            //Arrange
            var juego = new Jugada();
            juego.letrasIngresadas = new List<char>() { 'e', 'p', 'g', 'a' };

            //Act
            List<char> lista = juego.ListaLetrasIngresadas();

            //Assert
            Assert.NotEmpty(lista);
        }

        //Contar cantidad de fallos

        //Cantidad de fallos 0
        [Fact]
        public void NingunFallo()
        {
            //Arrange
            var juego = new Jugada();
            int fallos = 0;

            //Act
            int cantidadfallos = juego.CantidadFallos();

            //Assert
            Assert.Equal(fallos, cantidadfallos);
        }

        //Cantidad de fallos 7
        [Fact]
        public void LimiteFallos()
        {
            //Arrange
            var juego = new Jugada();
            int fallos = 7;
            juego.palabraHardcodeada = "gato";
            juego.letrasIngresadas = new List<char>() { 'e', 'p', 'x', 'q', 'w', 'j', 'y' };

            //Act
            juego.MostrarPalabra(juego.palabraHardcodeada, juego.letrasIngresadas);
            int cantidadfallos = juego.CantidadFallos();

            //Assert
            Assert.Equal(fallos, cantidadfallos);
        }

        //Mostrar score final
        //Juego perfecto
        [Fact]
        public void JuegoPerfecto()
        {
            //Arrange
            var juego = new Jugada();
            juego.palabraHardcodeada = "gato";
            juego.letrasIngresadas = new List<char>() { 'g', 'a', 't', 'o'};
            int scoreFinal = 100;

            //Act
            juego.MostrarPalabra(juego.palabraHardcodeada, juego.letrasIngresadas);
            int score = juego.CalcularScore();

            //Assert
            Assert.Equal(scoreFinal, score);
        }

        //Juego con fallos
        [Fact]
        public void JuegoConFallos()
        {
            //Arrange
            var juego = new Jugada();
            juego.palabraHardcodeada = "gato";
            juego.letrasIngresadas = new List<char>() { 'g', 'h', 't', 's', 'a', 'r', 'o'};
            int scoreFinal = 70;

            //Act
            juego.MostrarPalabra(juego.palabraHardcodeada, juego.letrasIngresadas);
            int score = juego.CalcularScore();

            //Assert
            Assert.Equal(scoreFinal, score);
        }

        //Juego perdido
        [Fact]
        public void JuegoPerdido()
        {
            //Arrange
            var juego = new Jugada();
            juego.palabraHardcodeada = "gato";
            juego.letrasIngresadas = new List<char>() { 'e', 'h', 'y', 's', 'u', 'r', 'i' };
            int scoreFinal = 0;

            //Act
            juego.MostrarPalabra(juego.palabraHardcodeada, juego.letrasIngresadas);
            int score = juego.CalcularScore();

            //Assert
            Assert.Equal(scoreFinal, score);
        }

    }
}
