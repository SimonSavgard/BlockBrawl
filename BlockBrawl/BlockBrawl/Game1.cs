﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BlockBrawl
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        GameHandler gameHandler;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void LoadContent()
        {
            gameHandler = new GameHandler(graphics, GraphicsDevice, Content);
        }
        protected override void Update(GameTime gameTime)
        {
            gameHandler.Update(gameTime);
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            gameHandler.Draw();
            base.Draw(gameTime);
        }
    }
}
