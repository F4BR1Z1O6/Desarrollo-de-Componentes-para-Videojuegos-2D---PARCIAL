using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoIzquierda : MonoBehaviour
{
    public float velocidad = 2f;

    void Update()
    {
        // Mover el objeto hacia la izquierda
        transform.Translate(Vector2.left * velocidad * Time.deltaTime);

        // Destruir el objeto si sale del lado izquierdo de la cámara
        if (transform.position.x < Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect - 1)
        {
            Destroy(gameObject);
        }
    }
}