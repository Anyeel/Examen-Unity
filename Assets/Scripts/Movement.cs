using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 movingInput;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float acceleration = 100f;
    [SerializeField] float decceleration = 100f;
    [SerializeField] float maxSpeed = 5f;
    private float vectorModule;
    [SerializeField] float direcction = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movingInput = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            movingInput.x--;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movingInput.x++;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movingInput.y--;
        }
        if (Input.GetKey(KeyCode.W))
        {
           movingInput.y++;
        }
        Velocity();

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movingInput.x = movingInput.x + 1 * direcction;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            movingInput.x = movingInput.x - 1 * direcction;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movingInput.y = movingInput.y - 1 * direcction;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            movingInput.y = movingInput.y + 1 * direcction;
        }
        Velocity();
        Brake();
    }
    void Velocity()
    {
        vectorModule = Mathf.Sqrt(rb.velocity.x * rb.velocity.x + rb.velocity.y * rb.velocity.y);

        if (vectorModule < maxSpeed)
        {
            rb.velocity = rb.velocity + movingInput.normalized * acceleration * Time.deltaTime;
        }
    }
    void Brake()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if(rb.velocity.x > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x - decceleration * Time.deltaTime, rb.velocity.y);
            }
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - decceleration * Time.deltaTime);
            }
            if (rb.velocity.x < 0)
            {
                rb.velocity = new Vector2(rb.velocity.x + decceleration * Time.deltaTime, rb.velocity.y);
            }
            if (rb.velocity.y < 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + decceleration * Time.deltaTime);
            }
        }
    }
}
