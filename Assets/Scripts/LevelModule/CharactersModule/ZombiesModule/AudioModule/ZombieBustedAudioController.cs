using System.Collections;
using CustomClasses;
using Infrastructure;
using Infrastructure.AudioModule.Base;
using UnityEngine;

namespace LevelModule.CharactersModule
{
    public class ZombieBustedAudioController : AudioController
    {
        [SerializeField] private Pair<AudioClip, float>[] _boostedClips;
        [SerializeField] private float _soundsFrequency;

        private void Start()
        {
            StartCoroutine(SoundGenerator());
        }

        private IEnumerator SoundGenerator()
        {
            while (true)
            {
                int clipIndex = Random.Range(0, _boostedClips.Length);
                _audioSource.clip = _boostedClips[clipIndex].Key;
                _audioSource.volume = _boostedClips[clipIndex].Value * AudioVolumeController.Instance.CurrentVolume;
                _audioSource.Play();
                yield return new WaitForSeconds(_soundsFrequency);
                _audioSource.Stop();
            }
        }
    }
}