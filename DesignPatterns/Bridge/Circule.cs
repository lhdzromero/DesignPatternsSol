using System;

namespace DesignPatterns.Bridge
{
    public class Circule : Shape
    {
        private float radius;
        
        public Circule(IRenderer renderer, float radius): base(renderer){
            this.radius = radius;
        }
        
        public override void Draw(){
            renderer.RenderCircule(radius);
        }
        
        public override void Resize(float factor){
            radius *= factor;
        }
    }
}