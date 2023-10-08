namespace ProductWebapp.Command
{
    public class Invoker
    {
        public List<Command> commands { get; set; } = new List<Command>();
        private static Invoker _instance { get; set; } = null;
        private Invoker() { }
        public static Invoker Instance()
        {
            if(_instance == null) return new Invoker();
            return _instance;
        }

        public void addCommand(Command command)
        {
            command.Execute();
            commands.Add(command);
        }
        public void removeCommand(Command command)
        {
            command.Unexecute();
            commands.Remove(command);
        }
    }
}
