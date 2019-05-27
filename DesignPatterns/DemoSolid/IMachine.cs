namespace DesignPatterns.Solid
{
    //Interfaz de proposito general
    public interface IMachine {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }
}