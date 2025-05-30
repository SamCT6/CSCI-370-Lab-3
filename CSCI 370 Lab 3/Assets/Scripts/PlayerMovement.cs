
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float searchRange;

    [SerializeField] private int jumpForce;

    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    float horizontal;

    public int jumpCount = 0;
    private const int maxJumps = 2;
    public float runSpeed = 5f;
    private bool m_Grounded;

    public UnityEvent OnLandEvent;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        if (OnLandEvent == null)
        {
            OnLandEvent = new UnityEvent();
        }
        OnLandEvent.AddListener(Landed);
    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        animator.SetFloat("horizontal", horizontal);
        if (Input.GetKeyDown(KeyCode.W) && jumpCount < maxJumps)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce);
            animator.SetBool("jump", true);
            jumpCount++;
            Debug.Log("Jump: " + jumpCount);
        }
        //OnLandEvent.AddListener(Landed);
    }

    // Update is called once per frame


    void FixedUpdate()
    {
        rigidbody2D.linearVelocity = new Vector2(horizontal * runSpeed, rigidbody2D.linearVelocity.y);

        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, searchRange);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                //jumpCount = 0;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
    }

    public void Landed()
    {
        animator.SetBool("jump", false);
        jumpCount = 0;
        Debug.Log("I reset to 0");
    }

}
