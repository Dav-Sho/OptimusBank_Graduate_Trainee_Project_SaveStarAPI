namespace SaveStarMoneyAPI.Dtos
{
    public class GetPercentageSavingsDetailsDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SavingTitle { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
    }
}
