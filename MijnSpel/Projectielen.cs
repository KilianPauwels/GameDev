using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MijnSpel
{
    public class Projectielen: MoveableObject
    {
        private List<Projectiel> projectielList = new List<Projectiel>();

        public void Add(Projectiel projectiel)
        {
            projectielList.Add(projectiel);
        }

        public void Remove(Projectiel projectiel)
        {
            projectielList.Remove(projectiel);
        }

        public void Display(Surface video)
        {
            for (int i = 0; i < projectielList.Count; i++)
            {
                video.Blit(projectielList[i]);
            }
        }

        public void Move()
        {
            for (int i = 0; i < laserList.Count; i++)
            {
                laserList[i].Move();
            }
        }

        public void CheckHit(Enemy enemy, Enemy enemy2, Enemy enemy3, Enemy enemy4)
        {
            for (int i = 0; i < laserList.Count; i++)
            {
                laserList[i].CheckHit(enemy,enemy2,enemy3,enemy4);
            }
        }
    }
}
