using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
    // I got this code from a forum post, not mine
    public static float seed = 0;
    public static float PerlinNoise3D(float x, float y, float z)
    {
        y += 1 + seed;
        z += 2 + seed;
        float xy = _perlin3DFixed(x, y);
        float xz = _perlin3DFixed(x, z);
        float yz = _perlin3DFixed(y, z);
        float yx = _perlin3DFixed(y, x);
        float zx = _perlin3DFixed(z, x);
        float zy = _perlin3DFixed(z, y);

        return xy * xz * yz * yx * zx * zy;
    }

    static float _perlin3DFixed(float a, float b)
    {
        return Mathf.Sin(Mathf.PI * Mathf.PerlinNoise(a, b));
    }

    //
    [Header("Spawner stats")]
    [SerializeField] private int range;
    private int spawnAttempts = 15000;
    [SerializeField] private int noiseScale;
    [SerializeField, Range(0.0f, 2.0f)] private float density;
    [SerializeField, Range(0.1f, 2.0f)] private float fade;

    private List<Vector3> spawnPoints;

    [Space(3)]
    [Header("Asteroid stats")]
    [SerializeField, Range(0.0f, 2.0f)] private float maxSpawnSpeed;
    [SerializeField, Range(0.0f, 2.0f)] private float maxSpawnAngularVelocity;
    [SerializeField, Range(0.0f, 200.0f)] private float maxScale;
    [SerializeField, Range(0.0f, 200.0f)] private float minScale;
    [SerializeField] private List<GameObject> asteroidsTypes;

    [Space(7)]
    [Header("!! DEBUG !!")]
    [SerializeField] private bool drawRange;
    [Header("Spawning debug")]
    [SerializeField] private bool populateSpawnsInEditor;
    [SerializeField] private bool drawSpawnPoints;
    [SerializeField] private bool usingDebugSeed;
    //

    private void Start() {
        //Turn off debugs
            drawRange = false;
            populateSpawnsInEditor = false;
            drawSpawnPoints = false;
            usingDebugSeed = false;
        ////

        PopulateSpawnPoints();

        SpawnAsteroids();
    }

    private void PopulateSpawnPoints() {
        spawnPoints = new List<Vector3>(); // empty List
        Random.InitState(System.DateTime.Now.Millisecond);
        seed = Random.Range(1, 100000);

        if (usingDebugSeed){ // manually set the seeds for when debugging
            seed = 1111;
            Random.InitState(1111);
        }

        for (int i = 0; i < spawnAttempts*density; i++)
        {
            Vector3 attemptPoint = math.sqrt(Random.Range(0.0f, 1.0f)) * range * Random.onUnitSphere;

            float noise = PerlinNoise3D( //Get perlin noise at point
                attemptPoint.x / noiseScale,
                attemptPoint.y / noiseScale,
                attemptPoint.z / noiseScale
            );

            float spawnChance = noise * math.pow(1 - attemptPoint.magnitude/range, fade); // Lowering chances based on distance
            
            if (Random.Range(0.01f, 1.0f) <= spawnChance)
            {
                spawnPoints.Add(attemptPoint);
            }
        }
    }

    private void SpawnAsteroids() {

        foreach (Vector3 spawnPoint in spawnPoints)
        {
            int i = Random.Range(0, asteroidsTypes.Count - 1);

            GameObject spawnedAsteroid = Instantiate<GameObject>(asteroidsTypes[i], spawnPoint, Random.rotation, transform);

            spawnedAsteroid.GetComponent<Asteroid>().SetInitialVelocity(Random.onUnitSphere * Random.Range(0.0f, maxSpawnSpeed));
            spawnedAsteroid.GetComponent<Asteroid>().SetInitialAngularVelocity(Random.onUnitSphere * Random.Range(0.0f, maxSpawnAngularVelocity));

            spawnedAsteroid.transform.localScale *= Random.Range(minScale, maxScale);
        }

    }




    //!!!!DEBUG!!!!

        private void OnValidate() {
            if (populateSpawnsInEditor)
            {
                PopulateSpawnPoints();
            }
        }

        private void OnDrawGizmos() {
            if (drawRange)
            {
                Gizmos.color = UnityEngine.Color.yellow;
                Gizmos.DrawWireSphere(transform.position, range);
            }
            
            if (drawSpawnPoints)
            {
                Gizmos.color = new UnityEngine.Color(0.3f, 0.5f, 1.0f, 0.6f);
                foreach (Vector3 point in spawnPoints)
                {
                    Gizmos.DrawSphere(point, maxScale/2);
                }
            }

        }

    ///////////

    

    
}
