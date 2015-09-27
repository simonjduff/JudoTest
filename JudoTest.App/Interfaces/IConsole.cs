namespace JudoTest.App.Interfaces
{
    public interface IConsole
    {
        void WriteLine(string message, params object[] formatterStrings);
    }
}