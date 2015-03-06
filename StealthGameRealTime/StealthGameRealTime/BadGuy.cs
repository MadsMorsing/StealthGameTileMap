using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace StealthGameRealTime
{
    internal class BadGuy
    {
        public static Rectangle rectangle;
        private Texture2D texture;
        private Vector2 position;


        public BadGuy(Vector2 position)
        {
            this.position = position;
        }

        public BadGuy()
        {

        }

        public Vector2 Position
        {
            get { return position; }
        }

        public void Load(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("BadGuy");
        }

        public void Update(GameTime gametime)
        {
            rectangle = new Rectangle((int)position.X, (int) position.Y, texture.Width, texture.Height);
        }

        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (rectangle.TouchTopOf(newRectangle))
            {
                rectangle.Y = newRectangle.Y - rectangle.Height;
            }

            if (rectangle.TouchLeftOf(newRectangle))
            {
                // insert logic
            }
            if (rectangle.TouchRightOf(newRectangle))
            {
                // insert logic
            }
            if (rectangle.TouchButtomOf(Ninja.rectangle))
            {
                // insert logic
            }

           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }






    }


