namespace DesignPatterns.Solid
{
    
    public class Square : Rectangule
    {
        public override int Width { 
            set {base.Width = base.Height = value; }
         }

         public override int Height {
             set { base.Width = base.Height = value; }
         }
    }
}