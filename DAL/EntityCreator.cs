using DAL.Interfaces;

namespace DAL
{
    public static class EntityCreator<T> where T : class, IEntity, new()
    {
        public static T CreateEntity(EntityOptions options) => new T().SetData(options) as T;
    }
}