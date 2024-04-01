using UnityEngine;

public class ParticleSystemScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;

    public void StartParticleSystem()
    {
        ps.Play();
    }
}
