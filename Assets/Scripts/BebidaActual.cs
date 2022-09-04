using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BebidaActual : MonoBehaviour
{
    public static int fresaCantidad, naranjaCantidad, piñaCantidad, papayaCantidad, platanoCantidad, mangocantidad, granadillaCantidad, lecheCantidad;
    public enum TipoDeBebida
    {
        Clásicos,
        Especiales,
        Batidos
    }
    public static TipoDeBebida tipoDeBebida;
    public enum TamañoDeBebida
    {
        Pequeño,
        Mediano,
        Grande
    }
    public static TamañoDeBebida tamañoDeBebida;

    public Text texto;

    private void Start()
    {

    }
    void Update()
    {







        texto.text = "Datos de la bebida actual"+
            " Fresa: "+fresaCantidad+
            " Leche: "+naranjaCantidad+
            " Piña: "+piñaCantidad+
            " Papaya: "+papayaCantidad+
            " Platano: "+platanoCantidad+
            " Mango: "+mangocantidad+
            " Granadilla: "+granadillaCantidad+
            " Leche: "+lecheCantidad+
            " Tipo: "+ tipoDeBebida+
            " Tamaño: "+tamañoDeBebida;
    }
}
