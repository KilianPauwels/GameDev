﻿using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnSpel
{
    public class Gras : blok
    {
        
        //code om gras te tekenen
        public Gras(Surface mVideo, Point position, Rectangle rect)
        {
            this.video = mVideo;
            this.position = position;
            image = new Surface(@"assets\grass.png");
            colRect = rect;
            botRectangle = new Rectangle(position.X, position.Y + 5, 50, 30);

            

            
        }

        

    }
}