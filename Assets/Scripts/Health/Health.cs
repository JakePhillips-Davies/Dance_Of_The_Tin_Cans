using UnityEngine;

public class Health : MonoBehaviour {
    
    [field: SerializeField] public float maxHealth { get; private set; }
    private float currentHealth;

    private void Start() {
        currentHealth = maxHealth;
    }

    public void Damage(float amount) {
        currentHealth -= amount;

        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    }

}