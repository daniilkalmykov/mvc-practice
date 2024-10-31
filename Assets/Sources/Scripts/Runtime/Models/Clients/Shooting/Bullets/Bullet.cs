using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Sources.Scripts.Runtime.Models.Clients.Shooting.Bullets
{
    public abstract class Bullet : MonoBehaviour
    {
        public abstract UniTask Fly(Vector3 target);
    }
}