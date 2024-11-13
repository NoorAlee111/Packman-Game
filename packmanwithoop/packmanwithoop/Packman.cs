using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;

namespace packmanwithoop
{
    class Packman
    {
        private int x;
        private int y;
        private static int score;
        private Grid mazegrid;
      
        public Packman()
        {

        }
        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }
        public Packman(int x,int y, Grid mazegrid)
        {
            this.x=x;
            this.y = y;
            this.mazegrid = mazegrid;
        }
        public void draw()
        {
            Console.SetCursorPosition(y ,x);
            Console.Write('P');
        }
        public void erase()
        {
            Console.SetCursorPosition(y, x);
            Console.Write(' ');
        }
        public bool checkpackmanmovementstatus(int x, int y)
        {
            char value = mazegrid.getcell(x, y).getValue();
            if (value == ' ' || value == '.' )
            {
                if(value == '.')
                {
                    score++;
                }
                return true;
            }
            return false;

        }
        public void moveLeft()
        {
            if(checkpackmanmovementstatus(x, y - 1))
            {
               
                y = y - 1;
              
            }
           
        }
        public void moveRight()
        {
            if (checkpackmanmovementstatus(x, y+ 1))
            {
              
                y = y + 1;
                
            }
               
        }
        public void moveUp()
        {
            if (checkpackmanmovementstatus(x-1,y)==true)
            {
              
                x = x - 1;
                

            }
               
        }
        public void moveDown()
        {
            if (checkpackmanmovementstatus(x + 1, y) == true)
            {
              
                x = x + 1;
              
            }
        }
        public void move()
        {
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                moveUp();
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                moveDown();
            }
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                moveLeft();
            }
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                moveRight();
            }
        }
        public void PrintScore()
        {
            Console.SetCursorPosition(75, 4);
            Console.Write("score:"+score);
        }
        public static int getscore()
        {
            return score;
        }
    }
}
