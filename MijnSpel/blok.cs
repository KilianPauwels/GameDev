using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnSpel
{
    //abstracte klasse voor het tekenen van terrain
    public abstract class blok
    {
        protected Surface video;
        protected Surface image;
        protected Point position;
        public Rectangle colRect;
        public Rectangle botRectangle;

        public void Draw()
        {
            video.Blit(image, position);
            botRectangle = new Rectangle(position.X, position.Y + 5, 50, 20);
        }
    }
}
