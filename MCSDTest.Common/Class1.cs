using System;
using Newtonsoft.Json;

namespace MCSDTest.Common
{
    public static class TestHelpers
    {
        public static void ConsoleWriteAsJson(this object obj)
        {
            var str = JsonConvert.SerializeObject(obj);
            Console.WriteLine(obj);
        }
    }
}
