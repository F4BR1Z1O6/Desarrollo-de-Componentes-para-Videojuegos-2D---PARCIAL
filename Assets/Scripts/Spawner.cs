using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objetosParaGenerar; // almacenar sprites pero tipo arai xd para agregar mas
    public float tiempoEntreApariciones = 2f; // Tiempo 
    public float velocidadMovimiento = 2f; // Velocidad

    private Camera camaraPrincipal;
    private float anchoCamara;

    void Start()
    {
        camaraPrincipal = Camera.main;
        anchoCamara = camaraPrincipal.orthographicSize * camaraPrincipal.aspect;
        StartCoroutine(GenerarObjetos());
    }

    IEnumerator GenerarObjetos()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempoEntreApariciones);

            // prefab aleatorio
            GameObject objetoAleatorio = objetosParaGenerar[Random.Range(0, objetosParaGenerar.Length)];

            Vector2 posicionAparicion = new Vector2(camaraPrincipal.transform.position.x + anchoCamara + 1, Random.Range(-camaraPrincipal.orthographicSize, camaraPrincipal.orthographicSize));

            // crear
            GameObject objetoGenerado = Instantiate(objetoAleatorio, posicionAparicion, Quaternion.identity);

            // Velocidad
            objetoGenerado.AddComponent<MovimientoIzquierda>().velocidad = velocidadMovimiento;
        }
    }
}