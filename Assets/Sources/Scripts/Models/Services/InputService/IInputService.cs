namespace Sources.Scripts.Models.Services.InputService
{
    public interface IInputService
    {
        float Horizontal { get; }
        float Vertical { get; }

        void OnUpdated();
    }
}