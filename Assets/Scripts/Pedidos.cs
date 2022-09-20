using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pedidos : MonoBehaviour
{
    //texto
    public Text ordenTexto;

    public float suavizado;
    public GameObject globoAlfa;
    public GameObject textoAlfa;
    public bool empieza;

    //variable para tiempo y limite de cuanto va llegarxd
    public float tiempo;
    public float limiteDeTiempo;

    //variable para saber que orden va pedir y para saber que orden pidio la anterior vez
    public static int recetaOrden = 0;
    public int guardarReceta;
    public static string mezcla;
    public static int fresa, naranja, piña, papaya, platano, mango, granadilla, leche;
    public string mezcla2;
    public static string tamaño;
    public string tamaño2;
    public int a;

    //variable que funciona cuando termine de pensar la orden 
    public bool terminado;

    public Receta [] recetas;
    public ControladorBebida controladorBebida;

    private void Start()
    {
        empieza = true;
    }

    private void Update()
    {
        a = recetaOrden;
        Debug.Log(a);
        tamaño2 = tamaño;
        mezcla2 = mezcla;
        IndicarPedido();

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

    public void ApareceGloboTexto()
    {
        var alphaGlobo = globoAlfa.GetComponent<RawImage>().color;

        var alphaTexto = textoAlfa.GetComponent<Text>().color;

        alphaGlobo.a = Mathf.Lerp(alphaGlobo.a, 1f, suavizado * Time.deltaTime);

        alphaTexto.a = Mathf.Lerp(alphaTexto.a,1f, suavizado * Time.deltaTime);

        if (alphaGlobo.a >= 0.9f)
        {
            alphaTexto.a = 1f;
            alphaGlobo.a = 1f;
        }
        Debug.Log(alphaGlobo);
        globoAlfa.GetComponent<RawImage>().color = alphaGlobo;
        textoAlfa.GetComponent<Text>().color = alphaTexto;
    }

    public void DesaparecerGloboTexto()
    {
        var alphaGlobo = globoAlfa.GetComponent<RawImage>().color;

        var alphaTexto = textoAlfa.GetComponent<Text>().color;

        alphaGlobo.a = Mathf.Lerp(alphaGlobo.a,0f, suavizado * Time.deltaTime);

        alphaTexto.a = Mathf.Lerp(alphaTexto.a, 0f, suavizado * Time.deltaTime);

        if (alphaGlobo.a <= 0.1f)
        {
            alphaTexto.a = 0f;
            alphaGlobo.a = 0f;
        }
        Debug.Log(alphaGlobo);
        globoAlfa.GetComponent<RawImage>().color = alphaGlobo;
        textoAlfa.GetComponent<Text>().color = alphaTexto;
    }

    //metodo para elegir la orden aleatoriamente
    public void IndicarPedido()
    {
        #region random
        /*
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
        */

        #endregion

        switch(recetaOrden)
        {
            case 0:
                ordenTexto.text = recetas[recetaOrden].textoPedido;
                mezcla = recetas[recetaOrden].tipoDEBebidaString;
                tamaño = recetas[recetaOrden].tamañoDEBebida;
                fresa = recetas[recetaOrden].fresa;
                naranja = recetas[recetaOrden].naranja;
                piña = recetas[recetaOrden].piña;
                papaya = recetas[recetaOrden].papaya;
                platano = recetas[recetaOrden].platano;
                mango = recetas[recetaOrden].mango;
                granadilla = recetas[recetaOrden].granadilla;
                leche = recetas[recetaOrden].leche;

                break;
            case 1:
                ordenTexto.text = recetas[recetaOrden].textoPedido;
                mezcla = recetas[recetaOrden].tipoDEBebidaString;
                tamaño = recetas[recetaOrden].tamañoDEBebida;
                fresa = recetas[recetaOrden].fresa;
                naranja = recetas[recetaOrden].naranja;
                piña = recetas[recetaOrden].piña;
                papaya = recetas[recetaOrden].papaya;
                platano = recetas[recetaOrden].platano;
                mango = recetas[recetaOrden].mango;
                granadilla = recetas[recetaOrden].granadilla;
                leche = recetas[recetaOrden].leche;
                break;
            case 2:
                ordenTexto.text = recetas[recetaOrden].textoPedido;
                mezcla = recetas[recetaOrden].tipoDEBebidaString;
                tamaño = recetas[recetaOrden].tamañoDEBebida;
                fresa = recetas[recetaOrden].fresa;
                naranja = recetas[recetaOrden].naranja;
                piña = recetas[recetaOrden].piña;
                papaya = recetas[recetaOrden].papaya;
                platano = recetas[recetaOrden].platano;
                mango = recetas[recetaOrden].mango;
                granadilla = recetas[recetaOrden].granadilla;
                leche = recetas[recetaOrden].leche;
                break;
            case 3:
                ordenTexto.text = recetas[recetaOrden].textoPedido;
                mezcla = recetas[recetaOrden].tipoDEBebidaString;
                tamaño = recetas[recetaOrden].tamañoDEBebida;
                fresa = recetas[recetaOrden].fresa;
                naranja = recetas[recetaOrden].naranja;
                piña = recetas[recetaOrden].piña;
                papaya = recetas[recetaOrden].papaya;
                platano = recetas[recetaOrden].platano;
                mango = recetas[recetaOrden].mango;
                granadilla = recetas[recetaOrden].granadilla;
                leche = recetas[recetaOrden].leche;
                break;
            case 4:
                ordenTexto.text = recetas[recetaOrden].textoPedido;
                mezcla = recetas[recetaOrden].tipoDEBebidaString;
                tamaño = recetas[recetaOrden].tamañoDEBebida;
                fresa = recetas[recetaOrden].fresa;
                naranja = recetas[recetaOrden].naranja;
                piña = recetas[recetaOrden].piña;
                papaya = recetas[recetaOrden].papaya;
                platano = recetas[recetaOrden].platano;
                mango = recetas[recetaOrden].mango;
                granadilla = recetas[recetaOrden].granadilla;
                leche = recetas[recetaOrden].leche;
                break;
            case 5:
                ordenTexto.text = recetas[recetaOrden].textoPedido;
                mezcla = recetas[recetaOrden].tipoDEBebidaString;
                tamaño = recetas[recetaOrden].tamañoDEBebida;
                fresa = recetas[recetaOrden].fresa;
                naranja = recetas[recetaOrden].naranja;
                piña = recetas[recetaOrden].piña;
                papaya = recetas[recetaOrden].papaya;
                platano = recetas[recetaOrden].platano;
                mango = recetas[recetaOrden].mango;
                granadilla = recetas[recetaOrden].granadilla;
                leche = recetas[recetaOrden].leche;
                break;
            case 6:
                ordenTexto.text = recetas[recetaOrden].textoPedido;
                mezcla = recetas[recetaOrden].tipoDEBebidaString;
                tamaño = recetas[recetaOrden].tamañoDEBebida;
                fresa = recetas[recetaOrden].fresa;
                naranja = recetas[recetaOrden].naranja;
                piña = recetas[recetaOrden].piña;
                papaya = recetas[recetaOrden].papaya;
                platano = recetas[recetaOrden].platano;
                mango = recetas[recetaOrden].mango;
                granadilla = recetas[recetaOrden].granadilla;
                leche = recetas[recetaOrden].leche;
                break;
            case 7:
                ordenTexto.text = recetas[recetaOrden].textoPedido;
                mezcla = recetas[recetaOrden].tipoDEBebidaString;
                tamaño = recetas[recetaOrden].tamañoDEBebida;
                fresa = recetas[recetaOrden].fresa;
                naranja = recetas[recetaOrden].naranja;
                piña = recetas[recetaOrden].piña;
                papaya = recetas[recetaOrden].papaya;
                platano = recetas[recetaOrden].platano;
                mango = recetas[recetaOrden].mango;
                granadilla = recetas[recetaOrden].granadilla;
                leche = recetas[recetaOrden].leche;
                break;
            case 8:
                ordenTexto.text = recetas[recetaOrden].textoPedido;
                mezcla = recetas[recetaOrden].tipoDEBebidaString;
                tamaño = recetas[recetaOrden].tamañoDEBebida;
                fresa = recetas[recetaOrden].fresa;
                naranja = recetas[recetaOrden].naranja;
                piña = recetas[recetaOrden].piña;
                papaya = recetas[recetaOrden].papaya;
                platano = recetas[recetaOrden].platano;
                mango = recetas[recetaOrden].mango;
                granadilla = recetas[recetaOrden].granadilla;
                leche = recetas[recetaOrden].leche;
                break;
            case 9:
                ordenTexto.text = recetas[recetaOrden].textoPedido;
                mezcla = recetas[recetaOrden].tipoDEBebidaString;
                tamaño = recetas[recetaOrden].tamañoDEBebida;
                fresa = recetas[recetaOrden].fresa;
                naranja = recetas[recetaOrden].naranja;
                piña = recetas[recetaOrden].piña;
                papaya = recetas[recetaOrden].papaya;
                platano = recetas[recetaOrden].platano;
                mango = recetas[recetaOrden].mango;
                granadilla = recetas[recetaOrden].granadilla;
                leche = recetas[recetaOrden].leche;
                break;
            case 10:
                ordenTexto.text = recetas[recetaOrden].textoPedido;
                mezcla = recetas[recetaOrden].tipoDEBebidaString;
                tamaño = recetas[recetaOrden].tamañoDEBebida;
                fresa = recetas[recetaOrden].fresa;
                naranja = recetas[recetaOrden].naranja;
                piña = recetas[recetaOrden].piña;
                papaya = recetas[recetaOrden].papaya;
                platano = recetas[recetaOrden].platano;
                mango = recetas[recetaOrden].mango;
                granadilla = recetas[recetaOrden].granadilla;
                leche = recetas[recetaOrden].leche;
                break;
            case 11:
                ordenTexto.text = recetas[recetaOrden].textoPedido;
                mezcla = recetas[recetaOrden].tipoDEBebidaString;
                tamaño = recetas[recetaOrden].tamañoDEBebida;
                fresa = recetas[recetaOrden].fresa;
                naranja = recetas[recetaOrden].naranja;
                piña = recetas[recetaOrden].piña;
                papaya = recetas[recetaOrden].papaya;
                platano = recetas[recetaOrden].platano;
                mango = recetas[recetaOrden].mango;
                granadilla = recetas[recetaOrden].granadilla;
                leche = recetas[recetaOrden].leche;
                break;
            case 12:
                ordenTexto.text = recetas[recetaOrden].textoPedido;
                mezcla = recetas[recetaOrden].tipoDEBebidaString;
                tamaño = recetas[recetaOrden].tamañoDEBebida;
                fresa = recetas[recetaOrden].fresa;
                naranja = recetas[recetaOrden].naranja;
                piña = recetas[recetaOrden].piña;
                papaya = recetas[recetaOrden].papaya;
                platano = recetas[recetaOrden].platano;
                mango = recetas[recetaOrden].mango;
                granadilla = recetas[recetaOrden].granadilla;
                leche = recetas[recetaOrden].leche;
                break;
        }
    }

}