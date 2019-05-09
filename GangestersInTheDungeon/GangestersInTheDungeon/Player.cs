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
            hitbox = new Rectangle(50, 500, 100, 100);
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
                move(platform, speed, 0);
            }
            if (ks.IsKeyDown(Keys.A))
            {
                left = true;
                right = false;
                move(platform, -speed, 0); 
            }
            if (ks.IsKeyDown(Keys.W) && canJump == true)
            {
                canJump = false;
                velocity.Y += -10;
                
            }
   
            velocity.Y += .3f;
            move(platform, 0, (int)velocity.Y);
        }
        private void move(List<Platform> platform, int xVal, int yVal)
        {
            int xMag = xVal;
            int yMag = yVal;
            int xDir = 1;
            int yDir = 1;
            if (xVal < 0)
            {
                xMag = -1 * xVal;
                xDir = -1;
            }
            if (yVal < 0)
            {
                yMag = -1 * yVal;
                yDir = -1;
            }
            for (int x = 0; x < xMag; x++)
            {
                hitbox.X = hitbox.X + xDir;
                bool collide = false;
                for (int i = 0; i < platform.Count; i++)
                {
                    if (hitbox.Intersects(platform[i].hitbox))
                    {
                        hitbox.X = hitbox.X -xDir; 
                        break;
                    }
                   
                }
            }
            for (int y = 0; y < yMag; y++)
            {
                hitbox.Y = hitbox.Y + yDir;
                for (int i = 0; i < platform.Count; i++)
                {
                    if (hitbox.Intersects(platform[i].hitbox))
                    {
                        hitbox.Y = hitbox.Y - yDir;
                        canJump = true;
                        velocity.Y = 0;
                        break;
                    }
                
                }
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
