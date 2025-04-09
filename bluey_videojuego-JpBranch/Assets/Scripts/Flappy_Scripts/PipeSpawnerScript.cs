using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipePrefab;     // Prefab del garrafón normal
    public GameObject pipeStarPrefab; // Prefab del garrafón con estrella
    public float spawnRate = 2f;      // Tiempo entre spawn
    private float timer = 0f;         // Temporizador
    public float heightOffset = 3f;   // Rango de altura

    private int pipeCount = 0; // Contador de garrafones

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            timer = 0f; // Reinicia el temporizador
        }
    }

    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Vector3 spawnPosition = new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0);
        // Alternar entre garrafón normal y garrafón con estrella
        if (pipeCount < 2)
        {
           Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
            pipeCount++;
        }
        else
        {
             Instantiate(pipeStarPrefab, spawnPosition, Quaternion.identity);
            pipeCount = 0; // Reinicia el contador después del garrafón con estrella
        }
    }
}
