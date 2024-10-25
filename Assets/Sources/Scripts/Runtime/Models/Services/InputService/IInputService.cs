using System;

namespace Sources.Scripts.Runtime.Models.Services.InputService
{
    public interface IInputService
    {
        event Action OnShootButtonClicked;
        
        float MouseX { get; }
        float MouseY { get; }
        
        void OnUpdated();
    }
}