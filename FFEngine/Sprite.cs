using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FFEngine
{
    public class Sprite
    {
        #region Declarations
        private Texture2D texture;
        private int frameWidth;
        private int frameHeight;

        private float frameTimer = 0f;
        private float frameDelay = 0.05f;

        private int currentFrame = 0;

        private bool isAnimated = false;
        private bool loopAnimation = true;
        private bool finishedPlaying = false;

        private string name;
      
        #endregion

        #region Properties
        public int FameWidth
        {
            get { return frameWidth; }
            set { frameWidth = value; }
        }

        public int FameHeight
        {
            get { return frameHeight; }
            set { frameHeight = value; }
        }

        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool IsAnimated
        {
            get { return isAnimated; }
            set
            {
                isAnimated = value;
                if (isAnimated == true)
                {
                    StartAnimation();
                }
            }
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

        public int FrameCount
        {
            get { return texture.Width / frameWidth; }
        }

        public float FrameLength
        {
            get { return frameDelay; }
            set { frameDelay = value; }
        }

        public Rectangle FrameRectangle
        {
            get
            {
                return new Rectangle(
                    currentFrame * frameWidth,
                    0,
                    frameWidth,
                    frameHeight);
            }
        }
        #endregion

        #region Constructor(s)
        public Sprite(Texture2D texture, string name, int frameWidth, bool isAnimated = false)
        {
            this.texture = texture;
            this.frameWidth = frameWidth;
            this.frameHeight = texture.Height;
            this.name = name;
            this.isAnimated = isAnimated;           
        }

        public Sprite(Texture2D texture, string name) : this(texture, name, texture.Width)
        {   
        }
        #endregion

        #region Public Methods
        public void StartAnimation()
        {
            currentFrame = 0;
            finishedPlaying = false;
        }

        public void Update (GameTime gameTime)
        {
            if (isAnimated)
            {
                float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

                frameTimer += elapsed;

                if (frameTimer >= frameDelay)
                {
                    currentFrame++;
                    if (currentFrame >= FrameCount)
                    {
                        if (loopAnimation)
                        {
                            currentFrame = 0;
                        }
                        else
                        {
                            currentFrame = FrameCount - 1;
                            finishedPlaying = true;
                        }
                    }
                    frameTimer = 0f;
                }
            }
        }
        #endregion
    }
}
