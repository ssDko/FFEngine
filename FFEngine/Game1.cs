using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Xml.Serialization;
using TiledEngine;
using TiledEngine.DatabaseObjects;
using TiledEngine.Managers;




namespace FFEngine
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {        
       
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
            TempMethod();

            DataManager.LoadDataBase();

            graphics.PreferredBackBufferWidth = DataManager.DataSystems[0].ScreenWidth;
            graphics.PreferredBackBufferHeight = DataManager.DataSystems[0].ScreenHeight;
            graphics.IsFullScreen = DataManager.DataSystems[0].IsFullScreen;
            graphics.ApplyChanges();

            Camera.ViewPortWidth = DataManager.DataSystems[0].ScreenWidth;
            Camera.ViewPortHeight = DataManager.DataSystems[0].ScreenHeight;
            Camera.Scaleing = DataManager.DataSystems[0].Scaling;

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            player = new Player(new Vector2(12, 16), 16, 16, 16, 16, Content.Load<Texture2D>("Player"), 1);







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

        private static void TempMethod()
        {
            DBSkill[] test = new DBSkill[1];

            test[0] = new DBSkill();


            XmlSerializer writer = new XmlSerializer(typeof(DBSkill[]));

            var path = @"Content\Data\Skills.xml";

            using (System.IO.FileStream file = System.IO.File.Create(path))
            {
                writer.Serialize(file, test);
            }

            //DBActor[] test = new DBActor[2];
            //List<DBTrait> traits = new List<DBTrait>();
            //traits.Add(new DBTrait(Codes.AddState, 1, 2, 3, Occasion.Always));
            //test[0] = new DBActor(1, "Jesse", 1, 1, 99, "Jesse.png", 0, "JB.png", traits );
            //test[1] = new DBActor(2, "Jesse2", 1, 1, 99, "JesseB.png", 1, "JB2.png", traits, "Kittyface.png");


            //XmlSerializer writer = new XmlSerializer(typeof(DBActor[]));

            //var path = @"Content\Data\Actors.xml";

            //using (System.IO.FileStream file = System.IO.File.Create(path))
            //{
            //    writer.Serialize(file, test);
            //}


            //DBSystem[] test = new DBSystem[1];

            //List<string> ele = new List<string>();
            //ele.Add("Status");
            //ele.Add("Poison");
            //ele.Add("Stone");
            //ele.Add("Time");
            //ele.Add("Death");
            //ele.Add("Fire");
            //ele.Add("Ice");
            //ele.Add("Lightning");
            //ele.Add("Earth");

            //List<string> ene = new List<string>();
            //ene.Add("Magical");
            //ene.Add("Dragon");
            //ene.Add("Giant");
            //ene.Add("Undead");
            //ene.Add("Were");
            //ene.Add("Aquatic");
            //ene.Add("Mage");
            //ene.Add("Regenerative");

            //List<DBStartingEquipment> se = new List<DBStartingEquipment>();
            //se.Add(new DBStartingEquipment(1, new int[] { 1, 2, 3, 4, 5 }, 1));
            //se.Add(new DBStartingEquipment(2, new int[] { 5, 4, 3, 2, 1 }, 2));
            //test[0] = new DBSystem(
            //    4,
            //    1024,
            //    960,
            //    false,
            //    ele,
            //    ene,
            //    false,
            //    se);


            //XmlSerializer writer = new XmlSerializer(typeof(DBSystem[]));

            //var path = @"Content\Data\System.xml";

            //using (System.IO.FileStream file = System.IO.File.Create(path))
            //{
            //    writer.Serialize(file, test);
            //}
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
