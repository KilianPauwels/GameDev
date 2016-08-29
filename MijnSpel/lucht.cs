using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnSpel
{
    class lucht:blok
    {
        //code om lucht te tekenen (lege afbeelding), puur voor collision doeleinden.
        public lucht(Surface mVideo, Point position, Rectangle rect)
        {
            this.video = mVideo;
            this.position = position;
            image = new Surface(@"assets\lucht.png");
            colRect = rect;
            

            
        }
    }
}
