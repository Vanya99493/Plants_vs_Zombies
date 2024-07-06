using UnityEngine;

namespace Infrastructure.AudioModule.Base
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class AudioController : MonoBehaviour
    {
        [SerializeField] protected AudioSource _audioSource;

        protected virtual void Awake()
        {
            _audioSource ??= GetComponent<AudioSource>();
            AudioVolumeController.Instance.ChangeVolumeEvent += OnChangeVolume;
            OnChangeVolume(AudioVolumeController.Instance.CurrentVolume);
        }

        protected virtual void OnChangeVolume(float newVolume)
        {
            _audioSource.volume = newVolume;
        }
    }
}