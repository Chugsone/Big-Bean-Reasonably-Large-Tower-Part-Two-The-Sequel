using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;

    private Rigidbody2D rb2d;

    private float movement;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
  
    void Update()
    {
        rb2d.linearVelocityX = movement;
        
    }

    public void Move(InputAction.CallbackContext ctx)
    {
            movement = ctx.ReadValue<Vector2>().x * moveSpeed;
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
      if (ctx.ReadValue<float>() == 1)
            rb2d.linearVelocityY = jumpHeight;

    }
}
