namespace HBSIS.Padawan.Produtos.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int ID { get;  set; }
        public bool Deleted { get; protected set; }

        public void Delete()
        {
            Deleted = true;
        }
    }
}