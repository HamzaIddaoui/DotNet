namespace ProductWebapp.Command
{
    public abstract class Command
    {
        public abstract void Execute();
        public abstract void Unexecute();
    }
}
