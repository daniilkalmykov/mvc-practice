using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[assembly: InternalsVisibleTo("Assembly-CSharp")]
namespace Sources.Scripts.Runtime.Models.Services.InputService
{
    internal sealed class PCInput : IInputService
    {
        public event Action OnShootButtonClicked;
        
        public float MouseX { get; private set; }
        public float MouseY { get; private set; }

        public void OnUpdated()
        {
            MouseX = Input.GetAxis(InputServiceConstants.MouseX);
            MouseY = Input.GetAxis(InputServiceConstants.MouseY);

            if (Input.GetMouseButtonDown(0))
                OnShootButtonClicked?.Invoke();
        }
    }
}