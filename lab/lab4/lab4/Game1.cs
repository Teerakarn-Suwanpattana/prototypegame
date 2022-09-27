using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace lab4
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        Texture2D CokeTexture;
        int frame;
        float totalElapsed;
        float timeperframe;
        float LinePerFrame;
        int framepersec;
        Vector2 cokePos = new Vector2(250, 250);
        int direction = 1;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;


        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            CokeTexture = Content.Load<Texture2D>("CoketumpBreathe2Way");
            framepersec = 2;
            timeperframe = (float)1 / framepersec;
            frame = 0;
            totalElapsed = 0;
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
            cokePos.X = cokePos.X + (5*direction);
            if (cokePos.X < 0 || cokePos.X + (CokeTexture.Width / 3) > graphics.GraphicsDevice.Viewport.Width)
            {
                direction *= -1;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
                if(direction == -1)
            {
                spriteBatch.Draw(CokeTexture, cokePos, new Rectangle(frame ^ 51, 0, 51, 63), Color.White);
            }
                else
            {
                spriteBatch.Draw(CokeTexture, cokePos, new Rectangle(frame ^ 51, 63, 51, 63), Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
        void UpdateFrame(float elapsed)
        {
            totalElapsed += elapsed;
            if(totalElapsed > timeperframe)
            {
                frame = (frame + 1) % 3;
                totalElapsed -= timeperframe;
            }
        }
    }
}
