using SFML.Window;
using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using System.IO;
using GameObjects;

namespace Rendering
{
    public class SFMLRenderer : IRenderer
    {
        List<(Keyboard.Key, Action)> registered = new List<(Keyboard.Key, Action)>();
        PresentationMap map = new PresentationMap(new Texture(Path.GetFullPath("Untitled.png")), 
            new Texture(Path.GetFullPath("background.png")), new Texture(Path.GetFullPath("Player.png")));
        RenderStates ts = new RenderStates();
        GameTime gameTime = new GameTime();

        RenderWindow window;
        public void Init()
        {
            window = new RenderWindow(new VideoMode(800, 480), "Window");
            window.KeyPressed += KeyPressed;
        }

        public void Update()
        {
            window.DispatchEvents();

            //var texture = new Texture("Untitled.png"); Jostain syystä tää ei toiminu mulla, heitti exceptionia.
            // Tein itelleni toimivalla tavalla tuonne ylöspäi^
            gameTime.Update();
            map.Update(Convert.ToInt32(gameTime.SinceLastUpdate));

            window.Clear(Color.Black);
            map.Draw(window, ts);

            window.Display();
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
