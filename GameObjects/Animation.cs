
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameObjects
{
    public class Animation
    {
        #region Declarations
        private int width = 0;
        private int height = 0;
        private Frame currentFrame;
        private int currentFrameIndex = 0;
        private Frame nextFrame;
        private Frame prevFrame;
        private List<Frame> frames;
        private float frameTimer = 0.0f;
        private bool loopAnimation = true;
        private bool finishedPlaying = true;
        #endregion

        #region Properties
        public Texture2D Texture
        {
            get { return currentFrame.Texture; }
            set { SetFrameTextures(value); }
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public Frame CurrentFrame
        {
            get { return currentFrame; }
            set
            {
                if (frames.Contains(value))
                {
                    currentFrame = value;
                    currentFrameIndex = frames.IndexOf(currentFrame);
                    SetPrevAndNextFrame();                    
                }
            }
        }

        public int CurrentFrameIndex
        {
            get { return currentFrameIndex; }
            set
            {
                if (value <= frames.Count - 1)
                {
                    currentFrameIndex = value;
                    currentFrame = frames[currentFrameIndex];
                    SetPrevAndNextFrame();
                }
            }
        }

        public Frame NextFrame
        {
            get { return nextFrame; }
        }

        public Frame PrevFrame
        {
            get { return prevFrame; }
        }

        public List<Frame> Frames
        {
            get { return frames; }
            set
            {
                frames = value;
                Reset();
                SetWidthAndHeight();
            }
        }

        public float FrameTimer
        {
            get { return frameTimer; }
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
            get { return frames.Count; }
        }

        public float CurrentFrameDelay
        {
            get { return currentFrame.Delay; }
        }

        #endregion

        #region Constructor(s)
        public Animation (List<Frame> frames, bool loopAnimation)
        {
            Frames = frames;
            this.loopAnimation = loopAnimation;
        }
        #endregion

        #region Methods
        private void SetFrameTextures(Texture2D texture)
        {
            foreach (var frame in frames)
            {
                frame.Texture = texture;
            }
        }

        private void SetWidth()
        {
            int largestWidth = 0;

            foreach (var frame in frames)
            {
                if (frame.Width > largestWidth)
                {
                    largestWidth = frame.Width;
                }
            }

            width = largestWidth;
        }

        private void SetHeight()
        {
            int largestHeight = 0;

            foreach (var frame in frames)
            {
                if (frame.Height > largestHeight)
                {
                    largestHeight = frame.Height;
                }
            }

            height = largestHeight;
        }

        private void SetWidthAndHeight()
        {
            SetHeight();
            SetWidth();
        }

        private void SetPrevAndNextFrame()
        {
            if (CurrentFrameIndex > 0)
            {
                prevFrame = frames[currentFrameIndex - 1];
            }
            else
            {
                prevFrame = null;
            }

            if (CurrentFrameIndex < frames.Count - 1)
            {
                nextFrame = frames[currentFrameIndex + 1];
            }
            else
            {
                nextFrame = null;
            }
        }

        public void Reset()
        {
            CurrentFrameIndex = 0;
            frameTimer = 0.0f;            
        }

        public void Play()
        {           
            finishedPlaying = false;
        }

        public void ResetAndPlay()
        {
            Reset();
            Play();
        }

        public void Stop()
        {
            finishedPlaying = true;
        }

        public void StopAndReset()
        {
            Stop();
            Reset();
        }

        public void Update(GameTime gameTime)
        {
            if (!finishedPlaying)
            {
                float elapsed = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                frameTimer += elapsed;

                if (frameTimer >= currentFrame.Delay)
                {
                    if (CurrentFrameIndex >= FrameCount - 1)
                    {
                        if (loopAnimation)
                        {
                            CurrentFrameIndex = 0;
                        }
                        else
                        {
                            finishedPlaying = true;
                        }
                    }
                    else
                    {
                        CurrentFrameIndex++;
                    }
                    frameTimer = 0f;
                }
            }            
        }
       
        #endregion
    }
}
