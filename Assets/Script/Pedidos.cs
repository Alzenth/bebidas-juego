using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pedidos : MonoBehaviour
{
    public Text orden;
    public float tiempo;
    public float limite;
    public int receta;
    public int guardarReceta;
    public bool terminado;

    private void Start()
    {
        IndicarPedido();
    }

    private void Update()
    {
        /*
        tiempo += 1 * Time.deltaTime;

        if (tiempo >= limite)
        {
            IndicarPedido();
            tiempo = 0;
        }
        */
        if (terminado)
        {
            IndicarPedido();
            tiempo += 1 * Time.deltaTime;
            if (tiempo >= limite)
            {
                terminado = false;
                tiempo = 0;
            }
        }
    }

    public void IndicarPedido()
    {
        receta = Random.Range(1, 13);

        if (receta == guardarReceta && receta >= 1 && receta <= 6)
        {
            receta += 1;
        }
        if (receta == guardarReceta && receta <= 13 && receta >= 7)
        {
            receta -= 1;
        }

        switch (receta)
        {
            case 1:
                orden.text = "orden A";
                break;
            case 2:
                orden.text = "orden B";
                break;
            case 3:
                orden.text = "orden C";
                break;
            case 4:
                orden.text = "orden D";
                break;
            case 5:
                orden.text = "orden E";
                break;
            case 6:
                orden.text = "orden F";
                break;
            case 7:
                orden.text = "orden G";
                break;
            case 8:
                orden.text = "orden H";
                break;
            case 9:
                orden.text = "orden I";
                break;
            case 10:
                orden.text = "orden J";
                break;
            case 11:
                orden.text = "orden K";
                break;
            case 12:
                orden.text = "orden L";
                break;
            case 13:
                orden.text = "orden M";
                break;
        }

        guardarReceta = receta;
    }
}