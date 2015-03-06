#region Using Statements

using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Color = Microsoft.Xna.Framework.Color;
#endregion

namespace StealthGameRealTime
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch _spriteBatch;
        private Map _map;
        private Ninja _ninja;
        private BadGuy _badGuy1;
        BadGuy bg = new BadGuy();


        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            _map = new Map();
            _ninja = new Ninja();
            _badGuy1 = new BadGuy();
            Content.RootDirectory = "Content";
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Tiles.Content = Content;
            _map.Generate(ReadMap(), 16);
            _badGuy1.Load(Content);
            _ninja.Load(Content);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            _ninja.Update(gameTime);
            _badGuy1.Update(gameTime);
            foreach (CollisionTiles tile in _map.CollisionTiles)
            {
                _ninja.Collision(tile.Rectangle, _map.Width, _map.Height);
                _badGuy1.Collision(tile.Rectangle, _map.Width, _map.Height);
            }


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _map.Draw(_spriteBatch);
            _ninja.Draw(_spriteBatch);
            _badGuy1.Draw(_spriteBatch);
            
                

            // TODO: Add your drawing code here

            _spriteBatch.End();
            base.Draw(gameTime);
        }

        private int[,] ReadMap()
        {
            Bitmap img = new Bitmap("map.png");
            int[,] map = new int[20, 100];
            for (int i = 0; i < img.Height; i++)
            {
                for (int j = 0; j < img.Width; j++)
                {
                    System.Drawing.Color pixel = img.GetPixel(j, i);
                    if (pixel.R == 255 && pixel.B == 255 && pixel.G == 255)
                    {
                        map[i, j] = 0;
                    }
                    else if (pixel.R == 255 && pixel.B == 0 && pixel.G == 0)
                    {
                        map[i, j] = 1;
                    }
                    else if (pixel.R == 0 && pixel.B == 0 && pixel.G == 0)
                    {
                        map[i, j] = 2;
                    }
                }

            }
            return map;
        }
    }
}
