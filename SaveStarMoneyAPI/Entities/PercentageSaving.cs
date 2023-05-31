namespace SaveStarMoneyAPI.Entities
{
    public class PercentageSaving
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SavingTitle { get; set; } = string.Empty;
        public int Percentage { get; set; }
        public string Frequency { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public decimal PercentageAmount { get; set; }
        public Account? Account { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
