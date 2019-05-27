
namespace DesignPatterns.Solid
{
    public class Rectangule
    {
        public virtual int Height { get; set; }
        public virtual int Width { get; set; }

        public Rectangule(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }

        public Rectangule()
        {
            //do Something.
        }

        public override string ToString() => $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
    }
}