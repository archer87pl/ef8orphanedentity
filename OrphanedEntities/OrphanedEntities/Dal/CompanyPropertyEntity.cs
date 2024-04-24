namespace OrphanedEntities.Dal
{
    public class CompanyPropertyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? CompanyId { get; set; }

        public CompanyEntity CompanyEntity { get; set; }
    }
}
