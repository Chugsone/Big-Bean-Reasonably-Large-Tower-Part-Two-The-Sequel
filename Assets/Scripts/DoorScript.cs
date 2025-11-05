using UnityEngine;

public class DoorScript : MonoBehaviour
{

    [SerializeField] private Vector2 closedPosition;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector2 boxsize;
    private bool isOpen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            if (Vector2.Distance(transform.position,closedPosition)>0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, closedPosition, 5f * Time.deltaTime);
            }
        }
        else 
        {
            Vector3 boxcastLocation = new(closedPosition.x + 10, closedPosition.y);
            //RaycastHit2D hit = Physics2D.BoxCast(boxcastLocation, boxsize, 0, Vector2.zero, 0f, groundLayer);
            if (Physics2D.BoxCast(boxcastLocation, boxsize, 0, Vector2.zero, 0f, groundLayer))
            {
                Debug.Log("tesdkfjshfosofg");
                isOpen = true;
            }

        }
    }


    private void OnDrawGizmos()
    {
        if (!isOpen) 
        {
            Gizmos.DrawWireCube(new Vector3(closedPosition.x + 10, closedPosition.y), boxsize);
        }
    }

}
