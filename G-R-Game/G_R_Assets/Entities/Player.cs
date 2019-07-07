using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace G_R_Game.G_R_Assets.Entities
{
    class Player : Entity
    {
        
        public Player(Vector2 pos)
        {
            position = pos;
            speed = Vector2.Zero;
            
        }
        public void LoadTexture(Texture2D texture)
        {
            this.texture = texture;
        }
        
    }
}
