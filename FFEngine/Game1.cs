
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Tiled_Engine;


namespace FFEngine
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {        
        static int scaling = 4;
        static int screenWidth = 1024;
        static int screenHeight = 960;
        static bool isFullScreen = false;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;                
        Player player;
        SpriteFont debugFont;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.IsFullScreen = isFullScreen;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {          

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);          

            player = new Player(new Vector2(12,16), 16, 16, Content.Load<Texture2D>("Player"), 2);

           

            Camera.ViewPortWidth = screenWidth;
            Camera.ViewPortHeight = screenHeight;
            Camera.Scaleing = scaling;

           

            MapManager.Initialize(player, @"Content\", graphics.GraphicsDevice);

            Camera.WorldRectangle = new Rectangle(0, 0,
                                                  MapManager.CurrentMap.TileWidth * MapManager.CurrentMap.MapWidth,
                                                  MapManager.CurrentMap.TileHeight * MapManager.CurrentMap.MapHeight);

            debugFont = Content.Load<SpriteFont>("DebugText");

            // Set player bounding to map
            player.RespectBounds = true;
            player.WillWarpAroundBounds = true;
            player.Bounds = Camera.WorldRectangle;


            Camera.ClampPosition = false;            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MapManager.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            //Render to our target so we can properly scale the screen
            RenderTarget2D target = new RenderTarget2D(graphics.GraphicsDevice, Camera.GameWidth, Camera.GameHeight);
            GraphicsDevice.SetRenderTarget(target);
            
            spriteBatch.Begin();
           
            //Rendering
            MapManager.Draw(spriteBatch);
            

            spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            
            //Draw to screen
            spriteBatch.Begin(SpriteSortMode.FrontToBack, null, SamplerState.PointClamp);
            spriteBatch.Draw(target, new Rectangle(0, 0, screenWidth, screenHeight), Color.White);

            spriteBatch.DrawString(debugFont, "X:" + player.Position.X + ", Y:" + player.Position.Y, new Vector2(0, 0), Color.Black);
            spriteBatch.DrawString(debugFont, "GX:" + player.GridPosition.X + ", GY:" + player.GridPosition.Y, new Vector2(0, 12), Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
