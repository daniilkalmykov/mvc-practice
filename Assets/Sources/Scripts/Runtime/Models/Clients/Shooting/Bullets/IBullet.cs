using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Sources.Scripts.Runtime.Models.Clients.Shooting.Bullets
{
    public interface IBullet
    {
        UniTask Fly(Vector3 target);
    }
}