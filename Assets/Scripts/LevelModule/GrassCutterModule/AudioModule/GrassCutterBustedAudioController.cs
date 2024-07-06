using Infrastructure.AudioModule.Base;
using UnityEngine;

namespace LevelModule.GrassCutterModule.AudioModule
{
    [RequireComponent(typeof(GrassCutter))]
    public class GrassCutterBustedAudioController : BustedAudioController
    {
        [SerializeField] private GrassCutter _grassCutter;

        protected override void Awake()
        {
            base.Awake();
            _grassCutter ??= GetComponent<GrassCutter>();
        }

        private void Start()
        {
            _grassCutter.StartMoveEvent += OnMove;
        }

        private void OnMove()
        {
            _audioSource.Play();
        }
    }
}