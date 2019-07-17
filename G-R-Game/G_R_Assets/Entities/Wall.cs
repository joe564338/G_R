using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VelcroPhysics.Factories;
using VelcroPhysics.Dynamics;
using VelcroPhysics.Utilities;

namespace G_R_Game.G_R_Assets.Entities
{
    class Wall :Entity
    {
        public Wall(Vector2 dimensions, Vector2 position, VelcroPhysics.Dynamics.World world)
        {
           
            textureDimensions = dimensions;
            label = "wall";
            origin = textureDimensions / 1.85f;
            physicsBody = BodyFactory.CreateRectangle(world, ConvertUnits.ToSimUnits(dimensions.X), ConvertUnits.ToSimUnits(dimensions.Y), 10, ConvertUnits.ToSimUnits(position), 0, BodyType.Static, null);
        }
        public override void PrimaryAttack(VelcroPhysics.Dynamics.World world)
        {
            throw new NotImplementedException();
        }

    }
}
