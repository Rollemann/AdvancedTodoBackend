namespace TodoList.Domain{
    public class Schedule
    {
        public int Id { get; set; }
        public string CronString { get; set; }
        public int Repetitions { get; set; }
    }
}
