
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Tiled_Engine;
using Tiled_Engine.Layers;
using System.Collections.Specialized;
using System.Collections.Generic;

namespace FFEngine
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        static int screenWidth = 800;
        static int screenHeight = 480;
        static bool isFullScreen = false;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;        
        Texture2D spriteSheet;
      


        


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

            Camera.WorldRectangle = new Rectangle(0, 0, 160 * 48, 12 * 48);
            Camera.Position = Vector2.Zero;
            Camera.ViewPortWidth = screenWidth;
            Camera.ViewPortHeight = screenHeight;

            spriteSheet = Content.Load<Texture2D>(@"TileSet");

            MapManager.MapDirectory = @"Content\";
            MapManager.LoadMapData(graphics.GraphicsDevice);        

                   



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
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            //TiledSet set = (TiledSet)MapManager.TileSets[1];
            //foreach(TiledTile tile in set.Tiles)
            //{


            //    spriteBatch.Draw(tile.SourceImage,
            //                     new Rectangle((int)tile.PositionOnImage.X + 16, (int)tile.PositionOnImage.Y + 16, tile.TileWidth, tile.TileHeight),
            //                     new Rectangle((int)tile.PositionOnImage.X, (int)tile.PositionOnImage.Y, tile.TileWidth, tile.TileHeight),
            //                     Color.White);
            //}

            MapManager.Draw(spriteBatch);
            
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
