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

    private void Start()
    {
        
    }

    private void Update()
    {
        tiempo += 1 * Time.deltaTime;

        if (tiempo >= limite)
        {
            IndicarPedido();
            tiempo = 0;
        }
    }

    public void IndicarPedido()
    {
        receta = Random.Range(1, 3);

        if (receta == guardarReceta && receta <= 2)
        {
            receta += 1;
        }
        if (receta == guardarReceta && receta == 3)
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
        }
        guardarReceta = receta;
    }
}
