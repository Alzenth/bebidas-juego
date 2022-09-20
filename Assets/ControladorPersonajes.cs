using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorPersonajes : MonoBehaviour
{ 
    public GameObject[] posicion;

    public bool[] ocupado;

    public GameObject personas;
    public GameObject personaPrefab;

    public GameObject invocacion;

    public Pedidos pedidos;

    public int identificadorPersona;

    public float tiempo;
    public int contador;
    public int nivelSgt;


    private void Start()
    {
        personaPrefab = Instantiate(personas, invocacion.transform.position, Quaternion.identity);
        contador++;
    }

    private void Update()
    {
        EstadosGlobo();

        if (nivelSgt == 1 && contador < 4)
        {
            tiempo += 1 * Time.deltaTime;

            if (tiempo >= 20)
            {
                personaPrefab = Instantiate(personas, invocacion.transform.position, Quaternion.identity);
                contador++;
                tiempo = 0;
            }
        }
        if(nivelSgt == 2 && contador < 4)
        {
            contador = 0;
            tiempo += 1 * Time.deltaTime;

            if (tiempo >= 20)
            {
                personaPrefab = Instantiate(personas, invocacion.transform.position, Quaternion.identity);
                contador++;
                tiempo = 0;
            }
        }
        if (nivelSgt == 3 && contador < 5)
        {
            contador = 0;
            tiempo += 1 * Time.deltaTime;

            if (tiempo >= 20 )
            {
                personaPrefab = Instantiate(personas, invocacion.transform.position, Quaternion.identity);
                contador++;
                tiempo = 0;
            }

        }
    }

    public void EstadosGlobo()
    {
        if (ocupado[0])
        {
            pedidos.ApareceGloboTexto();
        }
        if (ocupado[0]==false)
        {
            pedidos.DesaparecerGloboTexto();
        }
    }
}
