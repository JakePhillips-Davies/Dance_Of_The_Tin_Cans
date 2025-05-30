using EditorAttributes;
using UnityEngine;

public class Health : MonoBehaviour {
    
    [field: SerializeField] public float maxHealth { get; private set; }
    [field: SerializeField, ReadOnly] public float currentHealth { get; private set; }
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

        if (TryGetComponent<SpaceShip>(out SpaceShip ship)) ship.AddScore(0 - amount);
    }

}