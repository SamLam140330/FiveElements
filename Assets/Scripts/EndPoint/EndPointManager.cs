using FiveElement.Id;
using FiveElement.Stage1;
using UnityEngine;

namespace FiveElement.EndPoint
{
    public abstract class EndPointManager : MonoBehaviour
    {
        protected Stage1Manager Stage1Managers;
        protected ParticleSystem ParticleSystems;
        protected ParticleSystem.MainModule ParticleSystemMainModule;

        private void Start()
        {
            Stage1Managers = FindObjectOfType<Stage1Manager>();
            ParticleSystems = GetComponent<ParticleSystem>();
            ParticleSystemMainModule = ParticleSystems.main;
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player"))
            {
                Destroy(other.gameObject);
                Stage1Manager.FindElementNum += 1;
                Stage1Manager.MakeSomeAudio(AudioState.Play, 1);
            }
        }
    }
}
