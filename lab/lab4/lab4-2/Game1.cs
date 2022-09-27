using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace lab4_2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private AnimatedTexture spriteTexture;
        private AnimatedTexture spriteTexture2;
        private const float Rotation = 0;
        private const float scale = 1.0f;
        private const float Depth = 0.5f;

        bool animate_stop = false;

        Texture2D Background;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            spriteTexture = new AnimatedTexture(Vector2.Zero, Rotation, scale, Depth);
            spriteTexture2 = new AnimatedTexture(Vector2.Zero, Rotation, scale, Depth);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }
        private Vector2 xPos = new Vector2(0, 430);
        private const int Frames = 8;
        private const int FramesRow = 2;
        private const int FramesPerSec = 15;

        private Vector2 xPos2 = new Vector2(650, 430);
        private const int Frames2 = 10;
        private const int FramesRow2 = 1;
        private const int FramesPerSec2 = 15;

        protected override void LoadContent() 
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteTexture.Load(Content, "Rockman_walk", Frames, FramesRow, FramesPerSec);
            spriteTexture2.Load(Content, "Rockman_warp", Frames2, FramesRow2, FramesPerSec2);
            Background = Content.Load<Texture2D>("mission");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(xPos.X<xPos2.X)
            {   
                spriteTexture.UpdateFrame(elapsed);
                xPos.X = xPos.X + 3;
            }
            else
            {
                spriteTexture2.UpdateFrame(elapsed);
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(Background, new Vector2(0, 0), Color.White);
            if(xPos.X < xPos2.X)
            {
                spriteTexture.DrawFrame(spriteBatch, xPos);
            }
            else
            {
                if (animate_stop == false)
                {
                    if(spriteTexture2.Frame < 9)
                    {
                        spriteTexture2.DrawFrame(spriteBatch, xPos2);
                    }
                    else
                    {
                        spriteTexture2.DrawFrame(spriteBatch, xPos2);
                        spriteTexture2.Pause();
                        animate_stop = true;
                    }
                }

            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
