namespace Sources.Scripts.Models.Services.InputService
{
    public interface IInputService
    {
        float MouseX { get; }
        float MouseY { get; }

        void OnUpdated();
    }
}