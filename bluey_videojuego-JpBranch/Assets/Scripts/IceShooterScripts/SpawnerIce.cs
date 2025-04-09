using System.Collections;
using UnityEngine;

public class SpawnerIce : MonoBehaviour
{
    public GameObject iceGameObject;
    public float maxRight;
    public float maxLeft;
    public float timeToSpawnMin;
    public float timeToSpawnMax;
    void Start()
    {
        StartCoroutine(SpawnerTimer());
    }
    void Update()
    {
        
    }

    // Función que Spawnea los hielos
    IEnumerator SpawnerTimer()
    {
        // Espera un tiempo random dentro del rango
        yield return new WaitForSeconds(Random.Range(timeToSpawnMax, timeToSpawnMin));
        // Crea el objeto dentro de los limites establecidos
        Instantiate(iceGameObject,
            new Vector3(transform.position.x + Random.Range (maxRight, maxLeft),
            transform.position.y, 0), Quaternion.identity);
        // Reinicia la corutina
        StartCoroutine(SpawnerTimer());
    }
}
