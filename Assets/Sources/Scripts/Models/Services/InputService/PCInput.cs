using System.Runtime.CompilerServices;
using UnityEngine;

[assembly: InternalsVisibleTo("Assembly-CSharp")]
namespace Sources.Scripts.Models.Services.InputService
{
    internal sealed class PCInput : IInputService
    {
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }
        
        public void OnUpdated()
        {
            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");
        }
    }
}