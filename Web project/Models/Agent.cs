namespace Web_project.Models
{
    public class Agent
    {
        public int AgentId { set; get; }
        public string Name { set; get; }

        public decimal Salary { set; get; }
        public string Password { set; get; }
        public string PhoneNumber { set; get; }
        public string Role { set; get; }
        public int CityId { set; get; }
        public City City { set; get; }
    }
}
