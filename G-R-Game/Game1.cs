using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using VelcroPhysics.Utilities;
using G_R_Game.G_R_Assets;
using G_R_Game.G_R_Assets.Entities;
namespace G_R_Game
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        long lastUpdate = System.DateTimeOffset.Now.ToUnixTimeMilliseconds();
        long currentTime = System.DateTimeOffset.Now.ToUnixTimeMilliseconds();
        World world;
        int windowWidth = 1200;
        int windowHeight = 600;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            world = new World(windowWidth*2, windowHeight*2);

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = windowWidth;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = windowHeight;   // set this value to the desired height of your window
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ConvertUnits.SetDisplayUnitToSimUnitRatio(64f);
            // TODO: use this.Content to load your game content here
            //world.LoadPlayerTexture(this.Content.Load<Texture2D>("Circleplaceholder"));
            foreach(Entity e in world.GetEntities())
            {
                if (e.label.Equals("player"))
                {
                    
                    e.LoadTexture(this.Content.Load<Texture2D>("Circleplaceholder"));
                }
                else if (e.label.Equals("wall"))
                {
                    
                    e.LoadTexture(this.Content.Load<Texture2D>("WallTexture"));
                }
                
            }
        }

        protected override void Update(GameTime gameTime)
        {
            
            Vector2 playerImpulse = Vector2.Zero;
            currentTime = System.DateTimeOffset.Now.ToUnixTimeMilliseconds();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            if(GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.D))
            {
                playerImpulse.X = 5.5f;
            }
            else if(GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.A))
            {
                playerImpulse.X = -5.5f;
            }
            else if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X != 0)
            {
                playerImpulse.X = 5.5f * GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X;
            }
            if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.W))
            {
                playerImpulse.Y = -5.5f;
            }
            else if (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.S))
            {
                playerImpulse.Y = 5.5f;
            }
            else if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y != 0)
            {
                playerImpulse.Y = 5.5f * -GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y;
            }
            world.ApplyImpulseToPlayer(playerImpulse);
            if (Keyboard.GetState().IsKeyDown(Keys.B))
            {
                world.PlayerPrimaryAttack();
            }
            /*if ((currentTime- lastUpdate) > (1000 / 60))
            {
                
                lastUpdate = currentTime;
                world.Update();
            }*/
            world.Update((float) gameTime.ElapsedGameTime.TotalMilliseconds * 0.001f);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            foreach(Entity e in world.GetEntities())
            {
                if (e.label.Equals("wall"))
                {
                    spriteBatch.Draw(e.GetTexture(), ConvertUnits.ToDisplayUnits(e.GetPosition()) - e.GetOrigin(), null, Color.White, e.GetRotation(), e.GetOrigin(), .2f, SpriteEffects.None, 0f);
                }
                else if (e.label.Equals("player"))
                {
                    spriteBatch.Draw(e.GetTexture(), ConvertUnits.ToDisplayUnits(e.GetPosition()) -e.GetOrigin(), null, Color.White, e.GetRotation(), e.GetOrigin(), .95f, SpriteEffects.None, 0f);
                }
                
            }
            
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}