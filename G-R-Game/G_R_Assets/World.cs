using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using G_R_Game.G_R_Assets.Entities;
namespace G_R_Game.G_R_Assets
{
    class World
    {
        Player p1;
        List<Entity> entities;
        public World()
        {
            p1 = new Player(new Vector2(200, 200));
            entities = new List<Entity>();
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
        public void Update()
        {
            p1.UpdatePosition();
        }
        public void UpdatePlayerSpeed(Vector2 speed)
        {
            p1.UpdateSpeed(speed);
        }
        public Vector2 GetPlayerTextureDimensions()
        {
            return p1.GetTextureDimensions();
        }
        public List<Entity> GetEntities()
        {
            return entities;
        }
    }
}
