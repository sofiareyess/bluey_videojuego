using UnityEngine;

public class PlacedObjectController : MonoBehaviour
{
    private bool isBeingDragged = false;
    private Vector3 offset;

    void OnMouseDown()
    {
        // ✅ Si presiona Delete o Backspace → destruir
        if (Input.GetKey(KeyCode.Delete) || Input.GetKey(KeyCode.Backspace))
        {
            Destroy(gameObject);
            Invoke("GuardarDespuesDeDestruir", 0.1f);
        }
        else
        {
            // ✅ Si no, empieza a arrastrar
            isBeingDragged = true;
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            offset = transform.position - new Vector3(mouseWorld.x, mouseWorld.y, 0);
        }
    }

    void OnMouseDrag()
    {
        if (isBeingDragged)
        {
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorld.z = 0f;
            transform.position = mouseWorld + offset;
        }
    }

    void OnMouseUp()
    {
        if (isBeingDragged)
        {
            isBeingDragged = false;
            PlacedObjectManager.GuardarTodo();
        }
    }

    private void GuardarDespuesDeDestruir()
    {
        PlacedObjectManager.GuardarTodo();
    }
}
