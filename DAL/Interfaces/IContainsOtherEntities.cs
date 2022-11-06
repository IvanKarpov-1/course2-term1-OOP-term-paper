namespace DAL.Interfaces
{
    public interface IContainsOtherEntities
    {
        void AddEntity(IEntity entity);
        void DeleteEntity(IEntity entity);
        void DeleteEntity(IEntity entity, int index);
    }
}