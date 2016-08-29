using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnSpel
{
    class muur:blok
    {
        //code om een muur blok te tekenen
        public muur(Surface mVideo, Point position, Rectangle rect)
        {
            this.video = mVideo;
            this.position = position;
            image = new Surface(@"assets\muur.png");
            colRect = rect;
            
            

            
        }
    }
}
