using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public int contadorSaltos = 1;
    public int magnitudSalto = 7;
    public LvlMgr manager;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        manager = FindObjectOfType<LvlMgr>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Saltar();
        }
    }
    void Saltar()
    {
        if (contadorSaltos > 0)
        {
            contadorSaltos = contadorSaltos-1;
            rb.velocity = new Vector2(0, magnitudSalto);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            contadorSaltos = 1;
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            EndGame();
        }
    }

    void EndGame()
    {
        manager.SendMessage("EndGame");
    }
}
