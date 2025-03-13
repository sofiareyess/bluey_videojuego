using System.Collections;
using UnityEngine;

public class SpawnerProjectile : MonoBehaviour
{
    public GameObject dropGameObject;
    public float timeToSpawnMin;
    public float timeToSpawnMax;
    void Start()
    {
        StartCoroutine(SpawnerTimer());
    }
    void Update()
    {
        
    }

    // Función que Spawnea las gotas
    IEnumerator SpawnerTimer()
    {
        // Espera un tiempo random dentro del rango
        yield return new WaitForSeconds(Random.Range(timeToSpawnMax, timeToSpawnMin));
        // Crea el objeto en la posición en la que está en spawner
        Instantiate(dropGameObject,
            new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        // Reinicia la corutina
        StartCoroutine(SpawnerTimer());
    }
}
