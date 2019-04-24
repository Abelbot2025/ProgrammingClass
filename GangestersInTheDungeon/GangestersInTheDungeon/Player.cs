using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace GangestersInTheDungeon
{
    class Player
    {
        private int speed;
        private int health;
        private Rectangle hitbox;
        private Texture2D rightWalk;
        private Texture2D leftWalk;
        private bool right;
        private bool left;
        public Player()
        {
            right = true;
            speed = 4;
            health = 10;
            hitbox = new Rectangle(0, 500, 100, 100);
        }
        public void LoadContent(ContentManager content)
        {
            rightWalk = content.Load<Texture2D>("KevinHartRight");
            leftWalk = content.Load<Texture2D>("KevinHartLeft");
        }
        public void Update()
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.D))
            {
                hitbox.X += speed;
                right = true;
                left = false;
            }
            if (ks.IsKeyDown(Keys.A))
            {
                hitbox.X -= speed;
                left = true;
                right = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (right == true)
            {
                spriteBatch.Draw(rightWalk, hitbox, Color.White);
            }
            else if (left == true)
            { spriteBatch.Draw(leftWalk, hitbox, Color.White); }
        }
    }
}
