namespace Sources.Scripts.Runtime.Models.Clients.Factories.FactoryMethods
{
    public interface IFactoryMethod<out T>
    {
        T Create();
    }
}