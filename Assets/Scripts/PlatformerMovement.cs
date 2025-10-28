using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using System.Collections;
using Unity.VisualScripting;
public class PlayerMovment : MonoBehaviour
{
    public float Delay1 =9;
    public float speed;
    public float JumpHeight;
    private Rigidbody2D Rb;
    private float _movement;
    private float direction=1;
    public Vector2 boxsize;
    public float castDistance;
    public LayerMask groundLayer;
    public GameObject playerObj;
    public float dashForce;
    public float dashTime;
    public GameObject dashEffect;
    public float dashCooldown;
    public bool HasDoubleJump = true;

    // grabs inital position
    private Vector2 InitialPos;

    // grabs initial rotation
    private bool isDashing;
    private Quaternion InitialRot;  // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
    }
    /*private IEnumerator DelayedActionCoroutine(float delay1)
    {
        Debug.Log("Waiting for " + delay1 + " seconds...");

        // Pause the function for the specified time
        yield return new WaitForSeconds(delay1);

        // This code will run after the delay
        Debug.Log("Delay finished! Action performed.");
        dashEffect.SetActive(false);
    }
    */
    // Update is called once per frame
    void Update()
    {


        if (isDashing == false)
        {
            //StartCoroutine(DelayedActionCoroutine(3.0f));

            Rb.linearVelocityX = _movement;
            dashEffect.SetActive(false);

        }
        if (isDashing == true)
        {

            dashEffect.SetActive(true);
        }




        if (Input.GetKeyDown(KeyCode.Q) && !isDashing)
        {
            Rb.AddForce(new Vector2(dashForce * direction, 0f));
            isDashing = true;

            Invoke(nameof(EndDash), dashTime);
            if (direction == 1)
            {
                dashEffect.transform.localPosition = new Vector3(-0.5f, -0.5f, 0f);
                dashEffect.transform.rotation = Quaternion.Euler(0f, 0f, 135f);
            }
            else
            {
                dashEffect.transform.localPosition = new Vector3(0.5f, -0.5f, 0f);
                dashEffect.transform.rotation = Quaternion.Euler(0f, 0f, -45f);
            }
        }
    }
        

         

    private void DashCooldown(float coolDown)
    {
        if (isDashing == false)
        {
            
        }
    }

    private void EndDash()
    {
        isDashing = false;
    }

    // Crontrolls the players horizontal movment
    public void Move(InputAction.CallbackContext ctx)
    {

        _movement = ctx.ReadValue<Vector2>().x * speed;
        

        if (_movement != 0)
            direction = Mathf.Sign(_movement);

    }
    // Controlls the players jump and makes sure the player is grounded
    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 1)
        {
            if (IsGrounded())
            {
                Rb.linearVelocityY = JumpHeight;
            }
            if (!IsGrounded())
            {
                if (HasDoubleJump ==true) 
    {
        Rb.linearVelocityY = JumpHeight;
        HasDoubleJump = false;
    }
            }
        }




    }

    // Check if the player is grounded using a boxcast
    public bool IsGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxsize, 0, -transform.up, castDistance, groundLayer))
        {
            HasDoubleJump = true;
            return true;
            
        }
        else
        {
            return false;
        }
    }

    

    

    // Draw the boxcast in unity
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + Vector3.down * castDistance, boxsize);
    }



    void Reset()
    {
        transform.position = InitialPos;
        transform.rotation = InitialRot;
    }


}
