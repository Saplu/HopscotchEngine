﻿using SFML.Window;
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
        Texture texture = new Texture(Path.GetFullPath("Untitled.png"));
        Vector2f pos = new Vector2f(10, 50);
        PresentationMap map = new PresentationMap(new Texture(Path.GetFullPath("Untitled.png")));
        RenderStates ts = new RenderStates();

        RenderWindow window;
        public void Init()
        {
            window = new RenderWindow(new VideoMode(800, 600), "Window");
            window.KeyPressed += KeyPressed;
            var sprite = new Sprite(texture);
        }

        public void Update()
        {
            window.DispatchEvents();

            //var texture = new Texture("Untitled.png"); Jostain syystä tää ei toiminu mulla, heitti exceptionia.
            // Tein itelleni toimivalla tavalla tuonne ylöspäi^

            pos.X += 5;
            pos.Y += 5;

            var sprite = new Sprite(texture);
            //sprite.Position = new Vector2f(10, 50);
            sprite.Position = pos;
            window.Clear(Color.Black);
            window.Draw(sprite);
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
