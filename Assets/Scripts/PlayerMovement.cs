using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * 4, body
            .velocity.y);

        if(horizontalInput > 0.01f)
        {
            Vector3 scale = transform.localScale;
            if (scale.x < 0)
            {
                scale.x *= -1;
            }
            transform.localScale = scale;
        }
        else if (horizontalInput < -0.01f)
        {
            Vector3 scale = transform.localScale;
            if(scale.x > 0)
            {
                scale.x *= -1;
            }
            transform.localScale = scale;
        }

        anim.SetBool("Walking", horizontalInput != 0);
    }
}
