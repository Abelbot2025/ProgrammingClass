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
    class TitleScreen
    {
        private Rectangle hitbox;
        private Texture2D texture;
        public bool isTrue;
        public TitleScreen()
        {
            hitbox = new Rectangle(0, 0, 900, 600);
        }
        public void LoadContnent(ContentManager content, string Texture)
        {
           texture = content.Load<Texture2D>(Texture);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitbox, Color.White);
        }
    }
}
