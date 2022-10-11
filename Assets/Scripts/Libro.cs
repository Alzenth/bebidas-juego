using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Libro : MonoBehaviour
{
    public GameObject libro;
    public GameObject ingredientes;
    public GameObject preparaciones;
    public GameObject pagina1;
    public GameObject pagina2;
    public GameObject pagina3;
    public GameObject estilosJugos;
    public GameObject principal;
    public GameObject atrasInicio;
    public GameObject atras;
    public GameObject siguiente;
    public int contador;
    bool ingrediente;
    bool preparacion;
    bool estiloJugo;
    public bool abierto;

    private void Update()
    {
    }

    public void Book()
    {
        if (abierto)
        {
            libro.SetActive(false);
            abierto = !abierto;
        }
        else
        {
            libro.SetActive(true);
            abierto = !abierto;
        }
    }
    public void Inicio()
    {
        siguiente.SetActive(false);
        atras.SetActive(false);
        if (ingrediente)
        {
            ingrediente = !ingrediente;
            ingredientes.SetActive(false);
            atrasInicio.SetActive(false);
            principal.SetActive(true);
        }
        if (preparacion)
        {
            preparacion = !preparacion;
            preparaciones.SetActive(false);
            atrasInicio.SetActive(false);
            principal.SetActive(true);
        }
        if(estiloJugo)
        {
            estiloJugo = !estiloJugo;
            estilosJugos.SetActive(false);
            atrasInicio.SetActive(false);
            principal.SetActive(true);
        }
    }
    public void Ingredientes()
    {
        principal.SetActive(false);
        atrasInicio.SetActive(true);
        ingredientes.SetActive(true);
        ingrediente = true;
    }
    public void Preparacion()
    {
        preparacion = true;
        contador = 0;
        principal.SetActive(false);
        preparaciones.SetActive(true);
        pagina1.SetActive(true);
        pagina2.SetActive(false);
        pagina3.SetActive(false);
        atrasInicio.SetActive(true);
        siguiente.SetActive(true);
    }
    public void Back()
    {
        if (contador == 1)
        {
            pagina1.SetActive(true);
            pagina2.SetActive(false);
            pagina3.SetActive(false);
            siguiente.SetActive(true);
        }
        if (contador == 2)
        {
            pagina1.SetActive(false);
            pagina2.SetActive(true);
            pagina3.SetActive(false);
        }
        contador--;
        if (contador == 0)
        {
            atrasInicio.SetActive(true);
            atras.SetActive(false);
        }
    }
    public void Next()
    {
        contador++;
        if(contador == 1)
        {
            atrasInicio.SetActive(false);
            atras.SetActive(true);
            pagina1.SetActive(false);
            pagina2.SetActive(true);
            pagina3.SetActive(false);
        }
        if (contador == 2)
        {
            atrasInicio.SetActive(false);
            pagina1.SetActive(false);
            pagina2.SetActive(false);
            pagina3.SetActive(true);
            siguiente.SetActive(false);
        }
    }

    public void Bebidas()
    {
        estiloJugo = true;
        principal.SetActive(false);
        estilosJugos.SetActive(true);
        atrasInicio.SetActive(true);
    }
}
