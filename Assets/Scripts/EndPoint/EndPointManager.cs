using FiveElement.Id;
using FiveElement.Stage1;
using UnityEngine;

namespace FiveElement.EndPoint
{
    public abstract class EndPointManager : MonoBehaviour
    {
        protected ParticleSystem ParticleSystems;
        protected ParticleSystem.MainModule ParticleSystemMainModule;

        private void Awake()
        {
            ParticleSystems = GetComponent<ParticleSystem>();
            ParticleSystemMainModule = ParticleSystems.main;
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player"))
            {
                Destroy(other.gameObject);
                StageManager.FindElementNum += 1;
                StageManager.MakeSomeAudio(AudioState.Play, 1);
            }
        }
    }
}
