using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lab05_2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        Texture2D character;
        Vector2 charpos;

        int direction = 0;
        int speed = 18;

        KeyboardState KeyboardState;
        KeyboardState old_KeyboardState;

        int frame;
        int totalframe;
        int framepersec;
        float timeperframe;
        float totalelapsed;
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
            character = Content.Load<Texture2D>("Char01");
            frame = 0;
            totalframe = 4;
            framepersec = 12;
            timeperframe = (float)1 / framepersec;
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState = Keyboard.GetState();
            if (KeyboardState.IsKeyUp(Keys.Down) && old_KeyboardState.IsKeyDown(Keys.Down)) 
            {
                direction = 0;
                charpos.Y = charpos.Y + speed;
                UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (KeyboardState.IsKeyUp(Keys.Up) && old_KeyboardState.IsKeyDown(Keys.Up))
            {
                direction = 3;
                charpos.Y = charpos.Y - speed;
                UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (KeyboardState.IsKeyUp(Keys.Left) && old_KeyboardState.IsKeyDown(Keys.Left))
            {
                direction = 1;
                charpos.X = charpos.X - speed;
                UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (KeyboardState.IsKeyUp(Keys.Right) && old_KeyboardState.IsKeyDown(Keys.Right))
            {
                direction = 2;
                charpos.X = charpos.X + speed;
                UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            old_KeyboardState = KeyboardState;
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(character, charpos, new Rectangle(32 * frame, 48 * direction, 32, 48), Color.White);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
        void UpdateFrame(float elapsed)
        {
            totalelapsed += elapsed;
            if (totalelapsed > timeperframe)
            {
                frame = (frame + 1) % totalframe;
                totalelapsed -= timeperframe;
            }
        }
    }
}
