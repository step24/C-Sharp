using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Тетрис
{
    /// <summary>
    /// Здесь описываются все фигурки, которые появляются
    /// </summary>

    struct Location
    {
        public int i;
        public int j;
    }

    struct StartPosition
    {
        public int I;
        public int J;
    }

    enum FigureLocation
    {
        Up, Right, Down, Left
    }

    class BaseFigure
    {
        protected int number;
        protected Square[,] fi = new Square[4, 4];
        protected FigureLocation lockation;
        protected StartPosition position;

        public BaseFigure(int N, StartPosition position)
        {
            number = N;
            lockation = FigureLocation.Up;
            this.position = position;

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    fi[i, j] = Square.Empty;
        }

        public BaseFigure(int N, Color c, FigureLocation f, StartPosition position)
        {
            number = N;
            lockation = f;
            this.position = position;

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    fi[i, j] = Square.Empty;
        }

        public Square[,] Fi
        {
            get
            {
                return fi;
            }
        }

        public int Number
        {
            get
            {
                return number;
            }
        }

        public StartPosition Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public int PositionI
        {
            get
            {
                return position.I;
            }
            set
            {
                position.I = value;
            }
        }

        public int PositionJ
        {
            get
            {
                return position.J;
            }
            set
            {
                position.J = value;
            }
        }

        public FigureLocation Location
        {
            get
            {
                return lockation;
            }
        }

        public virtual BaseFigure CreateF()
        {
            return this;
        }

        public virtual BaseFigure NextLocation()
        {
            return this;
        }

        public Color RandomColor(Random r)
        {
            Color c = Color.Violet;

            switch (r.Next(1, 8))
            {
                case 1: c = Color.Red; break;
                case 2: c = Color.Orange; break;
                case 3: c = Color.DarkGoldenrod; break;
                case 4: c = Color.Green; break;
                case 5: c = Color.CornflowerBlue; break;
                case 6: c = Color.DarkBlue; break;
                case 7: c = Color.BlueViolet; break;
            }
            return c;
        }

        public void ChangeFigure(Location[] a, Color c)
        {
            for (int h = 0; h < a.Length; h++)
            {
                fi[a[h].i, a[h].j] = new Square(true, c);
            }
        }
    }

    
    class Figure1 : BaseFigure
    {
        public Figure1(Random r, StartPosition position)
            : base(1, position)
        {
            Location[] a = new Location[4];

            a[0].i = 0; a[0].j = 0;
            a[1].i = 0; a[1].j = 1;
            a[2].i = 0; a[2].j = 2;
            a[3].i = 0; a[3].j = 3;

            Color c = this.RandomColor(r);

            this.ChangeFigure(a, c);
        }

        Figure1(int N, Color c, FigureLocation f, StartPosition position)
            : base(N, c, f, position)
        {
        }

        public override BaseFigure NextLocation()
        {
            FigureLocation l = this.lockation;
            FigureLocation newLocation = (int)l == 3 ? FigureLocation.Up : l + 1;
            Color c = Color.Violet;
            for (int i = 0; i < this.fi.GetLength(0); i++)
                for (int j = 0; j < this.fi.GetLength(1); j++)
                    if (fi[i, j].Color != Color.White)
                        c = fi[i, j].Color;
            StartPosition position = this.position;

            Figure1 bf = new Figure1(1, c, newLocation, position);
            Location[] a = new Location[4];
            if (l == FigureLocation.Up || l == FigureLocation.Down)
            {
                a[0].i = 0; a[0].j = 0;
                a[1].i = 1; a[1].j = 0;
                a[2].i = 2; a[2].j = 0;
                a[3].i = 3; a[3].j = 0;
            }
            if (l == FigureLocation.Left || l == FigureLocation.Right)
            {
                a[0].i = 0; a[0].j = 0;
                a[1].i = 0; a[1].j = 1;
                a[2].i = 0; a[2].j = 2;
                a[3].i = 0; a[3].j = 3;
            }
            bf.ChangeFigure(a, c);
            return bf;
        }
    }

    class Figure2 : BaseFigure
    {
        public Figure2(Random r, StartPosition position)
            : base(2, position)
        {
            Location[] a = new Location[4];
            a[0].i = 0; a[0].j = 0;
            a[1].i = 1; a[1].j = 0;
            a[2].i = 0; a[2].j = 1;
            a[3].i = 1; a[3].j = 1;

            Color c = this.RandomColor(r);

            this.ChangeFigure(a, c);
        }

        Figure2(int N, Color c, FigureLocation f, StartPosition position)
            : base(N, c, f, position)
        {
        }

        public override BaseFigure NextLocation()
        {
            return this;
        }
    }

    class Figure3 : BaseFigure
    {
        public Figure3(Random r, StartPosition position)
            : base(3, position)
        {
            Location[] a = new Location[4];
            a[0].i = 0; a[0].j = 0;
            a[1].i = 0; a[1].j = 1;
            a[2].i = 1; a[2].j = 1;
            a[3].i = 1; a[3].j = 2;

            Color c = this.RandomColor(r);

            this.ChangeFigure(a, c);
        }

        Figure3(int N, Color c, FigureLocation f, StartPosition position)
            : base(N, c, f, position)
        {
        }

        public override BaseFigure NextLocation()
        {
            FigureLocation l = this.lockation;
            FigureLocation newLocation = (int)l == 3 ? FigureLocation.Up : l + 1;
            Color c = Color.Violet;
            for (int i = 0; i < this.fi.GetLength(0); i++)
                for (int j = 0; j < this.fi.GetLength(1); j++)
                    if (fi[i, j].Color != Color.White)
                        c = fi[i, j].Color;

            StartPosition position = this.position;

            Figure3 bf = new Figure3(3, c, newLocation, position);
            Location[] a = new Location[4];
            if (l == FigureLocation.Up || l == FigureLocation.Down)
            {
                a[0].i = 0; a[0].j = 1;
                a[1].i = 1; a[1].j = 0;
                a[2].i = 1; a[2].j = 1;
                a[3].i = 2; a[3].j = 0;
            }
            if (l == FigureLocation.Left || l == FigureLocation.Right)
            {
                a[0].i = 0; a[0].j = 0;
                a[1].i = 0; a[1].j = 1;
                a[2].i = 1; a[2].j = 1;
                a[3].i = 1; a[3].j = 2;
            }
            bf.ChangeFigure(a, c);
            return bf;
        }
    }

    class Figure4 : BaseFigure
    {
        public Figure4(Random r, StartPosition position)
            : base(4, position)
        {
            Location[] a = new Location[4];
            a[0].i = 0; a[0].j = 1;
            a[1].i = 0; a[1].j = 2;
            a[2].i = 1; a[2].j = 0;
            a[3].i = 1; a[3].j = 1;

            Color c = this.RandomColor(r);

            this.ChangeFigure(a, c);
        }

        Figure4(int N, Color c, FigureLocation f, StartPosition position)
            : base(N, c, f, position)
        {
        }

        public override BaseFigure NextLocation()
        {
            FigureLocation l = this.lockation;
            FigureLocation newLocation = (int)l == 3 ? FigureLocation.Up : l + 1;
            Color c = Color.Violet;
            for (int i = 0; i < this.fi.GetLength(0); i++)
                for (int j = 0; j < this.fi.GetLength(1); j++)
                    if (fi[i, j].Color != Color.White)
                        c = fi[i, j].Color;
            StartPosition position = this.position;

            Figure4 bf = new Figure4(4, c, newLocation, position);
            Location[] a = new Location[4];
            if (l == FigureLocation.Up || l == FigureLocation.Down)
            {
                a[0].i = 0; a[0].j = 0;
                a[1].i = 1; a[1].j = 0;
                a[2].i = 1; a[2].j = 1;
                a[3].i = 2; a[3].j = 1;
            }
            if (l == FigureLocation.Left || l == FigureLocation.Right)
            {
                a[0].i = 0; a[0].j = 1;
                a[1].i = 0; a[1].j = 2;
                a[2].i = 1; a[2].j = 0;
                a[3].i = 1; a[3].j = 1;
            }
            bf.ChangeFigure(a, c);
            return bf;
        }
    }

    class Figure5 : BaseFigure
    {
        public Figure5(Random r, StartPosition position)
            : base(5, position)
        {
            Location[] a = new Location[4];
            a[0].i = 0; a[0].j = 0;
            a[1].i = 0; a[1].j = 1;
            a[2].i = 0; a[2].j = 2;
            a[3].i = 1; a[3].j = 2;

            Color c = this.RandomColor(r);

            this.ChangeFigure(a, c);
        }

        Figure5(int N, Color c, FigureLocation f, StartPosition position)
            : base(N, c, f, position)
        {
        }

        public override BaseFigure NextLocation()
        {
            FigureLocation l = this.lockation;
            FigureLocation newLocation = (int)l == 3 ? FigureLocation.Up : l + 1;
            Color c = Color.Violet;
            for (int i = 0; i < this.fi.GetLength(0); i++)
                for (int j = 0; j < this.fi.GetLength(1); j++)
                    if (fi[i, j].Color != Color.White)
                        c = fi[i, j].Color;
            StartPosition position = this.position;

            Figure5 bf = new Figure5(5, c, newLocation, position);
            Location[] a = new Location[4];
            if (l == FigureLocation.Up)
            {
                a[0].i = 2; a[0].j = 0;
                a[1].i = 1; a[1].j = 0;
                a[2].i = 0; a[2].j = 0;
                a[3].i = 0; a[3].j = 1;
            }
            if (l == FigureLocation.Right)
            {
                a[0].i = 0; a[0].j = 0;
                a[1].i = 1; a[1].j = 0;
                a[2].i = 1; a[2].j = 1;
                a[3].i = 1; a[3].j = 2;
            }
            if (l == FigureLocation.Down)
            {
                a[0].i = 0; a[0].j = 1;
                a[1].i = 1; a[1].j = 1;
                a[2].i = 2; a[2].j = 1;
                a[3].i = 2; a[3].j = 0;
            }
            if (l == FigureLocation.Left)
            {
                a[0].i = 0; a[0].j = 0;
                a[1].i = 0; a[1].j = 1;
                a[2].i = 0; a[2].j = 2;
                a[3].i = 1; a[3].j = 2;
            }
            bf.ChangeFigure(a, c);
            return bf;
        }
    }

    class Figure6 : BaseFigure
    {
        public Figure6(Random r, StartPosition position)
            : base(6, position)
        {
            Location[] a = new Location[4];
            a[0].i = 0; a[0].j = 2;
            a[1].i = 1; a[1].j = 2;
            a[2].i = 1; a[2].j = 1;
            a[3].i = 1; a[3].j = 0;

            Color c = this.RandomColor(r);

            this.ChangeFigure(a, c);
        }

        Figure6(int N, Color c, FigureLocation f, StartPosition position)
            : base(N, c, f, position)
        {
        }

        public override BaseFigure NextLocation()
        {
            FigureLocation l = this.lockation;
            FigureLocation newLocation = (int)l == 3 ? FigureLocation.Up : l + 1;
            Color c = Color.Violet;
            for (int i = 0; i < this.fi.GetLength(0); i++)
                for (int j = 0; j < this.fi.GetLength(1); j++)
                    if (fi[i, j].Color != Color.White)
                        c = fi[i, j].Color;
            StartPosition position = this.position;

            Figure6 bf = new Figure6(6, c, newLocation, position);
            Location[] a = new Location[4];
            if (l == FigureLocation.Up)
            {
                a[0].i = 0; a[0].j = 0;
                a[1].i = 0; a[1].j = 1;
                a[2].i = 1; a[2].j = 1;
                a[3].i = 2; a[3].j = 1;

            }
            if (l == FigureLocation.Right)
            {
                a[0].i = 1; a[0].j = 0;
                a[1].i = 0; a[1].j = 0;
                a[2].i = 0; a[2].j = 1;
                a[3].i = 0; a[3].j = 2;
            }
            if (l == FigureLocation.Down)
            {
                a[0].i = 2; a[0].j = 1;
                a[1].i = 2; a[1].j = 0;
                a[2].i = 1; a[2].j = 0;
                a[3].i = 0; a[3].j = 0;
            }
            if (l == FigureLocation.Left)
            {
                a[0].i = 0; a[0].j = 2;
                a[1].i = 1; a[1].j = 2;
                a[2].i = 1; a[2].j = 1;
                a[3].i = 1; a[3].j = 0;
            }
            bf.ChangeFigure(a, c);
            return bf;
        }
    }

    class Figure7 : BaseFigure
    {
        public Figure7(Random r, StartPosition position)
            : base(7, position)
        {
            Location[] a = new Location[4];
            a[0].i = 0; a[0].j = 0;
            a[1].i = 0; a[1].j = 1;
            a[2].i = 0; a[2].j = 2;
            a[3].i = 1; a[3].j = 1;

            Color c = this.RandomColor(r);

            this.ChangeFigure(a, c);
        }

        Figure7(int N, Color c, FigureLocation f, StartPosition position)
            : base(N, c, f, position)
        {
        }

        public override BaseFigure NextLocation()
        {
            FigureLocation l = this.lockation;
            FigureLocation newLocation = (int)l == 3 ? FigureLocation.Up : l + 1;
            Color c = Color.Violet;
            for (int i = 0; i < this.fi.GetLength(0); i++)
                for (int j = 0; j < this.fi.GetLength(1); j++)
                    if (fi[i, j].Color != Color.White)
                        c = fi[i, j].Color;
            StartPosition position = this.position;

            Figure7 bf = new Figure7(7, c, newLocation, position);
            Location[] a = new Location[4];
            if (l == FigureLocation.Up)
            {
                a[0].i = 0; a[0].j = 0;
                a[1].i = 1; a[1].j = 0;
                a[2].i = 2; a[2].j = 0;
                a[3].i = 1; a[3].j = 1;
            }
            if (l == FigureLocation.Right)
            {
                a[0].i = 1; a[0].j = 0;
                a[1].i = 1; a[1].j = 1;
                a[2].i = 1; a[2].j = 2;
                a[3].i = 0; a[3].j = 1;
            }
            if (l == FigureLocation.Down)
            {
                a[0].i = 0; a[0].j = 1;
                a[1].i = 1; a[1].j = 1;
                a[2].i = 2; a[2].j = 1;
                a[3].i = 1; a[3].j = 0;
            }
            if (l == FigureLocation.Left)
            {
                a[0].i = 0; a[0].j = 0;
                a[1].i = 0; a[1].j = 1;
                a[2].i = 0; a[2].j = 2;
                a[3].i = 1; a[3].j = 1;
            }
            bf.ChangeFigure(a, c);
            return bf;
        }
    }
}