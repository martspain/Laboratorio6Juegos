using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingMovement : MonoBehaviour
{
    private Rigidbody2D Rb;
    // Start is called before the first frame update
    void Start()
    {
        Rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }
    private void Jump()
    {
        if (Rb)
            if (Mathf.Abs(Rb.velocity.y) < 0.05f)
                Rb.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
    }
}
