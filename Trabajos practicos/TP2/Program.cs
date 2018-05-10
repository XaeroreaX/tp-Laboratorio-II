﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entidades;
using Productos;


namespace TP2
{
    class Program
    {
        static void Main(string[] args)
        {

            ElChanguito.Changuito changuito;

            List<Producto> productos;

            productos = new List<Producto>();

            changuito = new ElChanguito.Changuito(5);

            productos.Add(new Dulce(EMarca.Sancor, "ASD012", ConsoleColor.Black));
            productos.Add(new Dulce(EMarca.Ilolay, "ASD913", ConsoleColor.Red));
            productos.Add(new Leche(EMarca.Pepsico, "HJK789", ConsoleColor.White));
            productos.Add(new Leche(EMarca.Serenisima, "IOP582", ConsoleColor.Blue, ETipo.Descremada));
            productos.Add(new Snack(EMarca.Campagnola, "QWE968", ConsoleColor.Gray));

            foreach(Producto element in productos)
            {
                changuito += element;

            }

            Console.Write(changuito.ToString());

            Console.ReadKey();



        }
    }
}
