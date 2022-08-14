using System.ComponentModel.DataAnnotations;

namespace FinalProject.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
