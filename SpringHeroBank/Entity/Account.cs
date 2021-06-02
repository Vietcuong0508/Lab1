using System;

namespace SpringHeroBank.Entity
{
    public class Account
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public double Balance { get; set; }
        public string PhoneNumber { get; set; }
        public string CardNumber { get; set; }
        public int Status { get; set; }
        public string Birthday { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}