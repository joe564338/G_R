using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace G_R_Game.G_R_Assets.Entities
{
    class Wall :Entity
    {
        public Wall(Texture2D texture, Vector2 dimensions)
        {
            this.texture = texture;
            textureDimensions = dimensions;
            hitboxDimensions = dimensions;
            hitboxType = HitboxType.Rectangular;
        }

    }
}
