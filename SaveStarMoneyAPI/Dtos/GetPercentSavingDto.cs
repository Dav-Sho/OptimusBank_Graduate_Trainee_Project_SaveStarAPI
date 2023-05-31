namespace SaveStarMoneyAPI.Dtos
{
    public class GetPercentSavingDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SavingTitle { get; set; } = string.Empty;
        public double PercentageAmount { get; set; }
        public String Frequency { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
    }
}
