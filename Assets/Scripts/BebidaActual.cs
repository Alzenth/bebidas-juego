using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BebidaActual : MonoBehaviour
{
    public static int fresaCantidad, naranjaCantidad, piñaCantidad, papayaCantidad, platanoCantidad, mangocantidad, granadillaCantidad, lecheCantidad;
    public enum TipoDeBebida
    {
        Ninguno,
        Clásicos,
        Especiales,
        Batidos        
    }
    public static TipoDeBebida tipoDeBebida;
    public enum TamañoDeBebida
    {
        Ninguno,
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
    public static void ReiniciarIngredientes()
    {
        fresaCantidad = 0;
        naranjaCantidad = 0;
        piñaCantidad = 0;
        papayaCantidad = 0;
        platanoCantidad = 0;
        mangocantidad = 0;
        granadillaCantidad = 0;
        lecheCantidad = 0;
    }
    public static void ReiniciarMezcla()
    {
        ControladorBebida.numeroDeClics = 0;
    }

    public static void ReiniciarTamaño()
    {
        tamañoDeBebida = TamañoDeBebida.Ninguno;
    }

    public static void ReiniciarIntento()
    {
        ReiniciarIngredientes();
        ReiniciarMezcla();
        ReiniciarTamaño();
    }
}
