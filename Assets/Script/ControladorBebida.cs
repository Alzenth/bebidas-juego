using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorBebida : MonoBehaviour
{   //arreglo para guardar los botones
    public GameObject[] ingredientes;

    public GameObject ordenTexto;

    //botones

    //mezclador
    public GameObject mezclador;
    public float rotVelo;
    //vaso
    public GameObject vaso;

    public GameObject siguiente;

    //arreglo que guardael valor de los ingredientes
    public int[] valor;

    //Contador de las veces que ppreesionas un boton(ingrediente)
    public int contador;

    //contador de que parte del preparado esta(ingredientes = 1, mezcla = 2,etc)
    public int fases;

    //puede borrarlo si gustas estaba intentando hacer que aqui se supieraa la orden y que componentes se ocupa borralo si sabes otra manera con el metodo Ordenes
    public int orden;
    public string general;
    public string a;
    public string b;
    public string c;
    public string d;

    private void Start()
    {
        fases = 1;

        SiguienteFase();

        //guarda los el valor que tienen los ingredientes
        for (int i = 0; i < ingredientes.Length; ++i)
        {
            valor[i] = ingredientes[i].GetComponent<Valor>().val;
        }
    }

    private void Update()
    {
        orden = ordenTexto.GetComponent<Pedidos>().receta;

        if (contador == 4)
        {
            for (int i = 0; i < ingredientes.Length; ++i)
            {
                ingredientes[i].GetComponent<Button>().interactable = false;
            }
            fases = 2;
        }
        if (contador >= 3)
        {
            siguiente.SetActive(true);
        }
        else
        {
            siguiente.SetActive(false);
        }
    }

    //metodo que los botones ocupan para dar un valor cada que se presiona no sirve para nd mas 
    public void Pulsacion()
    {
        contador += 1;
    }

    //metodo para las fases
    public void SiguienteFase()
    {
        if (fases == 1)
        {
            for (int i = 0; i < ingredientes.Length; ++i)
            {
                ingredientes[i].SetActive(true);
            }
            mezclador.SetActive(false);
            vaso.SetActive(false);
        }
        if (fases == 2)
        {
            for (int i = 0; i < ingredientes.Length; ++i)
            {
                ingredientes[i].SetActive(false);
            }
            mezclador.SetActive(true);
            vaso.SetActive(false);
        }
    }

    public void Girar()
    {
        mezclador.transform.Rotate(0, 0, rotVelo);
    }
    /*
    public void Ordenes()
    {
        #region ordenes
        switch (orden)
        {
            case 1:
                general = "orden A";
                break;
            case 2:
                general = "orden B";
                break;
            case 3:
                general = "orden C";
                break;
            case 4:
                general = "orden D";
                break;
            case 5:
                general = "orden E";
                break;
            case 6:
                general = "orden F";
                break;
            case 7:
                general = "orden G";
                break;
            case 8:
                general = "orden H";
                break;
            case 9:
                general = "orden I";
                break;
            case 10:
                general = "orden J";
                break;
            case 11:
                general = "orden K";
                break;
            case 12:
                general = "orden L";
                break;
            case 13:
                general = "orden M";
                break;
        }
        #endregion
        switch (general)
        {
            case "orden A":
                break;
            case "orden B":
                break;
            case "orden C":
                break;
            case "orden D":
                break;
            case "orden E":
                break;
            case "orden F":
                break;
            case "orden G":
                break;
            case "orden H":
                break;
            case "orden I":
                break;
            case "orden J":
                break;
            case "orden K":
                break;
            case "orden L":
                break;
            case "orden M":
                break;
        }    
    }
    */
}
