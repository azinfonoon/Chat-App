using MessageAppSetupASPMVC.Models;

namespace MessageAppSetupASPMVC.Controllers
{
    internal class Student : Message
    {
        public string Id { get; set; }
        public object Name { get; set; }
        public object Email { get; set; }
        public object Age { get; set; }
    }
}