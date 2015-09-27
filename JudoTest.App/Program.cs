using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JudoTest.App.Implementations;

namespace JudoTest.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new JudoTestApp(new FileService(), new WordSplitter(), new WordCounter(), new ConsoleWrapper());

            app.Run("fileinput.txt");
        }
    }
}
