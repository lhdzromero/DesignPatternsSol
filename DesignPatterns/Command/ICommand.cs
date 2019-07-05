namespace DesignPatterns.Command
{
    public interface ICommand
    {
         void Call();
         void Undo();
    }
}