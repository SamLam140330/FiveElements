using FiveElement.Id;
using FiveElement.Stage1;
using UnityEngine;

namespace FiveElement.Audio
{
    public abstract class AudioManager : MonoBehaviour
    {
        [SerializeField] protected AudioSource[] audioSources;

        private void OnEnable()
        {
            Stage1Manager.OnChangeAudioState += ChangeAudioState;
        }

        private void OnDisable()
        {
            Stage1Manager.OnChangeAudioState -= ChangeAudioState;
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
