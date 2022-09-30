using Controllers;
using Models;
using System;
using System.Collections.Generic;

namespace ProjAgendaMvc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Agenda Telefonica");

            Contato c = new()
            {
                Nome = "Baratao",
                Telefone = "123456789"
            };

            new ContatoController().InserirContato(c);

            List<Contato> l = new ContatoController().ConsultaTodos();

            foreach (var item in l)
            {
                Console.WriteLine(item);
            }
        }

    }
}
