using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangestersInTheDungeon
{
    class Platform
    {
        public Rectangle hitbox;
        private Texture2D texture;
        public Platform(int x, int y, int width, int height)
        {
            hitbox = new Rectangle(x, y, width, height);
            texture = Game1.platformTexture;
        }
      
        public void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitbox, Color.White);
        }
    }
}
