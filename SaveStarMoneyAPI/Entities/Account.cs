namespace SaveStarMoneyAPI.Entities
{
    public class Account
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[0];
        public byte[] PasswordSalt { get; set; } = new byte[0];
        public decimal CurrentAccountBalance { get; set; }
        public string AccountNumberGenerated { get; set; } = string.Empty;
        public List<FixedSavingsEntity>? FixedSavings { get; set; }
        public List<PercentageSaving>? PercentageSavings { get; set; }
        public DateTime CreateAt { get; set; }

        Random random = new Random();

        public Account()
        {
            AccountNumberGenerated = Convert.ToString((long)Math.Floor(random.NextDouble() * 9_000_000_000 + 1_000_000_000));
            AccountName = FirstName + " " + LastName;
            CurrentAccountBalance = 0;
        }
    }
}
