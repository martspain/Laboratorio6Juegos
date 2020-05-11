using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D Rb;
    private bool PowerUpActive;
    private int Size;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        PowerUpActive = false;
        Size = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Allign();

        if (PowerUpActive)
            Size = 5;
    }
    private void FixedUpdate()
    {
        if (Rb) 
        {
            Rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * 10, 0));
            if (Input.GetAxis("Jump") > 0)
                this.Jump();
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !PowerUpActive)
            Destroy(gameObject);
        else if (collision.gameObject.CompareTag("Enemy") && PowerUpActive)
            Destroy(collision.gameObject);
        else if (collision.gameObject.CompareTag("PowerUp"))
        {
            Destroy(collision.gameObject);
            PowerUpActive = true;
        }
            
    }
    private void Jump()
    {
        if (Rb)
            if (Mathf.Abs(Rb.velocity.y) < 0.05f)
                Rb.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
    }

    private void Allign() 
    {
        Vector2 newScale = transform.localScale;
        if (Input.GetAxis("Horizontal") > 0)
            newScale.x = -Size;
        else if (Input.GetAxis("Horizontal") < 0)
            newScale.x = Size;
        newScale.y = Size;
        transform.localScale = newScale;

    }
}
