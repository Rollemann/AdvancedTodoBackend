namespace TodoList.Domain
{
    public class TodoItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Schedule Schedule { get; set; }
        public bool IsCompleted { get; set; }
    }
}
