namespace SaveStarMoneyAPI.Dtos
{
    public class GetFixedSavingDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SavingTitle { get; set; } = string.Empty;
        public double FixedAmount { get; set; }
        public String Frequency { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
    }
}
