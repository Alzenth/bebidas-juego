using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pedidos : MonoBehaviour
{
    //texto
    public Text orden;

    //variable para tiempo y limite de cuanto va llegarxd
    public float tiempo;
    public float limiteDeTiempo;

    //variable para saber que orden va pedir y para saber que orden pidio la anterior vez
    public int receta;
    public int guardarReceta;

    //variable que funciona cuando termine de pensar la orden 
    public bool terminado;

    public Receta [] recetas;

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
        if (terminado == false)
        {
            IndicarPedido();
            tiempo += 1 * Time.deltaTime;
            if (tiempo >= limiteDeTiempo)
            {
                terminado = true;
                tiempo = 0;
            }
        }
    }

    //metodo para elegir la orden aleatoriamente
    public void IndicarPedido()
    {
        receta = Random.Range(1, 13);
        //los siguientes if funcionaba para que no eligiera lo mismo dos veces seguidas pero ya no funciona a menos que sea 3 ordenes xd
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