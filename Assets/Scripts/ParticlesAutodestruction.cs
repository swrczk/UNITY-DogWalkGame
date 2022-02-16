using UnityEngine;

public class ParticlesAutodestruction : MonoBehaviour
{
    
    void Start()
    {
        Invoke("Autodestruction", 1f);
    }

    void Autodestruction()
    {
        Destroy(gameObject);
    }
}
