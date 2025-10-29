using UnityEngine;

public class SpikedBallTrap : MonoBehaviour
{
    public float swingAngle = 45f; // Maximum angle of swing
    public float swingSpeed = 2f;  // Speed of swinging
    public float swingFrequency = 1f; // Frequency of swinging
    private float currentAngle;
    private float time;
    [SerializeField] private Rigidbody2D _playerRB2D;
    [SerializeField] private float _knockbackForce = 10f;
    private float _direction;


    private void Start()
    {
        currentAngle = 0f;
        time = 0f;
    }

    private void Update()
    {
        time += Time.deltaTime * swingSpeed;
        currentAngle = swingAngle * Mathf.Sin(time * swingFrequency);
        transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);
        _direction = currentAngle > 0 ? 1f : -1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("E");
        if (collision.CompareTag("Player"))
        {
            Debug.Log("SpikedBallTrap hit the player!");
            //_playerRB2D.linearVelocityY = _knockbackForce * _direction;
            _playerRB2D.AddForce(new Vector2(_knockbackForce * _direction, 0f));
        }
    }

}



