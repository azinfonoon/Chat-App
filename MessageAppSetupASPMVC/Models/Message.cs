namespace MessageAppSetupASPMVC.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsEdited { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
    }
}
