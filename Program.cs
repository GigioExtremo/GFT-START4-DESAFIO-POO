using System;
using DesafioPOO.src.entities;


namespace DesafioPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            // var heroi = new Hero("Arus", "Knight", 32, 539, 200);
            // Erro, pois todo herói deve ter uma classe

            Console.WriteLine("\n-->Arus encounter a Zombie!\n");

            var arus = new Knight("Arus", "Knight", 32, 300, 100, 439, 200);

            Console.WriteLine(arus + "\n");
            arus.MPChange(10);
            Console.WriteLine(arus.Attack(4));
            Console.WriteLine($"--> {arus.Name} got attacked by Zombie!\n");
            arus.HPChange(-500);

            Console.WriteLine("--> Arus now is having an transformation! Arus transformed into Black Arus!\n");
            
            arus.RenameHero("Black Arus");
            Wizard blackMageArus = new Wizard(arus, "Black Mage");
            
            blackMageArus.HPChange(999);
            blackMageArus.MPChange(999);

            Console.WriteLine(blackMageArus);
            Console.WriteLine($"--> {arus.Name} got attacked by Zombie!\n");
            arus.HPChange(0);
            Console.WriteLine(blackMageArus.Attack("Ultima", 999, "Zombie"));
            
            Console.WriteLine($"--> Zombie died!\n");
            Console.WriteLine("--> Victory!\n");

            Console.WriteLine(blackMageArus.LevelUp(2));
            
        }
    }
}
