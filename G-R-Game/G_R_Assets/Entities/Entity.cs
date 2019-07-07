using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace G_R_Game.G_R_Assets.Entities
{
    enum HitboxType
    {
        Rectangular,
        Circular
    }
    abstract class Entity
    {
        protected Vector2 position;
        protected Vector2 speed;
        protected Texture2D texture = null;
        protected HitboxType hitboxType;
        protected Vector2 textureDimensions;
        protected Vector2 hitboxDimensions;
        public Texture2D GetTexture()
        {
            return texture;
        }
        public Vector2 GetPosition()
        {
            return position;
        }
        public void UpdatePosition()
        {
            position += speed;
        }
        public void UpdateSpeed(Vector2 speed)
        {
            this.speed = speed;
        }
        public Vector2 GetTextureDimensions()
        {
            return textureDimensions;
        }
        public Vector2 GetHitboxDimensions()
        {
            return hitboxDimensions;
        }
        public HitboxType GetHitboxType()
        {
            return hitboxType;
        }
    }
    
}
