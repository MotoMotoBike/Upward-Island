using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private GameObject scull;
    [SerializeField] private float speed;
    private SpriteRenderer _renderer;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        float xInput = Input.GetAxis("Horizontal") * speed;
        xInput += Input.acceleration.x * speed;
        rb.velocity = new Vector2(xInput, rb.velocity.y);
        if (rb.velocity.x < 0)
        {
            _renderer.flipX = true;
        }
        else
        {
            _renderer.flipX = false;
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb.velocity.y <=0 && collision.gameObject.CompareTag("Platform"))
        {
            Jump();
        }
    }

    public void Kill()
    {
        StartCoroutine(Death());
        Instantiate(scull, transform.position, Quaternion.identity);
    }

    IEnumerator Death()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        for (float i = 1; i > 0.1f; i-=0.02f)
        {
            Color color = renderer.color;
            color.a = i;
            renderer.color = color;
            yield return new WaitForFixedUpdate();
        }
    }
}