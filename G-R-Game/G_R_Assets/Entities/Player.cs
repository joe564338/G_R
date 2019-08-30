using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using VelcroPhysics.Factories;
using VelcroPhysics.Dynamics;
using VelcroPhysics.Utilities;
using VelcroPhysics.Collision.ContactSystem;
namespace G_R_Game.G_R_Assets.Entities
{
    class Player : Entity
    {
        public Fixture damageBox;
        public Texture2D damageBoxTexture = null;
        public Player(Vector2 pos, VelcroPhysics.Dynamics.World world)
        {
            physicsBody = BodyFactory.CreateCircle(world, ConvertUnits.ToSimUnits(100f), 1f, ConvertUnits.ToSimUnits(pos), BodyType.Dynamic);
            physicsBody.LinearDamping = 10f;
            
            label = "player";
            textureDimensions = new Vector2(100, 100);
            origin = textureDimensions / 2;
            damageBox = FixtureFactory.AttachRectangle(ConvertUnits.ToSimUnits(30f), ConvertUnits.ToSimUnits(90f), 2f, new Vector2(0, ConvertUnits.ToSimUnits(100f)), physicsBody, null);
            damageBox.OnCollision += new VelcroPhysics.Collision.Handlers.OnCollisionHandler(this.Dealdamage);
            
        }
        public override void PrimaryAttack(VelcroPhysics.Dynamics.World world)
        {
            
            //damageBox.IsSensor = true;
            
        }
        public override void EndPrimaryAttack(VelcroPhysics.Dynamics.World world)
        {
            damageBox.IsSensor = false;   
        }
        
        public void Dealdamage(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
            Console.WriteLine("Player stabbed b");
        }
        public void LoadPlayerDamageBoxTexture(Texture2D texture)
        {
            damageBoxTexture = texture;
        }
    }
}
