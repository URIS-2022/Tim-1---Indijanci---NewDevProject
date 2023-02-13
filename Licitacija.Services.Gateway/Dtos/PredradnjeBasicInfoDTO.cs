namespace Licitacija.Services.Gateway.Dtos
{

    public class PredradnjeBasicInfoDto
    {
        public Guid PredradnjeNadmetanjaId { get; set; }

        public string PredradnjeNadmetanjaNaziv { get; set; } = String.Empty;
    }
}
