using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnRateInSeconds = 10f;
    [SerializeField] private InteractableObject[] objectsToSpawn;
    private float _nextSpawnTime;

    private void Start()
    {
        _nextSpawnTime = Time.time + _spawnRateInSeconds;
    }
    void Update()
    {
        if ((int)_nextSpawnTime == (int)Time.time)
        {
            Spawn();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }

    private void Spawn()
    {
        _nextSpawnTime = Time.time + _spawnRateInSeconds;
        var objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];
        if (objectToSpawn.ChanseToSpawn >= Random.value)
        {
            Instantiate(objectToSpawn, transform.position, objectToSpawn.gameObject.transform.rotation);
        }
    }
}

