using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class personajemo : MonoBehaviour
{
    Rigidbody2D rb;
    public float fuerzaSalto;
    private Animator anim;

    private bool enElSuelo = false;

    private int joyasRecogidas = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && enElSuelo)
        {
            rb.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
        }

        if (rb.velocity.y > 0)
        {
            anim.SetInteger("state", 1);
        }
        else if (rb.velocity.y == 0)
        {
            anim.SetInteger("state", 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enElSuelo = true;
        }
        else if (collision.gameObject.CompareTag("Enemigo"))
        {
            Debug.Log("Enemigo ha golpeado al Player");
            Debug.Log("Reiniciando escena...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enElSuelo = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            joyasRecogidas++;
            Debug.Log("Joyas reunidas: " + joyasRecogidas);

            Destroy(other.gameObject);
        }
    }
}
       
        


