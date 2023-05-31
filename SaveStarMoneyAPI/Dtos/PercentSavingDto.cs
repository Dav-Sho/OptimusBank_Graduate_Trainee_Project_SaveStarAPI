namespace SaveStarMoneyAPI.Dtos
{
    public class PercentSavingDto
    {
        public string SavingTitle { get; set; } = string.Empty;
        public int Percentage { get; set; }
        public string Frequency { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
    }
}
