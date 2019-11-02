using SFML.Window;
using System;
using System.Collections.Generic;

namespace Rendering
{
    public class SFMLRenderer : IRenderer
    {
        List<(Keyboard.Key, Action)> registered = new List<(Keyboard.Key, Action)>();


        Window window;
        public void Init()
        {
            window = new Window(new VideoMode(800, 600), "Window");
            window.KeyPressed += KeyPressed;
        }

        public void Update()
        {
            window.DispatchEvents();
        }

        public void Register(SFML.Window.Keyboard.Key key, Action action)
        {
            registered.Add((key, action));
        }

        private void KeyPressed(object sender, KeyEventArgs e)
        {
            foreach (var reg in registered)
            {
                if (reg.Item1 == e.Code)
                {
                    reg.Item2.Invoke();
                }
            }
        }
    }
}
