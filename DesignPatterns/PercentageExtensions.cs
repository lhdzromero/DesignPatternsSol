//Ejemplo Value Proxy
namespace DesignPatterns
{
    public struct Percentage
    {
        private readonly float value;

        public Percentage(float value)
        {
            this.value = value;
        }

        public static float operator *(float f, Percentage p){
            return f * p.value;
        }

        public bool Equals(Percentage other){
            return value.Equals(other.value);
        }

        public override bool Equals(object obj){
            if(ReferenceEquals(null,obj)) return false;
            return obj is Percentage other && Equals(other);
        }

        public override int GetHashCode(){
            return value.GetHashCode();
        }

        public static bool operator ==(Percentage left, Percentage right){
            return left.Equals(right);
        }

        public static bool operator !=(Percentage left, Percentage right){
            return !left.Equals(right);
        }

        public static Percentage operator +(Percentage a, Percentage b){
            return new Percentage(a.value + b.value);
        }

        public override string ToString(){
            return $"{value * 100}%";
        }
    }

    public static class PorcentageExtensions 
    {
        public static Percentage Percent(this float value){
            return new Percentage(value / 100.0f);
        }

        public static Percentage Percent(this int value){
            return new Percentage(value / 100.0f);
        }
    }
}
