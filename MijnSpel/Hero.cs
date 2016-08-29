using SdlDotNet.Core;
using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MijnSpel
{
    public class Hero:MoveableObject 
    {
        //alle sprites
        private Surface image2;
        private Surface image3;
        private Surface image4;
        private Surface image5;
        
        
        
        //visible rectangle is voor de animatie
        private Rectangle visibleRectangle;
        
        
        //bools om beweging aan te geven
        private bool left; 
        private bool right;
        private bool up;
        private bool down;
        private bool space;
        private bool stil;
        
        

        public int gravity = -2;
        public int UpForce;
        public bool jump = false;
        private bool onGround;
        public bool dead = false;
        

        
        


  
        public Hero(Surface video):base(video)
        {
            
            image = new Surface(@"assets\stilstaan.png");
            image3 = new Surface(@"assets\links.png");
            image2 = new Surface(@"assets\rechts.png");
            image4 = new Surface(@"assets\down.png");
            image5 = new Surface(@"assets\Jump.png");
            
            

            visibleRectangle = new Rectangle(0, 0, 50,50);
            
            position = new Point(50,400);
            
            colRectangle = new Rectangle(position.X, position.Y, visibleRectangle.Width-10, visibleRectangle.Height-10);
            
            xVelocity = 4;
            yVelocity = 2;
            

            

            Events.KeyboardDown += Events_KeyboardDown;
            Events.KeyboardUp   +=Events_KeyboardUp;
            
            

        }

        private void Events_KeyboardUp(object sender, SdlDotNet.Input.KeyboardEventArgs e)
        {
            stil = up = down = left = right = false;
            space = false;
            
            

        }

        void Events_KeyboardDown(object sender, SdlDotNet.Input.KeyboardEventArgs e)
        {
            #region pijltjes
            if (e.Key == SdlDotNet.Input.Key.LeftArrow)
            {
                left = true;
                right = down = up = false;
            }
            if (e.Key == SdlDotNet.Input.Key.RightArrow)
            {
                right = true;
                up = down = left = false;
            }

            if (e.Key == SdlDotNet.Input.Key.UpArrow)
            {
                up = true;
                down = left = right = false;
            }

            if (e.Key == SdlDotNet.Input.Key.DownArrow)
            {
                down = true;
                up = left = right = false;
            }

            if (e.Key == SdlDotNet.Input.Key.Space)
            {
                space = true;
            }

            

           

            
            #endregion

        }

       

        int framedelay = 0;
        public override void Update(Level level)
        {
            framedelay++;
            colRectangle = new Rectangle(position.X, position.Y, visibleRectangle.Width, visibleRectangle.Height);
            onGround = false;

            #region collision
            foreach (blok blokske in level.spriteTileArray)
            {
                if (blokske != null)
                {


                    if (blokske is lucht) continue;
                    if (colRectangle.IntersectsWith(blokske.colRect))
                    {
                        if (blokske is Gras)
                        {
                            if (colRectangle.Bottom >= blokske.colRect.Top)
                            {
                                onGround = true;
                                UpForce = 0;
                            }
                            if (colRectangle.Top >= blokske.botRectangle.Bottom)
                            {
                                onGround = false;
                                UpForce = -10;
                            }

                        }
                        if (blokske is muur)
                        {
                            if (colRectangle.Right >= blokske.colRect.Left)
                            {
                                position.X -= xVelocity;
                            }


                        }
                    }
                }
            }
            #endregion

            #region bewegen

            if (left == true)
            {
                position.X -= xVelocity;
                
            }
            if (right == true)
            {
                position.X += xVelocity;
                
            }
            
                    if (left || right)
                    {
                
                    visibleRectangle.X += 50;
                    if (visibleRectangle.X >= 350)
                    {
                        visibleRectangle.X = 0;
                    }
                    
                    
                
          
            }
            if (left == false && right == false && up == false && down == false && space == false)
            {
                stil = true;
                visibleRectangle.X = 0;
            }

            

            

            
            #endregion

            


            colRectangle.X = position.X;
            colRectangle.Y = position.Y;

            #region jump
            
            if (space == true && onGround) {
                UpForce = 25;
                onGround = false;
            }
            if (!onGround)
            {
                UpForce += gravity;
            }
            position.Y -= UpForce;


            if (position.Y == 0)
            {
                position.Y -= yVelocity;
            }
            
            #endregion

            
            
        }
        

        public override void Draw() {
                video.Blit(image, position,visibleRectangle);
                if (left)
                {
                    video.Blit(image3, position, visibleRectangle);
                }
                if (right)
                {
                    video.Blit(image2, position, visibleRectangle);
                }
                if (stil)
                {
                    video.Blit(image, position, visibleRectangle);
                }
                if (down)
                {
                    video.Blit(image4, position, visibleRectangle);
                    
                    
                }
                if (jump)
                {
                    video.Blit(image5, position, visibleRectangle);
                    
                }
                
                video.Update();
                
        }
        
    
    }
}
