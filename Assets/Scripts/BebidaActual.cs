using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BebidaActual : MonoBehaviour
{
    public static int fresaCantidad, naranjaCantidad, pi�aCantidad, papayaCantidad, platanoCantidad, mangocantidad, granadillaCantidad, lecheCantidad;
    public enum TipoDeBebida
    {
        Ninguno,
        Cl�sicos,
        Especiales,
        Batidos        
    }
    public static TipoDeBebida tipoDeBebida;
    public enum Tama�oDeBebida
    {
        Ninguno,
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
    public static void ReiniciarIngredientes()
    {
        fresaCantidad = 0;
        naranjaCantidad = 0;
        pi�aCantidad = 0;
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

    public static void ReiniciarTama�o()
    {
        tama�oDeBebida = Tama�oDeBebida.Ninguno;
    }

    public static void ReiniciarIntento()
    {
        ReiniciarIngredientes();
        ReiniciarMezcla();
        ReiniciarTama�o();
    }
}
