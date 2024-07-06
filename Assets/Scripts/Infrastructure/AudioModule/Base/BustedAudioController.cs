using UnityEngine;

namespace Infrastructure.AudioModule.Base
{
    public class BustedAudioController : AudioController
    {
        [SerializeField][Range(0f, 5f)] private float _volumeBooster = 1f;
        
        protected override void OnChangeVolume(float newVolume)
        {
            _audioSource.volume = newVolume * _volumeBooster;
        }
    }
}