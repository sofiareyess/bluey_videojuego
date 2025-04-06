using UnityEngine;
using System.Collections;

public class AutoSaved : MonoBehaviour
{
    public float tiempoEntreGuardados = 5f; // cada cuántos segundos guardar

    void Start()
    {
        StartCoroutine(GuardarPeriodicamente());
    }

    IEnumerator GuardarPeriodicamente()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempoEntreGuardados);
            PlacedObjectManager.GuardarTodo();
            Debug.Log("💾 Guardado automático cada " + tiempoEntreGuardados + " segundos");
        }
    }
}



