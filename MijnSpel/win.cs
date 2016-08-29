using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnSpel
{
    class win:blok
    {
        //blok om een vlag op de finish te tekenen
        public win(Surface mVideo, Point position, Rectangle rect)
        {
            this.video = mVideo;
            this.position = position;
            image = new Surface(@"assets\win.png");
            colRect = rect;
            
            

            
        }
    }
}
