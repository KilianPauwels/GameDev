using SdlDotNet.Core;
using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnSpel
{
    

    public class Enemy: MoveableObject 
    {
        private Rectangle visibleRectangle;
        public Rectangle topRectangle;
        public int start;
        public int stop;
        
        

        public Enemy(Surface video,Point position)
            : base(video)
        {
            this.position = position;
            
            xVelocity = 2;
            image = new Surface(@"assets\rechtsvijand.png");
            visibleRectangle = new Rectangle(0, 0, 50, 50);
            topRectangle = new Rectangle(position.X+20, position.Y - 10, 10, 10);
            colRectangle = new Rectangle(position.X, position.Y, 40, 40);
            start = position.X;
            stop = position.X += 100;
        }
        public override void Draw()
        {
            video.Blit(image,position,visibleRectangle);
        }

        int framedelay = 0;
        public override void Update(Level level)
        {
            framedelay++;

            if (position.X >= start && position.X <= stop)
            {
                position.X += xVelocity;

                if (framedelay == 5)
                {
                    visibleRectangle.X += 50;


                    if (visibleRectangle.X >= 400)
                    {
                        visibleRectangle.X = 0;

                    }
                    framedelay = 0;
                    framedelay++;
                }
            }
            else
            {
                xVelocity *= -1;
                position.X += xVelocity;
                image = new Surface(@"assets\linksvijand.png");
                if (position.X <= start)
                {
                    image = new Surface(@"assets\rechtsvijand.png");
                }
            }

            colRectangle.X = position.X;
            colRectangle.Y = position.Y;
            topRectangle.X = position.X+20;
            topRectangle.Y = position.Y-5;
            
        }


        
    }
}
