using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;

    private Rigidbody2D rb2d;

    private float movement;
    public Animator anim;

    void Update()
    {
        rb2d.linearVelocityX = movement;
        anim.SetFloat("HorizantalSpeed", movement);
    }

    public void Move(InputAction.CallbackContext ctx)
    {
            movement = ctx.ReadValue<Vector2>().x * moveSpeed;
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        rb2d.AddForceY(jumpHeight);
        anim.SetTrigger("Jump");
        if (ctx.canceled) return;
    }
}
