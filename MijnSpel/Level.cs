using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnSpel
{

    public abstract class Level
    {
        public int[,] intTileArray;

        public blok[,] spriteTileArray;

        public Rectangle colRect;
        
        

        protected Surface video;

        public Level(Surface video)
        {
            this.video = video;
        }

        public abstract void CreateWorld();
        

        public void DrawWorld()
        {
            for (int i = 0; i < intTileArray.GetLength(0); i++)
            {
                for (int j = 0; j < intTileArray.GetLength(1); j++)
                {
                    if (spriteTileArray[i, j] != null)
                    {
                        spriteTileArray[i, j].Draw();
                        
                        
                    }
                }
            }
        }
    }
}
