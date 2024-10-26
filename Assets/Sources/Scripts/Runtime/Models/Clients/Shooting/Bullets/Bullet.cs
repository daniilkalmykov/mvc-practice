using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Sources.Scripts.Runtime.Models.Clients.Shooting.Bullets
{
    internal sealed class Bullet : MonoBehaviour, IBullet
    {
        private readonly CancellationTokenSource _cancellationToken = new();
        
        [SerializeField] private float _timeToFly;

        public void OnDisable()
        {
            _cancellationToken.Cancel();
        }
        
        public async UniTask Fly(Vector3 target)
        {
            await transform.DOMove(target, _timeToFly).SetEase(Ease.Linear).Play()
                .WithCancellation(_cancellationToken.Token);
        }
    }
}