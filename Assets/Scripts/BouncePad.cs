using UnityEngine;

public class BouncePad : MonoBehaviour
{

    
   void OnTriggerEnter2D(Collider2D other)
   {
       if (other.CompareTag("Player"))
       {
            Debug.Log("BouncePad activated!");
            other.GetComponent<Rigidbody2D>().linearVelocityY += 40f;
        }
    }


}
