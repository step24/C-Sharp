using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace Тетрис
{
    class Square
    {
        bool flag;
        Color color;

        public Square(bool flag, Color color)
        {
            this.flag = flag;
            this.color = color;
        }

        public bool Flag
        {
            get
            {
                return flag;
            }
            set
            {
                flag = value;
            }
        }

        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        public static Square Empty
        {
           get
           {
               Square sql = new Square(false, Color.White);
               return sql;
           }
        }
    }
}