
using System;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var engine = new EngineCore.EngineCore();

            engine.AddInputEvent(SFML.Window.Keyboard.Key.Space, Foo);

            engine.Init();

        }

        static void Foo()
        {
            Console.Write("Foo");
        }
    }
}
