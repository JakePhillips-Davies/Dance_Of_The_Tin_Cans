using EditorAttributes;
using UnityEngine;

public class Health : MonoBehaviour {
    
    [field: SerializeField] public float maxHealth { get; private set; }
    [SerializeField, ReadOnly] private float currentHealth;
    public float healthChange { get; private set; }

    private void Start() {
        currentHealth = maxHealth;
    }

    private void FixedUpdate() {
        healthChange = 0;
    }

    private void OnCollisionEnter(Collision other) {
        Vector3 relativeVelovity = other.relativeVelocity;

        float damage = Mathf.Max(0f, Mathf.Pow(relativeVelovity.magnitude, SettingsSingleton.Get.collisionDamagePower) - 20f) * SettingsSingleton.Get.collisionDamageScale;

        Damage(damage);
    }

    public void Damage(float amount) {
        currentHealth -= amount;
        healthChange -= amount;

        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    }

}