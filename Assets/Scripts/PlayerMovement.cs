using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody rb;
	public float jumpForce = 5.0f;
    public float moveSpeed = 10.0f;
    private Vector3 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();    
		startPosition = transform.position;
    }

	void Update (){
		if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
	}

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        rb.AddForce(movement * moveSpeed);

        if (transform.position.y < -5f)
        {
            Respawn();
        }

		
    }

	private void Respawn()
    {
        transform.position = startPosition;
        rb.linearVelocity = Vector3.zero; 
        rb.angularVelocity = Vector3.zero;
    }

	private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            GameController.Instance.Registrar(other.gameObject);
        }
    }


}
