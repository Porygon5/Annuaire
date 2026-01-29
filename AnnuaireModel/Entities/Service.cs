namespace AnnuaireModel.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;

        // Navigation property
        public ICollection<Employe> Employes { get; set; } = new List<Employe>();
    }
}
