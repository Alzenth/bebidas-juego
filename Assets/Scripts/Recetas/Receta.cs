using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nueva receta", menuName = "Recetas")]
public class Receta : ScriptableObject
{

    public new string name;

    [TextArea(3, 15)]
    public string textoPedido;
    public int fresa, naranja, piña, papaya, platano, mango, granadilla, leche;
    public enum TipoDeBebida
    {
        Clásicos,
        Especiales,
        Batidos
    }
    public TipoDeBebida tipoDeBebida;
    public string tipoDEBebidaString ;

    public enum TamañoDeBebida
    {
        Pequeño,
        Mediano,
        Grande
    }
    public TamañoDeBebida tamañoDeBebida;
    public string tamañoDEBebida ;
}