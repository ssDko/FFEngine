using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameObjects
{
    public class Player
    {
        //Very much a work in progress. 
        #region Declarations
        private Vector2 position;
        #endregion


        #region Properties
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Velocity { get; set; }
        public Texture2D Texture { get; set; }
        public float Z { get; set; }
        #endregion

        #region Constructor(s)
        public Player(Vector2 position, Texture2D texture, float z = 0)
        {
            Position = position;
            Velocity = Vector2.Zero;
            Texture = texture;
            Z = z;
        }

        public Player(float x, float y, Texture2D texture, float z = 0) : this(new Vector2(x, y), texture, z)
        {

        }
        #endregion

        #region Methods
        public void Update()
        {
            Position += Velocity;
        }
       
        #endregion




    }
}
