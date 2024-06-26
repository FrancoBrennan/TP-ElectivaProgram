﻿using CapaDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocios
{
    [Serializable]
    public abstract class Persona
    {
        private int dni;
        private string nombre;
        private DateTime fechaNac;
        protected List<Clase> clases;

        public Persona(int dni, string nombre, DateTime fechaNac)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.fechaNac = fechaNac;
            this.clases = new List<Clase>();
        }

        public override string ToString()
        {
            return "DNI: " + dni + " Edad: " + calcularEdad() + " Nombre: " + nombre;
        }

        public int calcularEdad()

        {

            DateTime hoy = DateTime.Today;

            int edad = hoy.Year - fechaNac.Year;

            if (hoy.Month < fechaNac.Month)

                edad--;

            else

              if (hoy.Month == fechaNac.Month && hoy.Day < fechaNac.Day)

                edad--;

            return edad;

        }

        public int Dni
        {
            get { return dni; } set { dni = value; }
        }

        public string Nombre
        {
            get { return nombre; } set { nombre = value; }
        }

        public DateTime FechaNac
        {
            get { return fechaNac; } set { fechaNac = value; }
        }

        public List<Clase> Clases
        {
            get { return clases; }
            set { clases = value; }
        }

        public abstract void agregarClase(Clase c); //Modificado para BD
        

        public abstract void quitarClase(Clase c); //Modificado para BD
        


    }
}
