namespace SaveStarMoneyAPI.Entities
{
    public class FixedSavingsEntity
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SavingTitle { get; set; } = string.Empty;
        public decimal FixedAmount { get; set; }
        public string Frequency { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public Account? Account { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
    }
}
