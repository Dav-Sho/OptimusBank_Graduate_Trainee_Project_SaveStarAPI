namespace SaveStarMoneyAPI.Dtos
{
    public class FixedSavingDto
    {
        public string SavingTitle { get; set; } = string.Empty;
        public decimal FixedAmount { get; set; }
        public string Frequency { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
    }
}
