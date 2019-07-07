using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace G_R_Game.G_R_Assets.Entities
{
    abstract class Entity
    {
        protected Vector2 position;
        protected Vector2 speed;
        protected Texture2D texture = null;
        public Texture2D GetTexture()
        {
            return texture;
        }
    }
    
}
