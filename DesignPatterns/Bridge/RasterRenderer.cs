using System;

namespace DesignPatterns.Bridge
{
    public class RasterRenderer : IRenderer
    {
        public void RenderCircule(float radius){
            Console.WriteLine($"Drawing pixels for circule with radius {radius}");
        }
    }
}