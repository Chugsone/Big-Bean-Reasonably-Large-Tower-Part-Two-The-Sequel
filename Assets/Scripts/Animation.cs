using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator animator;
    private float moveSpeed = 5f;

    void Start()
    {
        animator = GetComponent<Animator>();

        void Update()
        {
            // Might want to check with out movement script.
            float horizontalInput = Input.GetAxis("Horizontal");

            transform.position += new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, 0);

            animator.SetFloat("HorizontalSpeed", horizontalInput);

            if (horizontalInput < 0)
            {
                //Left
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (horizontalInput > 0)
            {
                //Right
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}