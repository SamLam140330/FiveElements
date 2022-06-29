using FiveElement.Id;
using FiveElement.GameManager;
using UnityEngine;

namespace FiveElement.Audio
{
    public abstract class AudioManager : MonoBehaviour
    {
        [SerializeField] protected AudioSource[] audioSources;

        private void OnEnable()
        {
            StageManager.OnChangeAudioState += ChangeAudioState;
        }

        private void OnDisable()
        {
            StageManager.OnChangeAudioState -= ChangeAudioState;
        }

        private void ChangeAudioState(AudioState state, int audioIndex)
        {
            if (state == AudioState.Play && !audioSources[audioIndex].isPlaying)
            {
                audioSources[audioIndex].Play();
            }
            else if (state == AudioState.Stop)
            {
                audioSources[audioIndex].Stop();
            }
            else if (state == AudioState.Pause)
            {
                audioSources[audioIndex].Pause();
            }
        }
    }
}
