﻿using System;

namespace Coding.Exercise
{
    public class Square
    {
        public int Side;
    }

    public interface IRectangle
    {
        int Width { get; }
        int Height { get; }
    }

    public static class ExtensionMethods
    {
        public static int Area(this IRectangle rc)
        {
            return rc.Width * rc.Height;
        }
    }

    public class SquareToRectangleAdapter : IRectangle
    {
        public int Width { get; }
        public int Height { get; }

        public SquareToRectangleAdapter(Square square)
        {
            Width = square.Side;
            Height = square.Side;
        }
    }
}
