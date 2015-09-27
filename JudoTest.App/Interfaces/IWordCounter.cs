using System.Collections;
using System.Collections.Generic;

namespace JudoTest.App.Interfaces
{
    public interface IWordCounter
    {
        IDictionary<string,int> Count(string[] inputData);
    }
}