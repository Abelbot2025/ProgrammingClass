using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace GangestersInTheDungeon
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        TitleScreen titleScreen = new TitleScreen();
        TitleScreen firstLevel = new TitleScreen();
        List<Platform> platforms = new List<Platform>();
        public static Texture2D platformTexture;
        Player player = new Player();
        public static Texture2D goldBar;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 900;
            graphics.PreferredBackBufferHeight = 600;
            graphics.IsFullScreen = false;
            titleScreen.isTrue = true;
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            titleScreen.LoadContnent(Content , "Title");
            firstLevel.LoadContnent(Content, "white guy room");
            player.LoadContent(Content);

            platformTexture = Content.Load<Texture2D>("Platform");
            goldBar = Content.Load<Texture2D>("gold bar");
        }
        protected override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (titleScreen.isTrue == true)
            {
                if (ks.IsKeyDown(Keys.Enter))
                {
                    titleScreen.isTrue = false;
                    firstLevel.isTrue = true;
                }
            }
            else if (firstLevel.isTrue == true)
            {
                AddPlatform(500, 565, 450, 5);
                AddPlatform(0,600, 1000, 1);
                AddPlatform(0, 450, 450, 5);
                AddPlatform(0, 315, 400, 5);
                AddPlatform(450, 200, 450, 5);
                player.Update(platforms);
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            if (titleScreen.isTrue == true)
            {
                titleScreen.Draw(spriteBatch);
            }
            else if (firstLevel.isTrue == true)
            {
                firstLevel.Draw(spriteBatch);
                player.Draw(spriteBatch);
            }
            foreach (Platform p in platforms)
            {
                p.Draw(spriteBatch);
            }
            base.Draw(gameTime);
            spriteBatch.End();
        }
        public void AddPlatform(int x,int y, int width , int height)
        {
            platforms.Add(new Platform(x, y, width, height));
        }
        public void SetTexture()
        {
        }
    }
}
