using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pasar : MonoBehaviour
{
    public GameObject per1;
    public GameObject posi1;
    public float tiempo;
    public bool cupo1;//,cupo2,cupo3;

    private void Update()
    {
        Posicion();
    }

    public void Posicion()
    {/*
        if (posi1.GetComponent<Collision>().c == false)
        {
            per1 = posi1.GetComponent<Collision>().per;
            per1.GetComponent<randomPersonaje>().quieto = false;
        }
        if (posi2.GetComponent<Collision>().c == false)
        {
            per2 = posi2.GetComponent<Collision>().per;
            per2.GetComponent<randomPersonaje>().quieto = false;
        }
        if (posi3.GetComponent<Collision>().c == false)
        {
            tiempo += 1 * Time.deltaTime;
            if (tiempo >= 1f)
            {
                per3 = posi3.GetComponent<Collision>().per;
                per3.GetComponent<randomPersonaje>().quieto = false;
            }
        }
        */
    }
    public void Siguiente()
    {
        if (cupo1)
        {
            per1.GetComponent<randomPersonaje>().irse = true;
        }
       /* if (per1.GetComponent<randomPersonaje>().posi2)
        {
            //cupo2 = false;
        }
        if (per1.GetComponent<randomPersonaje>().posi3)
        {
           // cupo3 = false;
        }*/
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Persona"))
        {
            per1 = collision.gameObject;
            cupo1 = true;
        }
      /*  if (posi2.CompareTag("Persona"))
        {
            per1 = gameObject;
            cupo2 = true;
        }
        if (posi3.CompareTag("Persona"))
        {
            per1 = gameObject;
            cupo3 = true;
        }*/
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (posi1.CompareTag("Persona"))
        {
            per1 = null;
            cupo1 = false;
        }
       /* if (posi2.CompareTag("Persona"))
        {
            per1 = null;
            cupo1 = false;
        }
        if (posi3.CompareTag("Persona"))
        {
            per1 = null;
            cupo1 = false;
        }*/
    }

}
