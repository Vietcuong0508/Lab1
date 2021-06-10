using System;
using System.Collections.Generic;

namespace Lap3.Ex1
{
    public class Atom
    {
        public int AtomicNumber { get; set; }
        public string AtomicSymbol { get; set; }
        public string FullName { get; set; }
        public float AtomicWeight { get; set; }

        private List<Atom> _atoms = new List<Atom>();

        public bool Accept()
        {
            while (true)
            {
                var atom = new Atom();
                Console.WriteLine("Atomic Information");
                Console.WriteLine("==================");
                Console.WriteLine("Enter atomic number: ");
                atom.AtomicNumber = int.Parse(Console.ReadLine());
                if (atom.AtomicNumber == 0)
                {
                    Console.WriteLine("No Sym Name Weight");
                    return false;
                }
                Console.WriteLine("Enter symbol: ");
                atom.AtomicSymbol = Console.ReadLine();
                Console.WriteLine("Enter full name: "); 
                atom.FullName = Console.ReadLine();
                Console.WriteLine("Enter atomic weight: ");
                atom.AtomicWeight = float.Parse(Console.ReadLine());
                _atoms.Add(atom);
                Console.WriteLine("1. Continue");
                Console.WriteLine("2. Stop");
                var choice = int.Parse(Console.ReadLine());
                if (choice != 1)
                {
                    break;
                }
            }
            return true;
        }

        public void Display()
        {
            for (int i = 0; i < _atoms.Count; i++)
            {
                var atoms = _atoms[i];
                if (_atoms.Count > 10)
                {
                    Console.WriteLine("Sorry ! program only accepts information for up to 10 atomic elements");
                    return;
                }

                Console.WriteLine("------------------");
                Console.WriteLine($"{atoms.AtomicNumber} {atoms.AtomicSymbol} {atoms.FullName} {atoms.AtomicWeight}");
            }
        }
    }
}