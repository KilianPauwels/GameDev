using MijnSpel;
using SdlDotNet.Audio;
using SdlDotNet.Core;
using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace MijnSpel
{
    class Manager
    {
        private Surface mVideo;
        private Surface GameOver;
        private Surface Win;
        private Hero hero;
        private Enemy enemy;
        private Enemy enemy2;
        private Enemy enemy3;
        private Enemy enemy4;
        private Enemy enemy5;
        private Enemy enemy6;
        private Surface BackGround;
        private int framedelay;
        private Level activelevel;


        Level Level1;
        Level Level2;
        Level level0;


        public Manager()
        {
            mVideo = Video.SetVideoMode(1350, 500, 32, false, false, false, true);
            hero = new Hero(mVideo);
            BackGround = new Surface(@"assets\background.png");
            GameOver = new Surface(@"assets\GameOver.png");
            Win = new Surface(@"assets\win.jpg");
            Music music = new Music(@"assets\sound.wav");
            MusicPlayer.Volume = 30;
            MusicPlayer.Load(music);
            MusicPlayer.Play();

            enemy = new Enemy(mVideo, new System.Drawing.Point(1200, 300));
            enemy2 = new Enemy(mVideo, new System.Drawing.Point(200, 300));
            enemy3 = new Enemy(mVideo, new System.Drawing.Point(900, 300));
            enemy4 = new Enemy(mVideo, new System.Drawing.Point(400, 200));
            Level1 = new level1(mVideo);
            Level2 = new level2(mVideo);
            level0 = new Level0(mVideo);
            activelevel = Level1;

            Events.Quit += Events_Quit;
            

            


            Events.Tick += Events_Tick;
            Events.Run();
        }

        void Events_Quit(object sender, QuitEventArgs e)
        {
            Events.QuitApplication();
        }

        void Events_Tick(object sender, TickEventArgs e)
        {

            #region activelevel code
            framedelay++;
                if (activelevel == Level1)
                {
                    mVideo.Blit(BackGround);
                    //mVideo.Blit(activelevel);
                    Level1.DrawWorld();
                    hero.Update(Level1);
                    hero.Draw();
                    enemy.Update(Level1);
                    enemy.Draw();
                    enemy2.Update(Level1);
                    enemy2.Draw();
                    enemy3.Update(Level1);
                    enemy3.Draw();
                    enemy4.Update(Level1);
                    enemy4.Draw();


                    mVideo.Update();
                }
                //de enemys hun positie in level 2 is nog niet helemaal in orde
                if (activelevel == Level1 && hero.position.X >= 1350)
                {
                    activelevel = Level2;
                    hero.position.X = 50;
                    hero.position.Y = 400;
                    enemy5 = new Enemy(mVideo, new System.Drawing.Point(100, 200));
                    enemy6 = new Enemy(mVideo, new System.Drawing.Point(850, 300));

                    enemy2.position.X = 650;
                    enemy2.position.Y = 400;
                    enemy2.start = 650;
                    enemy2.stop = 750;
                    
                    enemy4.position.X = 1100;
                    enemy4.position.Y = 250;
                    enemy4.start = 1100;
                    enemy4.stop = 1200;
                    

                }
                
                if (activelevel == Level2)
                {
                    
                    mVideo.Blit(BackGround);
                    
                    Level2.DrawWorld();
                    hero.Update(Level2);
                    hero.Draw();
                 
                    enemy2.Draw();
                    enemy2.Update(Level2);
                    enemy3.Draw();
                    enemy3.Update(Level2);
                    enemy4.Draw();
                    enemy4.Update(Level2);
                    enemy5.Draw();
                    enemy5.Update(Level2);
                    enemy6.Draw();
                    enemy6.Update(Level2);
                    mVideo.Update();

                    if (hero.colRectangle.IntersectsWith(enemy5.topRectangle))
                    {
                        Console.WriteLine("kill");
                        enemy5.position.Y = 600;
                        enemy5.colRectangle.Y = 600;
                    }
                    if (hero.colRectangle.IntersectsWith(enemy6.topRectangle))
                    {
                        Console.WriteLine("kill");
                        enemy6.position.Y = 600;
                        enemy6.colRectangle.Y = 600;
                    }
                    if (enemy5.colRectangle.IntersectsWith(hero.colRectangle))
                    {
                        Console.WriteLine("raak");
                        activelevel = level0;
                        mVideo.Blit(GameOver);
                        mVideo.Update();
                        Events.Tick -= Events_Tick;
                    }
                    if (enemy6.colRectangle.IntersectsWith(hero.colRectangle))
                    {
                        Console.WriteLine("raak");
                        activelevel = level0;
                        mVideo.Blit(GameOver);
                        mVideo.Update();
                        Events.Tick -= Events_Tick;
                    }
                }

            #endregion

                //vallen = game over
                if (hero.position.Y >= 500)
                {
                    Console.WriteLine("dood");
                    activelevel = level0;
                    mVideo.Blit(GameOver);
                    mVideo.Update();
                    Events.Tick -= Events_Tick;
                }


                #region kill condition

                if (hero.colRectangle.IntersectsWith(enemy2.topRectangle))
                {
                    Console.WriteLine("kill");
                    enemy2.position.Y = 600;
                    enemy2.colRectangle.Y = 600;
                }
                if (hero.colRectangle.IntersectsWith(enemy3.topRectangle))
                {
                    Console.WriteLine("kill");
                    enemy3.position.Y = 600;
                    enemy3.colRectangle.Y = 600;
                }
                if (hero.colRectangle.IntersectsWith(enemy4.topRectangle))
                {
                    Console.WriteLine("kill");
                    enemy4.position.Y = 600;
                    enemy4.colRectangle.Y = 600;
                }
                if (hero.colRectangle.IntersectsWith(enemy.topRectangle))
                {
                    Console.WriteLine("kill");
                    enemy.position.Y = 600;
                    enemy.colRectangle.Y = 600;
                }
                
                #endregion

                #region enemycollision
                if (enemy3.colRectangle.IntersectsWith(hero.colRectangle))
            {
                Console.WriteLine("raaaaaak!!");
                
                activelevel = level0;
                mVideo.Blit(GameOver);
                mVideo.Update();
                Events.Tick -= Events_Tick;
            }

            
            if (enemy2.colRectangle.IntersectsWith(hero.colRectangle))
            {
                Console.WriteLine("raak");
                activelevel = level0;
                mVideo.Blit(GameOver);
                mVideo.Update();
                Events.Tick -= Events_Tick;
            }

            if (enemy.colRectangle.IntersectsWith(hero.colRectangle))
            {
                Console.WriteLine("raak");
                activelevel = level0;
                mVideo.Blit(GameOver);
                mVideo.Update();
                Events.Tick -= Events_Tick;
            }



            if (enemy4.colRectangle.IntersectsWith(hero.colRectangle))
            {
                Console.WriteLine("raak");
                activelevel = level0;
                mVideo.Blit(GameOver);
                mVideo.Update();
                Events.Tick -= Events_Tick;
            }
            

            
                #endregion
            #region wincondition
            if (activelevel == Level2 && hero.position.X >= 1350)
            {
                activelevel = level0;
                mVideo.Blit(Win);
                mVideo.Update();
                Events.Tick -= Events_Tick;
            }
            #endregion

        }
    }
}
