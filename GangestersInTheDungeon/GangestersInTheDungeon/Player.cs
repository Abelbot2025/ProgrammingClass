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
        private bool canJump;
        private bool collide;
        Vector2 velocity;

        public Player()
        {
            canJump = true;
            right = true;
            speed = 4;
            health = 10;
            hitbox = new Rectangle(50, 450, 100, 100);
        }
        public void LoadContent(ContentManager content)
        {
            rightWalk = content.Load<Texture2D>("KevinHartRight");
            leftWalk = content.Load<Texture2D>("KevinHartLeft");
        }
        public void Update(List<Platform> platform)
        {
            KeyboardState ks = Keyboard.GetState();
       
            if (ks.IsKeyDown(Keys.D))
            {
                right = true;
                left = false;
                hitbox.X+=speed;
            }
            if (ks.IsKeyDown(Keys.A))
            {
                left = true;
                right = false;
                hitbox.X += -speed;  
            }
            if (ks.IsKeyDown(Keys.W))
            {
                hitbox.Y += -speed;
            }
          if (ks.IsKeyDown(Keys.S))
            {
                hitbox.Y += speed;
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
