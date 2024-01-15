using System;

namespace Coding.Exercise
{
    public interface IRenderer
    {
        string WhatToRenderAs { get; }
    }
    public abstract class Shape
    {
        public IRenderer Renderer;
        public string Name { get; set; }
    }

    public class Triangle : Shape
    {
        public Triangle(IRenderer renderer)
        {
            Name = "Triangle";
            Renderer = renderer;
        }

        public override string ToString() => $"Drawing {Name} as {Renderer.WhatToRenderAs}";
    }

    public class Square : Shape
    {
        public Square(IRenderer renderer)
        {
            Name = "Square";
            Renderer = renderer;
        }

        public override string ToString() => $"Drawing {Name} as {Renderer.WhatToRenderAs}";
    }

    public class VectorRenderer : IRenderer
    {
        string IRenderer.WhatToRenderAs => "lines";
    }

    public class RasterRenderer : IRenderer
    {
        string IRenderer.WhatToRenderAs => "pixels";
    }
}