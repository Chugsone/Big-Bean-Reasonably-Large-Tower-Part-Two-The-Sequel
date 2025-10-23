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
<<<<<<< HEAD:Assets/PlatformerMovement.cs
 
=======
        rb2d = GetComponent<Rigidbody2D>();
>>>>>>> c17ed7d74f4460d7068323a9547da69ffd6adc0d:Assets/Scripts/PlatformerMovement.cs
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
<<<<<<< HEAD:Assets/PlatformerMovement.cs
        if(ctx.canceled) return;
        rb2d.AddForceY(jumpHeight);
        anim.SetTrigger("Jump");
=======
        if (ctx.ReadValue<float>() == 1)

        rb2d.linearVelocityY = jumpHeight;
>>>>>>> c17ed7d74f4460d7068323a9547da69ffd6adc0d:Assets/Scripts/PlatformerMovement.cs
    }
}
