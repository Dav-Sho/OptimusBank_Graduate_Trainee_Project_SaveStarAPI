namespace SaveStarMoneyAPI.Dtos
{
    public class GetAccountDetailsDto
    {
        public long Id { get; set; }
        public string AccountName { get; set; } = string.Empty;
        public decimal CurrentAccountBalance { get; set; }
        public string AccountNumberGenerated { get; set; } = string.Empty;
    }
}
