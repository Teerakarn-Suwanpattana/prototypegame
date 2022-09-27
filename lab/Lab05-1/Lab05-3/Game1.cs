using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lab05_3
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        Texture2D background;

        AnimatedTexture rockman;

        private const float Rotation = 0;
        private const float scale = 1.0f;
        private const float Depth = 0.5f;

        KeyboardState keyboardState;
        KeyboardState old_keyboardstate;

        bool direction = false;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            rockman = new AnimatedTexture(Vector2.Zero, Rotation, scale, Depth); 
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }
        Vector2 rockmanPos = new Vector2(0, 430);
        int frame = 8;
        int framerow = 2;
        int framepersec = 15;

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("mission");
            rockman.Load(Content, "Rockman_walk", frame, framerow, framepersec);
            rockman.Pause();
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Mouse.GetState().RightButton == ButtonState.Pressed) 
            {
                this.Exit();
            }

            // TODO: Add your update logic here
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            rockman.UpdateFrame(elapsed);

            keyboardState = Keyboard.GetState();
            if(keyboardState.IsKeyDown(Keys.Right))
            {
                if(rockman.IsPaused)
                {
                    rockman.Play();
                }
                rockmanPos.X += 5;
                direction = false;
            }
            else if(old_keyboardstate.IsKeyDown(Keys.Right) && keyboardState.IsKeyUp(Keys.Right))
            {
                rockman.Pause(0,0);
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                if (rockman.IsPaused)
                {
                    rockman.Play();
                }
                rockmanPos.X -= 5;
                direction = true;
            }
            else if (old_keyboardstate.IsKeyDown(Keys.Left) && keyboardState.IsKeyUp(Keys.Left))
            {
                rockman.Pause(0,0);
            }
            old_keyboardstate = keyboardState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            rockman.DrawFrame(spriteBatch, rockmanPos,direction);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
