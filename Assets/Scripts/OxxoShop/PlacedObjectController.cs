using UnityEngine;

public class PlacedObjectController : MonoBehaviour
{
    private bool isBeingMoved = false;

    void Update()
    {
        if (isBeingMoved)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            transform.position = mousePos;

            if (Input.GetMouseButtonDown(0))
            {
                isBeingMoved = false;
                PlacedObjectManager.GuardarTodo();
            }
        }
    }

    void OnMouseDown()
    {
        if (Input.GetKey(KeyCode.Delete) || Input.GetKey(KeyCode.Backspace))
        {
            StartCoroutine(GuardarDespuesDeDestruir());
            Destroy(gameObject);
        }
        else if (Input.GetKey(KeyCode.M))
        {
            isBeingMoved = true;
        }
    }

    System.Collections.IEnumerator GuardarDespuesDeDestruir()
    {
    yield return new WaitForEndOfFrame(); // esperamos un frame completo
    PlacedObjectManager.GuardarTodo();
    }
}


