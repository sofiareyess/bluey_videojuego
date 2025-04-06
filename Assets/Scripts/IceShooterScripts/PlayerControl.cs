using Unity.Collections;
using UnityEngine;

// Comportamiento de Hormigoxxo
public class PlayerControl : MonoBehaviour
{
    public float moveSpeed; // que tan rapido se mueve
    public Rigidbody2D rig; // Hormigoxxo
    public SpriteRenderer sr; // Su sprite
    void Start()
    {
    
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        // Movimiento horizontal de Horigoxxo
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        rig.linearVelocity = new Vector2(xInput*moveSpeed, yInput * moveSpeed);

    } 

}
