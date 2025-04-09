using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject star; // Prefab de la estrella
    public float spawnRate = 3f; // Tiempo entre las estrellas
    private float timer = 0f; // Temporizador para el spawn
    public float heightOffsetstar = 3;

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnStar();
            timer = 0f; // Reinicia el temporizador
        }
    }

    void spawnStar()
    {
                //calcula los limites inferior y superior de la altura de los garrafones
        float lowestPoint = transform.position.y - heightOffsetstar;
        float heighestPoint = transform.position.y + heightOffsetstar;

        // produce un nuevo garrafon en una posición aleatoria 
        Instantiate(star, new Vector3(transform.position.x, Random.Range(lowestPoint, heighestPoint),0), transform.rotation);
    }
    }

