using System.Collections;
using UnityEngine;
public class SpawnerEnemy : MonoBehaviour
{
    public GameObject enemyGameObject;
    public Transform tiendaObjetivo; // El lugar a donde camina

    public float tiempoMin = 5f;
    public float tiempoMax = 10f;

    void Start()
    {
        StartCoroutine(SpawnTimer());
    }

    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(Random.Range(tiempoMin, tiempoMax));

        GameObject nuevoCliente = Instantiate(enemyGameObject, transform.position, Quaternion.identity);
        Cliente clienteScript = nuevoCliente.GetComponent<Cliente>();
        if (clienteScript != null)
        {
            clienteScript.puntoObjetivo = tiendaObjetivo;
        }

        StartCoroutine(SpawnTimer());
    }
}


