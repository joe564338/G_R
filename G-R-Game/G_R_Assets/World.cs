﻿using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using G_R_Game.G_R_Assets.Entities;
using VelcroPhysics.Dynamics;
namespace G_R_Game.G_R_Assets
{
    class World
    {
        
        Player p1;
        List<Entity> entities;
        VelcroPhysics.Dynamics.World physicsWorld;
        Wall wall;
        Wall wall2;
        public World(int areaWidth, int areaHeight)
        {
            physicsWorld = new VelcroPhysics.Dynamics.World(Vector2.Zero);
            p1 = new Player(new Vector2(200, 200), physicsWorld);
            entities = new List<Entity>();
            entities.Add(p1);
            wall = new Wall(new Vector2(200, 200), new Vector2(300, 700), physicsWorld);
            wall2 = new Wall(new Vector2(200, 200), new Vector2(600, 300), physicsWorld);
            entities.Add(wall);
            entities.Add(wall2);
            
        }
        public void AddEntity(Entity entity)
        {
            entities.Add(entity);
        }
        public void RemoveEntity(Entity entity)
        {
            entities.Remove(entity);
        }
        public void LoadPlayerTexture(Texture2D texture)
        {
            p1.LoadTexture(texture);
        }
        public Texture2D GetPlayerTexture()
        {
            return p1.GetTexture();
        }
        public Vector2 GetPlayerPosition()
        {
            return p1.GetPosition();
        }
        public void Update(float deltaTime)
        {
            physicsWorld.Step(deltaTime);
            foreach(Entity e in entities)
            {
                foreach(Fixture f in e.GetActiveAttackHitBoxes())
                {
                    //f.
                }
            }
        }
        public void ApplyImpulseToPlayer(Vector2 impulse)
        {
            p1.ApplyImpulse(impulse);
        }
        public Vector2 GetPlayerTextureDimensions()
        {
            return p1.GetTextureDimensions();
        }
        public List<Entity> GetEntities()
        {
            return entities;
        }
        public void PlayerPrimaryAttack()
        {
            p1.PrimaryAttack(physicsWorld);
        }
    }
}
