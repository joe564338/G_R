using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using G_R_Game.G_R_Assets;
namespace G_R_Game
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        long lastUpdate = System.DateTimeOffset.Now.ToUnixTimeMilliseconds();
        long currentTime = System.DateTimeOffset.Now.ToUnixTimeMilliseconds();
        World world;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            world = new World();

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            world.LoadPlayerTexture(this.Content.Load<Texture2D>("Circleplaceholder"));
        }

        protected override void Update(GameTime gameTime)
        {
            
            Vector2 playerSpeed = Vector2.Zero;
            currentTime = System.DateTimeOffset.Now.ToUnixTimeMilliseconds();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            if(GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.D))
            {
                playerSpeed.X = 10;
            }
            else if(GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.A))
            {
                playerSpeed.X = -10;
            }
            else if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X != 0)
            {
                playerSpeed.X = 10 * GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X;
            }
            if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.W))
            {
                playerSpeed.Y = -10;
            }
            else if (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.S))
            {
                playerSpeed.Y = 10;
            }
            else if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y != 0)
            {
                playerSpeed.Y = 10 * -GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y;
            }
            world.UpdatePlayerSpeed(playerSpeed);
            
            if ((currentTime- lastUpdate) > (1000 / 60))
            {
                
                lastUpdate = currentTime;
                world.Update();
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(world.GetPlayerTexture(), new Rectangle((int)world.GetPlayerPosition().X, (int)world.GetPlayerPosition().Y, (int)world.GetPlayerTextureDimensions().X, (int)world.GetPlayerTextureDimensions().Y), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}