namespace DAL.Interfaces
{
    public interface IEntity
    {
        IEntity SetData(EntityOptions options);
        void ChangeData(EntityOptions options);
    }
}