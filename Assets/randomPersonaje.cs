using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomPersonaje : MonoBehaviour
{
    public Sprite[] personas;
    public int escoge;
    public float suavizado;
    public ControladorPersonajes controladorPersonajes;
    public Pedidos pedidos;
    public bool quieto;
    public bool irse, posi1, posi2, posi3;

    private void Start()
    {

    }

    private void Awake()
    {
        escoge = Random.Range(0, 2);
        this.GetComponent<SpriteRenderer>().sprite = personas[escoge];

        pedidos = FindObjectOfType<Pedidos>();
        controladorPersonajes = FindObjectOfType<ControladorPersonajes>();
    }

    private void Update()
    {
        Moverse();
    }

    public void Moverse()
    {
        if (irse)
        {
           var posicion = this.gameObject.transform.position;

           posicion.x = Mathf.Lerp(posicion.x, controladorPersonajes.posicion[3].transform.position.x, suavizado);

           Vector2 objecto = new Vector2(posicion.x, 3.4f);

           transform.position = objecto;

        }

        if (quieto == false && irse == false)
        {
            if (controladorPersonajes.ocupado[0] == false && controladorPersonajes.ocupado[1] == false && controladorPersonajes.ocupado[2] == false || controladorPersonajes.ocupado[0] == false && controladorPersonajes.ocupado[1] == false && controladorPersonajes.ocupado[2] == true || controladorPersonajes.ocupado[0] == false && controladorPersonajes.ocupado[1] == true && controladorPersonajes.ocupado[2] == true || controladorPersonajes.ocupado[0] == false && controladorPersonajes.ocupado[1] == true && controladorPersonajes.ocupado[2] == false)
            {
                var posicion = this.gameObject.transform.position;

                posicion.x = Mathf.Lerp(posicion.x, controladorPersonajes.posicion[0].transform.position.x, suavizado);

                Vector2 objecto = new Vector2(posicion.x, 3.4f);

                transform.position = objecto;

            }

            if (controladorPersonajes.ocupado[1] == false && controladorPersonajes.ocupado[0])
            {
                var posicion = this.gameObject.transform.position;

                posicion.x = Mathf.Lerp(posicion.x, controladorPersonajes.posicion[1].transform.position.x, suavizado);

                Vector2 objecto = new Vector2(posicion.x, 3.4f);

                transform.position = objecto;
            }

            if (controladorPersonajes.ocupado[2] == false && controladorPersonajes.ocupado[1] && controladorPersonajes.ocupado[0])
            {
                var posicion = this.gameObject.transform.position;

                posicion.x = Mathf.Lerp(posicion.x, controladorPersonajes.posicion[2].transform.position.x, suavizado);

                Vector2 objecto = new Vector2(posicion.x, 3.4f);

                transform.position = objecto;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PosicionA"))
        {
            Debug.Log("dadas");
            controladorPersonajes.ocupado[0] = true;
            quieto = true;
            posi1 = true;
        }
        if (collision.CompareTag("PosicionB"))
        {
            if (controladorPersonajes.ocupado[0])
            {
                controladorPersonajes.ocupado[1] = true;
                quieto = true;
                posi2 = true;
            }
        }
        if (collision.CompareTag("PosicionC"))
        {
            if (controladorPersonajes.ocupado[1])
            {
                controladorPersonajes.ocupado[2] = true;
                quieto = true;
                posi3 = true;
            }
        }
        if (collision.CompareTag("PosicionD"))
        {
          // Destroy(gameObject);
           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PosicionA"))
        {
            controladorPersonajes.ocupado[0] = false;
            quieto = false;
            posi1 = false;
        }
        if (collision.CompareTag("PosicionB"))
        {
            controladorPersonajes.ocupado[1] = false;
            quieto = false;
            posi2 = false;

        }
        if (collision.CompareTag("PosicionC"))
        {
            controladorPersonajes.ocupado[2] = false;
            quieto = false;
            posi3 = false;

        }
    }
}