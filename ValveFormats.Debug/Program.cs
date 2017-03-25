using System;
using System.IO;
using ValveFormats;

namespace Narser.Two.Debug
{
    class Program
    {
        static void Main(string[] args)
        {
            const string path = "D:\\Programs\\Steam\\steamapps\\common\\Counter-Strike Global Offensive\\csgo\\scripts\\items\\";
            const string file = path + "items_game.txt";

            var script = ValveSerialize.Deserialize(File.ReadAllText(file));

            Console.ReadLine();
        }
    }
}
