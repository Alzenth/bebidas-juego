using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nueva receta", menuName = "Recetas")]
public class Receta : ScriptableObject
{

    public new string name;

    [TextArea(3, 15)]
    public string textoPedido;
    public int fresa, naranja, pi�a, papaya, platano, mango, granadilla, leche;
    public enum TipoDeBebida
    {
        Cl�sicos,
        Especiales,
        Batidos
    }
    public TipoDeBebida tipoDeBebida;
    public string tipoDEBebidaString ;

    public enum Tama�oDeBebida
    {
        Peque�o,
        Mediano,
        Grande
    }
    public Tama�oDeBebida tama�oDeBebida;
    public string tama�oDEBebida ;
}