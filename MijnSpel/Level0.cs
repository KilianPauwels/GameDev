using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnSpel
{
    class Level0: Level
    {
        public Level0(Surface mVideo):base(mVideo)
        {
            intTileArray = new int[10, 27]{
                 {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0},
                 {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0},
                 {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0},
                 {0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,2,0,0,0,0,0,0,0,0,0,0,0},
                 {0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0},
                 {0,0,1,1,0,0,0,0,1,1,1,0,0,5,0,2,0,0,0,0,0,0,0,0,0,0,0},
                 {0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0},
                 {1,1,0,2,1,1,1,0,0,0,0,0,0,1,1,1,0,0,1,1,1,0,0,0,1,1,1},
                 {0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                 {1,1,1,2,0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,1,1,0,0,0,0}
            };
            CreateWorld();

        }

        public override void CreateWorld()
        {
            spriteTileArray = new blok[10, 27];
            
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (intTileArray[i, j] == 1)
                    {
                        spriteTileArray[i, j] = new Gras(video, new System.Drawing.Point(j * 50, i * 50),new Rectangle(j*50,i*50,50, 50));

                    }
                    if(intTileArray[i,j] == 0){
                        spriteTileArray[i,j] = new lucht(video, new System.Drawing.Point(j*50,i*50),new Rectangle(j*50,i*50,50,50));
                    }
                    if (intTileArray[i, j] == 2)
                    {
                        spriteTileArray[i, j] = new muur(video, new System.Drawing.Point(j * 50, i * 50), new Rectangle(j * 50, i * 50, 50, 50));
                    }

                    if (intTileArray[i, j] == 5)
                    {
                        spriteTileArray[i, j] = new GameOver(video, new System.Drawing.Point(j * 50, i * 50), new Rectangle(j * 50, i * 50, 50, 50));
                    }


                    
                }
            }

        }
    }
}
