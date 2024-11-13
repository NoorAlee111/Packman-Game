using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace packmanwithoop
{
    class Grid
    {
        private Cell[,] maze;
        private int rowSize;
        private int colSize;
        public Grid(int rowSize, int colSize, string path)
        {
            this.rowSize = rowSize;
            this.colSize = colSize;
            int x = 0;
            StreamReader fp = new StreamReader(path);
            string record;
            this.maze = new Cell[rowSize, colSize];
            while ((record = fp.ReadLine()) != null)
            {
                if(x==rowSize)
                {
                    break;
                }

                    for (int y = 0; y < colSize; y++)
                    {
                        Cell c = new Cell(record[y], x, y);
                        maze[x, y] = c;
                    }
                x++;
            }
            fp.Close();
        }
        public Cell getcell(int x,int y)
        {
            return maze[x, y];
        }
        public void setMazeGridCell(int x,int y,char c)
        {
            maze[x, y].setValue(c);
        }
        public Cell getleftcell(Cell c)
        {
            int colno = c.gety();
            int rowno = c.getx();
            Cell leftcell = new Cell();
            leftcell = maze[rowno, colno - 1];
            return leftcell;
        }
        public Cell getrightcell(Cell c)
        {
            int colno = c.gety();
            int rowno = c.getx();
            Cell rightcell = new Cell();
            rightcell = maze[rowno, colno + 1];
            return rightcell;
        }
        public Cell getupcell(Cell c)
        {
            int colno = c.gety();
            int rowno = c.getx();
            Cell upcell = new Cell();
            upcell = maze[rowno-1 , colno];
            return upcell;
        }
        public Cell getdowncell(Cell c)
        {
            int colno = c.gety();
            int rowno = c.getx();
            Cell downcell = new Cell();
            downcell = maze[rowno + 1, colno];
            return downcell;
        }
        public Cell FindPackman()
        {
            
            for (int x = 0; x < rowSize; x++)
            {
                for (int y = 0; y < colSize; y++)
                {
                    Cell c = new Cell('P',x,y);
                    bool Result = c.IsPackManPresent();                    
                    if(Result==true)
                    {
                        return c;
                    }
                }
            }
            return null;
        }
        public Cell FindGhost(char GhostCharacter)
        {
            Cell c=new Cell();
            for (int x = 0; x < rowSize; x++)
            {
                for (int y = 0; y < colSize; y++)
                {

                    if (maze[x, y].IsGhostPresent(GhostCharacter) == true)
                    {
                        c = maze[x, y];
                    }
                }
            }
            return c;
        }
        public void draw()
        {
            for (int x = 0; x < rowSize - 1; x++)
            {
                for (int y = 0; y < colSize; y++)
                {
                    Console.Write(maze[x, y].getValue());
                }
                Console.WriteLine();
            }
        }
        public bool isWinningCondition()
        {
            Packman P = new Packman();
            if (P.GetX() == 4 && P.GetY()==4 &&Packman.getscore() >= 50)
            {
                return true;
            }
            return false;
        }

    }
 }

