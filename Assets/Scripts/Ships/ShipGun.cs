using EditorAttributes;
using UnityEngine;

/*
    #==============================================================#
	
	
	
	
*/
[RequireComponent(typeof(LineRenderer))]
public class ShipGun : MonoBehaviour
{    
//--#
    #region Variables


    [field: Title("variables")]
    [field: SerializeField] public float damage  {get; private set;}
    [field: SerializeField] public float range  {get; private set;}
    [field: SerializeField] public float cooldownTimer  {get; private set;}
    [field: SerializeField] public float laserFadeTime  {get; private set;}
    [field: SerializeField] public float randomAimOffsetMax  {get; private set;}

    private RaycastHit hit;

    private LineRenderer lineRenderer;
    private SpaceShip ship;

    private float lastShotTime;

    private float randX = 0;
    private float randY = 0;
    private float randZ = 0;


    #endregion
//--#


//--#
    #region Unity Methods


    private void Start() {
        lineRenderer = GetComponent<LineRenderer>();
        ship = GetComponent<SpaceShip>();

        lineRenderer.useWorldSpace = true;
        lineRenderer.widthMultiplier = 3;
        lineRenderer.endWidth = 8;

        lineRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        
        lineRenderer.material = SettingsSingleton.Get.laserMat;
        lineRenderer.material.SetColor("_BaseColor", Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f));
        lineRenderer.material.SetColor("_EmissionColor", lineRenderer.material.GetColor("_BaseColor") * 5);

        lineRenderer.loop = false;

        lineRenderer.enabled = false;
    }

    private void FixedUpdate() {
        if (Time.time - lastShotTime >= laserFadeTime) {
            lineRenderer.enabled = false;
        }
        else {
            lineRenderer.material.SetColor("_EmissionColor", lineRenderer.material.GetColor("_BaseColor") * 5 * (1 - ((Time.time - lastShotTime) / laserFadeTime)));
            lineRenderer.widthMultiplier = Mathf.Max(3f, (Camera.main.transform.position - transform.position).magnitude / 150);
        }
    }


    #endregion
//--#


//--#
    #region Shoot


    /// <returns>Whether the shot was successful</returns>
    public bool Shoot(Vector3 direction) {
        if (Time.time <= lastShotTime + cooldownTimer) return false;

        // Randomise aim
        randX = Random.Range(-randomAimOffsetMax, randomAimOffsetMax);
        randY = Random.Range(-randomAimOffsetMax, randomAimOffsetMax);
        randZ = Random.Range(-randomAimOffsetMax, randomAimOffsetMax);

        direction = direction.normalized;
        direction = new (direction.x + randX, direction.y + randY, direction.z + randZ);

        // Shoot!
        lastShotTime = Time.time;

        lineRenderer.enabled = true;
            lineRenderer.widthMultiplier = Mathf.Max(3f, (Camera.main.transform.position - transform.position).magnitude / 150);

        if (Physics.Raycast(transform.position, direction, out hit, range)) {
            lineRenderer.SetPositions(new Vector3[] {transform.position, hit.point});
            
            if (hit.transform.TryGetComponent<Health>(out Health hitHealth)) {
                hitHealth.Damage(damage);
                ship.AddScore(damage);
                return true;
            }
            else return false;
        }
        
        lineRenderer.SetPositions(new Vector3[] {transform.position, transform.position + (direction.normalized * range * 1.5f)});
        
        return false;
    }


    #endregion
//--#
}
