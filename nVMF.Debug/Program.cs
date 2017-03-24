using System;
using Narser.Two.Parser.Syntax.VMF.Nodes;

namespace Narser.Two.Debug
{
    class Program
    {
        static void Main(string[] args)
        {
            const string path = "D:\\Programs\\Steam\\steamapps\\common\\Counter-Strike Global Offensive\\csgo\\scripts\\items\\";
            const string file = path + "items_game.txt";

            var script = Script.Read(file);
            Console.ReadLine();
        }
    }
}
