using System.Collections;
using UnityEngine;

public class IceeSpecialSpawner : MonoBehaviour
{
    public GameObject iceSpecialPrefab; // Prefab del Icee Especial
    public float speed = 3f; // Velocidad del Icee
    public float moveRange = 7f; // Rango de movimiento (izquierda-derecha)
    private Vector3 startPosition; // Posición inicial del Icee
    private bool movingRight = true; // Control de la dirección

    public float timeToSpawn = 22f; // Tiempo que tarda en generar el Icee Especial

    void Start()
    {
        startPosition = transform.position; // Guarda la posición inicial
        StartCoroutine(SpawnIceeEspecial()); // Llamamos la corutina para el spawn del Icee Especial después de 22 segundos
    }


    IEnumerator SpawnIceeEspecial()
    {
        yield return new WaitForSeconds(timeToSpawn);
        GameObject iceeSpecial = Instantiate(iceSpecialPrefab, transform.position, Quaternion.identity); // Genera el Icee Especial

        // Llamamos al método de movimiento dentro del mismo objeto instanciado
        StartCoroutine(MoveIcee(iceeSpecial));
    }


   IEnumerator MoveIcee(GameObject iceeSpecial)
{
    while (true)
    {
        if (iceeSpecial != null) // Verificar si el objeto sigue existiendo
        {
            if (movingRight)
            {
                iceeSpecial.transform.position += Vector3.right * speed * Time.deltaTime; // Mueve a la derecha
                if (iceeSpecial.transform.position.x >= startPosition.x + moveRange) {
                    movingRight = false;
                }
            }
            else
            {
                iceeSpecial.transform.position -= Vector3.right * speed * Time.deltaTime; // Mueve a la izquierda
                if (iceeSpecial.transform.position.x <= startPosition.x - moveRange) {
                    movingRight = true;
                }
            }
        }
        else
        {
            Debug.LogWarning("El objeto iceeSpecial ha sido destruido.");
            yield break;  // Salir de la coroutine si el objeto ha sido destruido
        }

        yield return null;
    }
}

}
