﻿namespace SaveStarMoneyAPI.Dtos
{
    public class AccountDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal CurrentAccountBalance { get; set; }
        public string password { get; set; } = string.Empty;
    }
}
