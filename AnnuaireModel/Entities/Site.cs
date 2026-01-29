namespace AnnuaireModel.Entities
{
    public class Site
    {
        public int Id { get; set; }
        public string Ville { get; set; } = string.Empty;

        public ICollection<Employe> Employes { get; set; } = new List<Employe>();
    }
}
