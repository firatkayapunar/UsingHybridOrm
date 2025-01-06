namespace UsingHybridOrm.Entities.Concrete
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = string.Empty; // Departman adı
        public bool IsActive { get; set; } = true; // Departmanın aktiflik durumu
    }
}
