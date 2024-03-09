using UnityEngine;

public class EndPoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Agent agent)) 
        {
            agent.OnHitEndPoint();
        }
    }
}
