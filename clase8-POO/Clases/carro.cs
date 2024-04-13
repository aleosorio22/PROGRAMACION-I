using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clase8_POO.Clases
{
    public class Carro
    {
        public string Marca { get; }
        public int Modelo { get;}
        public string Color { get; set; }
        public string Owner { get; set; }
        private int Encendido = 0;
        private int velocidad_actual = 0;
        public int MAXVELOCIDAD {  get; set; }

        public Carro(string m, int model)
        {
            Marca = m;
            Modelo = model;
        }

        public int Acelerar()
        {
            if (Encendido == 0)
            {
                return 0;
            }
            velocidad_actual += 10;
            return velocidad_actual;
        }

        public string EncenderCarro()
        {
            if (Encendido != 1)
            {
                Encendido = 1;
            }
            return "encendido";
        }

        public string ApagarCarro()
        {
            if (velocidad_actual != 0)
            {
                Encendido = 0;
            }
            return "Carro apagado";
   
        }
    }
}
