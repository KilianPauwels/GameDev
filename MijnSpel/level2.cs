using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnSpel
{
    public class level2: Level
    {
        //level 2 code zoals in de les nagemaakt
        public level2(Surface mVideo):base(mVideo)
        {
            intTileArray = new int[10, 27]{
                 {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                 {0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                 {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                 {0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                 {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                 {0,0,1,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                 {0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0},
                 {1,1,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0},
                 {0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
                 {1,1,1,1,1,0,0,0,0,0,1,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,1}
            };
            CreateWorld();

        }

        public override void CreateWorld()
        {
            spriteTileArray = new blok[10, 27];
            
            for (int i = 0; i < spriteTileArray.GetLength(0); i++)
            {
                for (int j = 0; j < spriteTileArray.GetLength(1); j++)
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
                    if (intTileArray[i, j] == 3)
                    {
                        spriteTileArray[i, j] = new win(video, new System.Drawing.Point(j * 50, i * 50), new Rectangle(j * 50, i * 50, 50, 50));
                    }


                    
                }
            }

        }
    }
}
