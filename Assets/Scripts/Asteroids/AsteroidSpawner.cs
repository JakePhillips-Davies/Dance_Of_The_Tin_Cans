using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    //
    [SerializeField] private int range;
    [SerializeField] private int amount;
    //


    // Draw range
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
