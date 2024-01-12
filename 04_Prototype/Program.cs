using System;

namespace Coding.Exercise
{
    public class Point
    {
        public int X, Y;

        public Point()
        {
            X = 0;
            Y = 0;
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point DeepCopy()
        {
            return new Point(X, Y);
        }
    }

    public class Line
    {
        public Point Start, End;

        // Needed because the tests call this
        public Line()
        {
            Start = new Point();
            End = new Point();
        }

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public Line DeepCopy()
        {
            return new Line(Start.DeepCopy(), End.DeepCopy());
        }
    }
}
