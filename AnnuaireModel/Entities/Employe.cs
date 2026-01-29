namespace AnnuaireModel.Entities
{
    public class Employe
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public string TelephoneFixe { get; set; } = string.Empty;
        public string TelephonePortable { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Foreign keys
        public int ServiceId { get; set; }
        public int SiteId { get; set; }

        // Navigation properties
        public Service Service { get; set; } = null!;
        public Site Site { get; set; } = null!;
    }
}
