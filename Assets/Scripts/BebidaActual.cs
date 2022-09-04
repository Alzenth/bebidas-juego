using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BebidaActual : MonoBehaviour
{
    public static int fresaCantidad, naranjaCantidad, pi�aCantidad, papayaCantidad, platanoCantidad, mangocantidad, granadillaCantidad, lecheCantidad;
    public enum TipoDeBebida
    {
        Cl�sicos,
        Especiales,
        Batidos
    }
    public static TipoDeBebida tipoDeBebida;
    public enum Tama�oDeBebida
    {
        Peque�o,
        Mediano,
        Grande
    }
    public static Tama�oDeBebida tama�oDeBebida;

    public Text texto;

    private void Start()
    {

    }
    void Update()
    {







        texto.text = "Datos de la bebida actual"+
            " Fresa: "+fresaCantidad+
            " Leche: "+naranjaCantidad+
            " Pi�a: "+pi�aCantidad+
            " Papaya: "+papayaCantidad+
            " Platano: "+platanoCantidad+
            " Mango: "+mangocantidad+
            " Granadilla: "+granadillaCantidad+
            " Leche: "+lecheCantidad+
            " Tipo: "+ tipoDeBebida+
            " Tama�o: "+tama�oDeBebida;
    }
}
