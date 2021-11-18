namespace ExpenserTracker.Application.DTO
{
    public class LoginRetorno_DTO : RetornoBase_DTO
    {
        public string JwtToken { get; set; }
        public string Nome { get; set; }
    }
}
