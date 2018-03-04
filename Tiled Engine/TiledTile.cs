using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace Tiled_Engine
{
    public class TiledTile
    {
        #region Declarations
        private static List<TiledTile> TileList;

        private int tileID = 0;       
        private Texture2D sourceImage;
        private Vector2 positionOnImage;
        private int tileWidth = 0;
        private int tileHeight = 0;
        private string type;
        private TiledSet tileSet;

        // Animation specific info
        private bool isAnimated = false;
        private bool loopAnimation = true;
        private bool finishedPlaying = false;
        private bool isPaused = false;
        private int currentFrameIndex = 0;
        private float frameTimer = 0.0f;
        private List<FrameData> animationFrames;

        #endregion

        #region Properties
        public static List<TiledTile> GetTileList
        {
            get { return TileList; }
        }

        public int TileID
        {
            get { return tileID; }
            set { tileID = value; }
        }       

        public Texture2D SourceImage
        {
            get { return sourceImage; }
            set { sourceImage = value; }
        }

        public Vector2 PositionOnImage
        {
            get { return positionOnImage; }
            set { positionOnImage = value; }
        }

        public float XPositionOnIamge
        {
            get { return positionOnImage.X; }
            set { positionOnImage.X = value; }
        }

        public float YPositionOnIamge
        {
            get { return positionOnImage.Y; }
            set { positionOnImage.Y = value; }
        }

        public int TileWidth
        {
            get { return tileWidth; }
            set { tileWidth = value; }
        }
        public int TileHeight
        {
            get { return tileHeight; }
            set { tileHeight = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public TiledSet TiledSet
        {
            get { return tileSet; }
        }

        //Animation specific Properties (most are pointless unless IsAnimated = true)
        public bool IsAnimated
        {
            get { return isAnimated; }
            set { isAnimated = value; }
        }

        public bool LoopAnimation
        {
            get { return loopAnimation; }
            set { loopAnimation = value; }
        }

        public bool FinishedPlaying
        {
            get { return finishedPlaying; }
        }

        public bool IsPaused
        {
            get { return isPaused; }
        }

        private int CurrentFrameIndex
        {
            get { return currentFrameIndex; }
            // set { currentFrameIndex = value; }  //Unsure if someone needs to be able to modify this
        }

        private float FrameTimer
        {
            get { return frameTimer; }
        }

        public List<FrameData> AnimationFrames
        {
            get { return animationFrames; }
            set { animationFrames = value; }
        }        

        public int CurrentFrameID
        {
            get { return animationFrames[currentFrameIndex].TileID; }
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
            this.tileID = tileID;
            this.sourceImage = tileSet.Texture;
            this.positionOnImage = positionOnImage;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            this.tileSet = tileSet;
            this.type = type;
            this.isAnimated = isAnimated;
            this.loopAnimation = loopAnimation;
            this.animationFrames = animationFrames;

            if (TileList == null)
            {
                TileList = new List<TiledTile>();
            }

            TileList.Add(this);

            
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
            TileList.Remove(this);
        }

        #endregion

        #region Methods
        public static void RemoveTileAt(int index)
        {
            TileList.RemoveAt(index);
        }

        public void Update(GameTime gameTime)
        {

            if (isAnimated && !finishedPlaying && !isPaused)
            {
                float elapsed = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                frameTimer += elapsed;

                if (frameTimer >= animationFrames[currentFrameIndex].Duration)
                {
                    if (currentFrameIndex >= animationFrames.Count - 1)
                    {
                        if (loopAnimation)
                        {
                            currentFrameIndex = 0;
                        }
                        else
                        {
                            finishedPlaying = true;
                        }
                    }
                    else
                    {
                        currentFrameIndex++;
                    }
                    frameTimer = 0f;
                }
            }
        }

        public void Play()
        {
            finishedPlaying = false;
            isPaused = false;
        }

        public void Stop()
        {
            finishedPlaying = true;
            Restart();
        }

        public void Pause()
        {
            isPaused = true;
        }

        public void Restart()
        {
            currentFrameIndex = 0;
        }



        #endregion
    }

}
