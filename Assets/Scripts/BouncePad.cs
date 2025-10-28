using UnityEngine;

public class BouncePad : MonoBehaviour
{

    [SerializeField] private Rigidbody2D bounceTarget;

    
   void OnTriggerEnter2D(Collider2D other)
   {
       if (other.CompareTag("Player"))
       {
            Debug.Log("BouncePad activated!");
            bounceTarget.linearVelocityY += 40f;
        }
    }


}
