using Licitacija.Services.DokumentAPI.Entities;

namespace Licitacija.Services.DokumentAPI.DbConexts
{
    public class DataSeeder
    {
        private readonly DataContext _context;

        public DataSeeder(DataContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.TipGarancije.Any())
            {
                var tipoviGarancije = new List<TipGarancije>()
                {
                    new TipGarancije()
                    {
                        TipGarancijeId = Guid.NewGuid(),
                        TipGarancijeNaziv = "Jemstvo"
                    },
                    new TipGarancije()
                    {
                        TipGarancijeId = Guid.NewGuid(),
                        TipGarancijeNaziv = "Bankarska Garancija"
                    },
                    new TipGarancije()
                    {
                        TipGarancijeId = Guid.NewGuid(),
                        TipGarancijeNaziv = "Garancija nekretninom"
                    },
                    new TipGarancije()
                    {
                        TipGarancijeId = Guid.NewGuid(),
                        TipGarancijeNaziv = "Žirantska"
                    },
                    new TipGarancije()
                    {
                        TipGarancijeId = Guid.NewGuid(),
                        TipGarancijeNaziv = "Uplata gotovinom"
                    }
                };
                _context.TipGarancije.AddRange(tipoviGarancije);
                _context.SaveChanges();
            }
            if (!_context.StatusDokumenta.Any())
            {
                var statusiDokumenta = new List<StatusDokumenta>()
                {
                    new StatusDokumenta()
                    {
                        StatusDokumentaId = Guid.NewGuid(),
                        StatusDokumentaNaziv = "Usvojen"
                    },
                    new StatusDokumenta()
                    {
                        StatusDokumentaId = Guid.NewGuid(),
                        StatusDokumentaNaziv = "Odbijen"
                    },
                    new StatusDokumenta()
                    {
                        StatusDokumentaId = Guid.NewGuid(),
                        StatusDokumentaNaziv = "Otvoren"
                    }
                };
                _context.StatusDokumenta.AddRange(statusiDokumenta);
                _context.SaveChanges();
            }
        }
    }
}
