using Microsoft.Xna.Framework;

namespace Tiled_Engine
{
    public static class Camera
    {
        #region Declarations
        private static Vector2 position = Vector2.Zero;
        private static Vector2 viewPortSize = Vector2.Zero;       
        #endregion

        #region Properties
        public static Vector2 Position
        {
            get { return position; }
            set
            {
                if (ClampPosition)
                {
                    ClampPositonByBounds(value);
                }
                else
                {
                    position = value;
                }
            }
        }

        public static bool ClampPosition { get; set; } = true;


        private static void ClampPositonByBounds(Vector2 value)
        {
            position = value;

            position = new Vector2(
                                MathHelper.Clamp(value.X,
                                                 WorldRectangle.X - HorizontalBorderLength,
                                                 WorldRectangle.Width - (ViewPortWidth / Scaleing) + HorizontalBorderLength),
                                MathHelper.Clamp(value.Y,
                                                 WorldRectangle.Y - VerticalBorderLength,
                                                 WorldRectangle.Height - (ViewPortHeight / Scaleing) + VerticalBorderLength));

        }

        public static int Scaleing { get; set; } = 1;

        public static Vector2 BorderLength { get; set; } = Vector2.Zero;

        public static float HorizontalBorderLength
        {
            get
            {
                return BorderLength.X;
            }
            set
            {
                BorderLength = new Vector2(value, BorderLength.Y);
            }
        } 

        public static float VerticalBorderLength
        {
            get
            {
                return BorderLength.Y;
            }
            set
            {
                BorderLength = new Vector2(BorderLength.X, value);
            }
        }

        public static int GameWidth
        {
            get
            {
                return ViewPortWidth / Scaleing;
            }
        }

        public static int GameHeight
        {
            get
            {
                return ViewPortHeight / Scaleing;
            }
        }

        public static Rectangle WorldRectangle { get; set; } = new Rectangle(0, 0, 0, 0);

        public static int ViewPortWidth
        {
            get { return (int)viewPortSize.X; }
            set { viewPortSize.X = value; }
        }

        public static int ViewPortHeight
        {
            get { return (int)viewPortSize.Y; }
            set { viewPortSize.Y = value; }
        }

        public static Rectangle ViewPort
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, ViewPortWidth, ViewPortHeight);
            }
        }
       
        #endregion

        #region Public Methods
        public static void Move(Vector2 offset)
        {
            Position += offset;
        }

        public static bool ObjectIsVisible(Rectangle bounds)
        {
            return (ViewPort.Intersects(bounds));
        }

        public static Vector2 WorldToScreen(Vector2 worldLocation)
        {
            return worldLocation - position;
        }

        public static Vector2 WorldToScreen(float x, float y)
        {
            return new Vector2(x, y) - position;
        }

        public static Rectangle WorldToScreen(Rectangle worldRectangle)
        {
            return new Rectangle(
                worldRectangle.Left - (int)position.X,
                worldRectangle.Top - (int)position.Y,
                worldRectangle.Width,
                worldRectangle.Height);
        }

        public static Vector2 ScreenToWorld(Vector2 screenLocation)
        {
            return screenLocation + position;
        }

        public static Vector2 ScreenToWorld(float x, float y)
        {
            return new Vector2(x, y) + position;
        }

        public static Rectangle ScreenToWorld(Rectangle screenRectangle)
        {
            return new Rectangle(
                screenRectangle.Left + (int)position.X,
                screenRectangle.Top + (int)position.Y,
                screenRectangle.Width,
                screenRectangle.Height);
        }


        #endregion
    }
}
