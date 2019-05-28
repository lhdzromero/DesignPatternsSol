using System;

namespace DesignPatterns.Bridge
{
    public class VectorRenderer : IRenderer
    {
        public void RenderCircule(float radius){
            Console.WriteLine($"Drawing a circule of radius {radius}");
        }
    }
}