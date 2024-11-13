using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace packmanwithoop
{
    class Cell
    {
        private char value;
        private int x;
        private int y;
        public Cell(char value, int x, int y)
        {
            this.value = value;
            this.x = x;
            this.y = y;
        }
        public Cell( int x, int y)
        {
          
            this.x = x;
            this.y = y;
        }
        public Cell()
        {

        }
        public char getValue()
        {
            return value;
        }
        public void setValue(char value)
        {
            this.value = value;
        }
        public int getx()
        {
            return x;
        }
        public int gety()
        {
            return y;
        }
        public bool IsPackManPresent()
        {
            if (value=='P')
            {
                return true;
            }
            return false;
        }
        public bool IsGhostPresent(char GhostCharacter)
        {
            if (value ==GhostCharacter)
            {
                return true;
            }
            return false;
        }
    }
}
