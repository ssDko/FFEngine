using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace TiledEngine
{
    public class TiledTile
    {       

        #region Properties
        public static List<TiledTile> GetTileList { get; private set; }

        public int TileID { get; set; } = 0;

        public Texture2D SourceImage { get; set; }

        public Vector2 PositionOnImage { get; set; }

        public int TileWidth { get; set; } = 0;

        public int TileHeight { get; set; } = 0;

        public string Type { get; set; }

        public TiledSet TiledSet { get; }

        //Animation specific Properties (most are pointless unless IsAnimated = true)
        public bool IsAnimated { get; set; } = false;

        public bool LoopAnimation { get; set; } = true;

        public bool FinishedPlaying { get; private set; } = false;

        public bool IsPaused { get; private set; } = false;

        private int CurrentFrameIndex { get; set; } = 0;

        private float FrameTimer { get; set; } = 0.0f;

        public List<FrameData> AnimationFrames { get; set; }

        public int CurrentFrameID
        {
            get { return AnimationFrames[CurrentFrameIndex].TileID; }
        }
        #endregion

        #region Constructor(s) and Destructor
        public TiledTile(int tileID,                         
                         Vector2 positionOnImage,
                         int tileWidth,
                         int tileHeight,                        
                         TiledSet tileSet,
                          string type = "",
                         bool isAnimated = false,
                         bool loopAnimation = true,
                         List<FrameData> animationFrames = null)
        {
            TileID = tileID;
            SourceImage = tileSet.Texture;
            PositionOnImage = positionOnImage;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            TiledSet = tileSet;
            Type = type;
            IsAnimated = isAnimated;
            LoopAnimation = loopAnimation;
            AnimationFrames = animationFrames;

            if (GetTileList == null)
            {
                GetTileList = new List<TiledTile>();
            }

            GetTileList.Add(this);            
        }

        public TiledTile(int tileId,                         
                         int xPositionOnImage,
                         int yPositionOnImage,
                         int tileWidth,
                         int tileHeight,
                         TiledSet tileSet,
                         string type = "",                         
                         bool isAnimated = false,
                         bool loopAnimation = true,
                         List<FrameData> animationFrames = null)

                  : this(tileId,                         
                         new Vector2((float)xPositionOnImage, (float)yPositionOnImage),
                         tileWidth,
                         tileHeight,
                         tileSet,
                         type,                         
                         isAnimated,
                         loopAnimation,
                         animationFrames)
        {

        }

        ~TiledTile()
        {
            GetTileList.Remove(this);
        }

        #endregion

        #region Methods
        public static void RemoveTileAt(int index)
        {
            GetTileList.RemoveAt(index);
        }

        public void Update(GameTime gameTime)
        {

            if (IsAnimated && !FinishedPlaying && !IsPaused)
            {
                float elapsed = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                FrameTimer += elapsed;

                if (FrameTimer >= AnimationFrames[CurrentFrameIndex].Duration)
                {
                    if (CurrentFrameIndex >= AnimationFrames.Count - 1)
                    {
                        if (LoopAnimation)
                        {
                            CurrentFrameIndex = 0;
                        }
                        else
                        {
                            FinishedPlaying = true;
                        }
                    }
                    else
                    {
                        CurrentFrameIndex++;
                    }
                    FrameTimer = 0f;
                }
            }
        }

        public void Play()
        {
            FinishedPlaying = false;
            IsPaused = false;
        }

        public void Stop()
        {
            FinishedPlaying = true;
            Restart();
        }

        public void Pause()
        {
            IsPaused = true;
        }

        public void Restart()
        {
            CurrentFrameIndex = 0;
        }

        public Rectangle Rectangle()
        {
            return new Rectangle(
                (int)PositionOnImage.X,
                (int)PositionOnImage.Y,
                TileWidth,
                TileHeight);
        }
        #endregion
    }
}
