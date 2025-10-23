using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;

    private Rigidbody2D rb2d;

    private float movement;
    public Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

    }

    // Update is called once per frame
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

    }
}
