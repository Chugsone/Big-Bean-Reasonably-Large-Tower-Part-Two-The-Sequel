using UnityEngine;

public class BouncePad : MonoBehaviour
{

    [SerializeField] private Rigidbody2D bounceTarget;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void OnTriggerEnter2D(Collider2D other)
   {
       if (other.CompareTag("Player"))
       {
            Debug.Log("BouncePad activated!");
            bounceTarget.linearVelocityY += 40f;
        }
    }


}
