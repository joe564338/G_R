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
        }
        public void LoadPlayerTexture(Texture2D texture)
        {
            p1.LoadTexture(texture);
        }
        public Texture2D GetPlayerTexture()
        {
            return p1.GetTexture();
        }
        
    }
}
