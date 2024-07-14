using System;
using UnityEngine;

namespace Infrastructure.SettingsModule
{
    public class AudioVolumeController
    {
        public static AudioVolumeController Instance { get; } = new();
        
        public event Action<float> ChangeVolumeEvent;

        private const string VOLUME_PREFS_NAME = "VolumeSetting";
        
        public float CurrentVolume { get; private set; }

        public AudioVolumeController()
        {
            if (Instance != null)
            {
                return;
            }
            
            float currentVolume = PlayerPrefs.GetFloat(VOLUME_PREFS_NAME);
            if (currentVolume == 0f)
            {
                currentVolume = 0.5f;
            }
            
            ChangeVolume(currentVolume);
        }

        public bool TryChangeVolume(object sender, float newVolume)
        {
            if (sender is Game)
            {
                ChangeVolume(newVolume);
                return true;
            }

            return false;
        }

        private void ChangeVolume(float newVolume)
        {
            CurrentVolume = newVolume;
            SetVolumeToPrefs();
            ChangeVolumeEvent?.Invoke(CurrentVolume);
        }

        private void SetVolumeToPrefs()
        {
            PlayerPrefs.SetFloat(VOLUME_PREFS_NAME, CurrentVolume);
        }
    }
}