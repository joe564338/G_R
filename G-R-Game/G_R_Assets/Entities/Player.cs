using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using VelcroPhysics.Factories;
using VelcroPhysics.Dynamics;
using VelcroPhysics.Utilities;
namespace G_R_Game.G_R_Assets.Entities
{
    class Player : Entity
    {
        
        public Player(Vector2 pos, VelcroPhysics.Dynamics.World world)
        {
            physicsBody = BodyFactory.CreateCircle(world, ConvertUnits.ToSimUnits(100f), 1f, ConvertUnits.ToSimUnits(pos), BodyType.Dynamic);
            physicsBody.LinearDamping = 10f;
            
            label = "player";
            textureDimensions = new Vector2(100, 100);
            origin = textureDimensions / 2;
            
        }
        public override void PrimaryAttack(VelcroPhysics.Dynamics.World world)
        {
            Fixture damageBox = FixtureFactory.AttachRectangle(ConvertUnits.ToSimUnits(30f), ConvertUnits.ToSimUnits(90f), 0f, new Vector2(0, ConvertUnits.ToSimUnits(50f)), physicsBody, null);
            damageBox.IsSensor = true;
        }


    }
}
