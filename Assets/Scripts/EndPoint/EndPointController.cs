using FiveElement.Stage1;
using UnityEngine;

namespace FiveElement.EndPoint
{
    public class EndPointController : EndPointManager
    {
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            if (other.gameObject.CompareTag("Gold"))
            {
                ParticleSystemMainModule.startColor = new ParticleSystem.MinMaxGradient(Color.yellow);
                ParticleSystems.Play();
                Stage1Controller.GetAnElement("Gold");
                Stage1Controller.CheckWinCond();
            }
            else if (other.gameObject.CompareTag("Wood"))
            {
                ParticleSystemMainModule.startColor = new ParticleSystem.MinMaxGradient(Color.green);
                ParticleSystems.Play();
                Stage1Controller.GetAnElement("Wood");
                Stage1Controller.CheckWinCond();
            }
            else if (other.gameObject.CompareTag("Dust"))
            {
                ParticleSystemMainModule.startColor = new ParticleSystem.MinMaxGradient(new Color(0.75f, 0.6f, 0.4f));
                ParticleSystems.Play();
                Stage1Controller.GetAnElement("Dust");
                Stage1Controller.CheckWinCond();
            }
            else if (other.gameObject.CompareTag("Water"))
            {
                ParticleSystemMainModule.startColor = new ParticleSystem.MinMaxGradient(Color.blue);
                ParticleSystems.Play();
                Stage1Controller.GetAnElement("Water");
                Stage1Controller.CheckWinCond();
            }
            else if (other.gameObject.CompareTag("Fire"))
            {
                ParticleSystemMainModule.startColor = new ParticleSystem.MinMaxGradient(Color.red);
                ParticleSystems.Play();
                Stage1Controller.GetAnElement("Fire");
                Stage1Controller.CheckWinCond();
            }
        }
    }
}
