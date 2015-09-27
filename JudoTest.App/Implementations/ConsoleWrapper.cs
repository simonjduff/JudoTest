using System;
using JudoTest.App.Interfaces;

namespace JudoTest.App.Implementations
{
    public class ConsoleWrapper : IConsole
    {
        public void WriteLine(string message, params object[] formatterStrings)
        {
            Console.WriteLine(message, formatterStrings);
        }
    }
}