using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VelcroPhysics.Dynamics;
using VelcroPhysics.Factories;

namespace G_R_Game.G_R_Assets.Entities
{
    enum HitboxType
    {
        Rectangular,
        Circular
    }
    
    abstract class Entity
    {
        protected Body physicsBody;
        //protected Vector2 position;
        //protected Vector2 speed;
        protected Texture2D texture = null;
        //protected HitboxType hitboxType;
        protected Vector2 textureDimensions;
        //protected Vector2 hitboxDimensions;
        public Texture2D GetTexture()
        {
            return texture;
        }
        public Vector2 GetPosition()
        {
            return physicsBody.Position;
        }
        
        public void ApplyImpulse(Vector2 force)
        {
            physicsBody.ApplyLinearImpulse(force);
        }
        public Vector2 GetTextureDimensions()
        {
            return textureDimensions;
        }
        
        
        public Vector2 GetSpeed()
        {
            return physicsBody.LinearVelocity;
        }
        public void SetPosition(Vector2 position)
        {
            physicsBody.Position = position;
        }
    }
    
}
