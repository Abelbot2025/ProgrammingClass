using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GangestersInTheDungeon
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        TitleScreen titleScreen = new TitleScreen();
        TitleScreen firstLevel = new TitleScreen();
        Player player = new Player();

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
                player.Update();
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
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
