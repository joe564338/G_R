using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VelcroPhysics.Factories;
using VelcroPhysics.Dynamics;

namespace G_R_Game.G_R_Assets.Entities
{
    class Wall :Entity
    {
        public Wall(Vector2 dimensions, Vector2 position, VelcroPhysics.Dynamics.World world)
        {
           
            textureDimensions = dimensions;


            physicsBody = BodyFactory.CreateBody(world, position, 0, BodyType.Static);
        }
        public void LoadTexture(Texture2D texture)
        {
            this.texture = texture;
        }

    }
}
