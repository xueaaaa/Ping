namespace Ping.Models.Task
{
    internal interface ITask
    {
        public void MarkCompleted();
        public void Save();
        public void Delete();
    }
}
