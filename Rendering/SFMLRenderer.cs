﻿using SFML.Window;
using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;

namespace Rendering
{
    public class SFMLRenderer : IRenderer
    {
        List<(Keyboard.Key, Action)> registered = new List<(Keyboard.Key, Action)>();


        RenderWindow window;
        public void Init()
        {
            window = new RenderWindow(new VideoMode(800, 600), "Window");
            window.KeyPressed += KeyPressed;
        }

        public void Update()
        {
            window.DispatchEvents();

            var texture = new Texture("Untitled.png");

            var sprite = new Sprite(texture);
            sprite.Position = new Vector2f(10, 50);
            window.Clear(Color.Black);
            window.Draw(sprite);

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
