using System;
using System.Threading;

namespace EngineCore
{
    public class EngineCore
    {
        Rendering.SFMLRenderer rend;

        public EngineCore()
        {
            rend = new Rendering.SFMLRenderer();
        }

        public void Init()
        {
            rend.Init();

            while (true)
            {
                Thread.Sleep(20);
                rend.Update();
            }
        }

        public void AddInputEvent(SFML.Window.Keyboard.Key key, Action action)
        {
            rend.Register(key, action);
        }
    }
}
