using BookWorm;
using System;

namespace Simple
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var it = from x in new Reader<string, IConfig>((something) => new Config(something))
                     from y in new Reader<>
        }
    }

    public interface IConfig {
        string SomethingImportant { get; }
    }

    public class Config : IConfig {

        public string SomethingImportant { get; }

        public Config(string SomethingImportant) {
            this.SomethingImportant = SomethingImportant;
        }
    }

    public interface IDo {
        string Do();
    }

    public class Doer : IDo {

        public Doer() { }

        public string Do() => "hello World";
    }
}
