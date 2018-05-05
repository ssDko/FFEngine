using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tiled_Engine
{
    public class AnimationStrip
    {
        #region Declarations
        private Texture2D texture;
        //Where on the texture the animation begins
        private int locationX;
        private int locationY;

        private int frameWidth;
        private int frameHeight;

        private float frameTimer = 0f;
        private float frameDelay = 0.05f;

        private int currentFrame;
        private int frameCount;

        private bool loopAnimation = true;
        private bool finishedPlaying = false;

        private string name;
        private string nextAnimation;
        #endregion

        #region Properties
        public int LocationX
        {
            get { return locationX; }
            set { locationX = value; }
        }

        public int LocationY
        {
            get { return locationY; }
            set { locationY = value; }
        }

        public int FrameWidth
        {
            get { return frameWidth; }
            set { frameWidth = value; }
        }

        public int FrameHeight
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

        public string NextAnimation
        {
            get { return nextAnimation; }
            set { nextAnimation = value; }
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
            get { return frameCount; }
            set { frameCount = value; }
        }

        public float FrameDelay
        {
            get { return frameDelay; }
            set { frameDelay = value; }
        }

        public Rectangle FrameRectangle
        {
            get
            {
                return new Rectangle(
                    (currentFrame * frameWidth) + locationX,
                    locationY,
                    frameWidth,
                    frameHeight);
            }
        }
        #endregion

        #region Constructor
        public AnimationStrip(
            int locationX,
            int locationY,
            Texture2D texture,
            int frameWidth,
            int frameHeight,
            int frameCount,            
            string name,
            float frameDelay = 0.05f)
        {
            this.locationX = locationX;
            this.locationY = locationY;
            this.texture = texture;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.frameCount = frameCount;
            this.name = name;
            this.frameDelay = frameDelay;
        }
        #endregion

        #region Public Methods
        public void Play()
        {
            currentFrame = 0;
            finishedPlaying = false;
        }

        public void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            frameTimer += elapsed;

            if (frameTimer >= frameDelay)
            {
                currentFrame++;
                if (currentFrame >= frameCount)
                {
                    if (loopAnimation)
                    {
                        currentFrame = 0;
                    }
                    else
                    {
                        currentFrame = frameCount - 1;
                        finishedPlaying = true;
                    }
                }

                frameTimer = 0f;
            }
        }
        #endregion

    }
}
