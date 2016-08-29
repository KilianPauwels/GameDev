using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace MijnSpel
{
    //abstracte klasse voor beweegbare objecten (enemy, hero)
    public abstract class MoveableObject
    {
        public Point position;
        protected int xVelocity;
        protected int yVelocity;
        protected Surface video;
        protected Surface image;
        public Rectangle colRectangle;
        

        public MoveableObject(Surface video)
        {
            this.video = video;
        }

        public abstract void Update(Level level);

        public abstract void Draw();

        
    }
}
