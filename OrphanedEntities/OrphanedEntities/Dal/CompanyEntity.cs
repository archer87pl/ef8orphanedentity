namespace OrphanedEntities.Dal
{
    public class CompanyEntity
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public ICollection<CompanyPropertyEntity> CompanyProperties { get; set; } 
    }
}
