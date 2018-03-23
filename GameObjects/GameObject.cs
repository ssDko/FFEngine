using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tiled_Engine;

namespace FFEngine
{
    public class GameObject
    {
        #region Declarations
        
        protected Vector2 velocity;
        protected int frameWidth;
        protected int frameHeight;

        
        protected bool vflipped = false;
        protected bool hflipped = false;

        protected Rectangle collisionRectangle;
        protected int collideWidth;
        protected int collideHeight;
        protected bool blocks = false;

        protected float drawDepth = 0.85f;
        protected Dictionary<int, Texture2D> sprites = new Dictionary<string, Sprite>();
        protected int currentSprite;
        #endregion

        #region Properties
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        //public Dictionary<int, Texture2D>  


        public bool Enabled { get; set; } = true;        

        

        
        }
        #endregion

        #region Helper Methods
        private void updateSprite(GameTime gameTime)
        {
            if (sprites.ContainsKey(currentSprite))
            {                
                sprites[currentSprite].Update(gameTime);                
            }
        }
        #endregion

        #region Public Methods
        public void ChangeCurrentSprite(string name)
        {
            if (!(name==null) && sprites.ContainsKey(name))
            {
                currentSprite = name;
                sprites[name].StartAnimation();
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            if (!enabled)
                return;
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            updateSprite(gameTime);

            Vector2 moveAmount = velocity * elapsed;
            //moveAmount = horizontalCollisionText(moveAmount);
            //moveAmount = verticlaCollisionTest(moveAmount);

            Vector2 newPosition = worldLocation + moveAmount;

            newPosition = new Vector2(
                MathHelper.Clamp(
                    newPosition.X,
                    0,
                    Camera.WorldRectangle.Width - frameWidth),
                MathHelper.Clamp(
                    newPosition.Y,
                    2 * (-TiledMap.TileHeight),
                    Camera.WorldRectangle.Height - frameHeight));

            WorldLocation = newPosition;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (!enabled)
                return;

            if (sprites.ContainsKey(currentSprite))
            {
                SpriteEffects effect = SpriteEffects.None;

                if (hflipped)
                {
                    effect |= SpriteEffects.FlipHorizontally;
                }

                if (vflipped)
                {
                    effect |= SpriteEffects.FlipVertically;
                }

                spriteBatch.Draw(
                    sprites[currentSprite].Texture,
                    Camera.WorldToScreen(WorldRectangle),
                    sprites[currentSprite].FrameRectangle,
                    Color.White,
                    0.0f,
                    Vector2.Zero,
                    effect,
                    drawDepth); 
            }
        }
        #endregion

        #region Map-Based Collision Detection Methods
        private Vector2 horizontalCollisionTest(Vector2 moveAmmount)
        {
            // Todo
            return moveAmmount;
        }

        private Vector2 verticalCollisionTest(Vector2 moveAmmount)
        {
            // Todo
            return moveAmmount;
        }
        #endregion
    }
}
