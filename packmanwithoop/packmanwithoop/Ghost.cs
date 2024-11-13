using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace packmanwithoop
{
    class Ghost
    {
        private int x;
        private int y;
        private string ghostDirection;
        private char ghostCharacter;
        private float speed;
        private char previousItem;
        private float deltaChannge;
      
       private Grid MazeGrid;
        public Ghost(int x,int y, char ghostCharacter, string ghostDirection,float speed, char previousItem, Grid MazeGrid)
        {
            this.x = x;
            this.y = y;
            this.ghostCharacter = ghostCharacter;
            this.ghostDirection = ghostDirection;
            this.speed= speed;
            this.previousItem = previousItem;
            this.MazeGrid = MazeGrid;
        }
        public void setDirection(string ghostDirection)
        {
            this.ghostDirection = ghostDirection;
        }
        public string getDirection()
        {
            return ghostDirection;
        }
        public char getCharacter()
        {
            return ghostCharacter;
        }
        public void changeDelta()
        {
            deltaChannge = deltaChannge + speed;
        }
        public float getDelta()
        {
            return deltaChannge;
        }
        public void setDeltaZero()
        {
            deltaChannge = 0;
        }
        public void draw()
        {
            Console.SetCursorPosition(y, x);
            previousItem = MazeGrid.getcell(x,y).getValue();
            Console.Write(ghostCharacter);
        }
        public void erase()
        {
            Console.SetCursorPosition(y, x);
            Console.Write(previousItem);
        }
        public bool checkghostmovementstatus(int x,int y)
        {
            char value = MazeGrid.getcell(x, y).getValue();
            if(value==' '||value=='.'||value=='P')
            {
                return true;
            }
            return false;

        }
     
        public void movehorizontal()
        {
           
            if (ghostDirection == "right")
            {
               
                if(checkghostmovementstatus(x, y + 1) == true)
                {
                    y = y + 1;
                }
                else
                {
                    ghostDirection = "left";
                }
            }
            else if(ghostDirection == "left")
            {
               
                if (checkghostmovementstatus(x, y -1) == true)
                {
                    y = y - 1;
                }
                else
                {
                    ghostDirection = "right";
                }
            }
        }
        public void movevertical()
        {
            if (ghostDirection == "up")
            {

                if (checkghostmovementstatus(x-1, y) == true)
                {
                    x = x - 1;
                }
                else
                {
                    ghostDirection = "down";
                }
            }
            else if (ghostDirection == "down")
            {

                if (checkghostmovementstatus(x+1, y) == true)
                {
                    x = x+ 1;
                }
                else
                {
                    ghostDirection = "up";
                }
            }
        }
       public int GenerateRandom()
        {
            Random r = new Random();
            int value = r.Next(4);
            return value;
        }
        public void RandomeMovement()
        {
            int value = GenerateRandom();
            if(value==0)
            {
                if (checkghostmovementstatus(x , y-1) == true)//for left movement
                {
                    y = y - 1;
                }
            }
            else if(value==1)
            {
                if (checkghostmovementstatus(x, y + 1) == true)//for right movement
                {
                    y = y + 1;
                }
            }
            else if (value == 2)
            {
                if (checkghostmovementstatus(x-1, y) == true)// for up movement
                {
                    x = x - 1;
                }
            }
            else if (value == 3)
            {
                if (checkghostmovementstatus(x + 1, y) == true)//for down movement
                {
                    x = x + 1;
                }
            }
        }
        public double calculateDistance(int X,int Y,Cell packmanlocation)
        {
            return Math.Sqrt(Math.Pow((packmanlocation.getx() - X), 2) + Math.Pow((packmanlocation.gety() - Y), 2));
        }
        public void movesmart()
        {
            Cell packmanlocation = new Cell();
            packmanlocation = MazeGrid.FindPackman();
            double[] distance = new double[4] { 1000000, 1000000, 1000000, 1000000 };
       
            distance[0] = (calculateDistance(x, y - 1, packmanlocation));
            distance[1] = (calculateDistance(x, y + 1, packmanlocation));
            distance[2] = (calculateDistance(x + 1, y, packmanlocation));
            distance[3] = (calculateDistance(x - 1, y, packmanlocation));
            if (distance[0] <= distance[1] && distance[0] <= distance[2] && distance[0] <= distance[3])
            {
                if (checkghostmovementstatus(x, y - 1) == true)//for left movement
                {
                    y = y - 1;
                }
            }
            if (distance[1] <= distance[0] && distance[1] <= distance[2] && distance[1] <= distance[3])
            {
                if (checkghostmovementstatus(x, y + 1) == true)//for right movement
                {
                    y = y + 1;
                }
            }
            if (distance[2] <= distance[0] && distance[2] <= distance[1] && distance[2] <= distance[3])
            {
                if (checkghostmovementstatus(x + 1, y) == true)//for down movement
                {
                    x = x + 1;
                }
            }
            else
            {

                if (checkghostmovementstatus(x - 1, y) == true)// for up movement
                {
                    x = x - 1;
                }
            }
            }
        public void move()
        {
            changeDelta();
            if(Math.Floor(getDelta())==1)
            {
                if(ghostCharacter=='H')
                {
                    movehorizontal();
                }
                else if(ghostCharacter=='V')
                {
                    movevertical();
                }
                else if(ghostCharacter=='R')
                {
                    RandomeMovement();
                }
                else if (ghostCharacter == 'C')
                {
                    movesmart();
                }
                setDeltaZero();
            }
        }
    }
}
