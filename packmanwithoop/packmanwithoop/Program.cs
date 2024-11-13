using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using packmanwithoop;
using System.Threading;

namespace packmanwithoop
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\DELL\\source\\repos\\packmanwithoop\\packman.txt";
            Grid mazeGrid=new Grid(24,69,path);
            Packman player = new Packman(9, 31, mazeGrid);
            Ghost ghost1 = new Ghost(4, 31, 'H', "right", 0.1F, ' ', mazeGrid);
            Ghost ghost2 = new Ghost(12, 2, 'V', "up", 0.2F, ' ', mazeGrid);
            Ghost ghost3 = new Ghost(1, 38, 'R', "up", 1F, ' ', mazeGrid);
            Ghost ghost4 = new Ghost(19, 25, 'C', "up", 0.5F, ' ', mazeGrid);
            List<Ghost> enemies = new List<Ghost>();
            enemies.Add(ghost1);
            enemies.Add(ghost2);
            enemies.Add(ghost3);
            enemies.Add(ghost4);

            mazeGrid.draw();
            player.draw();
            bool gamerunning = true;
            while(gamerunning)
            {
                Thread.Sleep(100);
                player.PrintScore();
                player.erase();
                player.move();
                player.draw();

                foreach(Ghost g in enemies)
                {
                    g.erase();
                    g.move();
                    g.draw();
                   
                }
                if(mazeGrid.isWinningCondition()==true)
                {
                    gamerunning = false;
                }
            }
            
        }
    }
}
