using UnityEngine;
using System.Collections;

public class Cliente : MonoBehaviour
{
    public float speed = 2f;
    public Transform puntoObjetivo; // A la tienda
    private bool regresando = false;

    public float tiempoMirando = 2f; // Tiempo dentro de la tienda

    private Vector3 puntoEntrada; // Guardamos donde entró (para regresar)

    void Start()
    {
        // Guardamos el punto de entrada para luego regresar
        puntoEntrada = transform.position;
        StartCoroutine(MirarYSalir());
    }

void Update()
{
    if (puntoObjetivo == null) return;

    transform.position = Vector3.MoveTowards(transform.position, puntoObjetivo.position, speed * Time.deltaTime);

    if (!regresando && Vector3.Distance(transform.position, puntoObjetivo.position) < 0.1f)
    {
        // Se detiene, pero NO eliminamos puntoObjetivo
        // Solo dejamos que la coroutine se encargue de todo
    }

    if (regresando && Vector3.Distance(transform.position, puntoObjetivo.position) < 0.1f)
    {
        Destroy(gameObject); // 💣 Chau cliente
    }
}


    IEnumerator MirarYSalir()
    {
        // Espera a llegar a la tienda
        yield return new WaitUntil(() => Vector3.Distance(transform.position, puntoObjetivo.position) < 0.1f);
        yield return new WaitForSeconds(tiempoMirando);

        // Cambiamos objetivo al punto de entrada
        puntoObjetivo = new GameObject("RetornoTemp").transform;
        puntoObjetivo.position = puntoEntrada;
        regresando = true;
    }
}


