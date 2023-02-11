using Licitacija.Services.PredradnjeNadmetanjaAPI.DTOs;

namespace Licitacija.Services.PredradnjeNadmetanjaAPI.Mock
{
    public class MockRepository : IMockRepository
    {
        public static List<FazaDto> Faze { get; set; } = new List<FazaDto>();

        public MockRepository()
        {
            FillData();
        }

        private static void FillData()
        {
            Faze.AddRange(new List<FazaDto>
            {
                new FazaDto
                {
                    FazaId = Guid.Parse("8cea8fa5-af15-42df-927f-e2b41a1a827b"),
                    FazaNaziv = "Faza I"
                },
                new FazaDto
                {
                    FazaId = Guid.Parse("0420b473-dfdd-4d56-b806-66133bd11812"),
                    FazaNaziv = "Faza II"
                },
                new FazaDto
                {
                    FazaId = Guid.Parse("8223a486-4fc0-4ffb-a947-18f71fa4014e"),
                    FazaNaziv = "Faza III"
                }
            });
        }

        public FazaDto GetFazaById(Guid fazaId)
        {
            return Faze.FirstOrDefault(i => i.FazaId == fazaId);
        }
    }
}
