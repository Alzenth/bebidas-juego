using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public enum StateClient{
        Ninguno,
        Wait,
        AdvancePosition,
        order,
        preparing,
        checkOrder,
        next
    }

    public StateClient stateClient;

    public Sprite[] Skin;

    public float smooth;

    public Vector3 location;

    public GameObject[] targets;

    public bool nextC,nextB, nextA;

    public bool end;

    private void Awake()
    {
        this.GetComponent<SpriteRenderer>().sprite = Skin[Random.Range(0, 2)];

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if (stateClient == StateClient.AdvancePosition)
            {
                location = transform.position;

                if (ManaguerPosition.occupiedC == false && nextC == false)
                {
                    //moverse(location, 0);
                    StartCoroutine(Move(location, 0));

                    if (transform.position.x == targets[0].transform.position.x)
                    {
                        Debug.Log("porque");
                        nextC = true;
                    }
                }
                if (ManaguerPosition.occupiedB == false && nextC && nextB == false)
                {
                    //moverse(location, 1);
                    StartCoroutine(Move(location, 1));

                    if (transform.position.x == targets[1].transform.position.x)
                    {
                        nextB = true;
                    }
                }
                if (ManaguerPosition.occupiedA == false && nextB)
                {
                    //moverse(location, 2);
                    StartCoroutine(Move(location, 2));

                    if (transform.position.x == targets[2].transform.position.x)
                    {
                        nextA = true;
                        stateClient = StateClient.preparing;
                    }
                }
                /*
                if (ManaguerPosition.occupiedB == false)
                {
                    if (ManaguerPosition.occupiedA)
                    {
                        Debug.Log("aO");
                        position = Vector2.Lerp(position, targets[1].transform.position, smooth);

                        Vector2 target = position;

                        transform.position = target;
                    }
                }
                if (ManaguerPosition.occupiedA == false)
                {
                    Debug.Log("no");
                    position = Vector2.Lerp(position, targets[2].transform.position, smooth);

                    Vector2 target = position;

                    transform.position = target;

                }
                */
            }
            if (end)
            {
                stateClient = StateClient.next;
            }
            if (stateClient == StateClient.next)
            {
                //moverse(location, 3);
                StartCoroutine(Move(transform.position, 3));
            }
        
    }

   /* public void moverse(Vector2 position, int i)
    {
        position.x = Mathf.Lerp(position.x, targets[i].transform.position.x, smooth * Time.deltaTime);

        Vector2 target = new Vector2(position.x, 3.1f);

        transform.position = target;
    }
   */
    IEnumerator Move(Vector2 position, int i)
    {
        position.x = Mathf.Lerp(position.x, targets[i].transform.position.x, smooth * Time.deltaTime);

        Vector2 target = new Vector2(position.x, 3.1f);

        /*if (transform.position.x >= targets[i].transform.position.x - 0.2)
        {
            target = targets[i].transform.position;
        }
        */
        transform.position = target;

        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TargetC"))
        {
            transform.position = targets[0].transform.position;
        }
        if (collision.CompareTag("TargetB"))
        {
            transform.position = targets[1].transform.position;
        }
        if (collision.CompareTag("TargetA"))
        {
            transform.position = targets[2].transform.position;
        }
        if (collision.CompareTag("TargetEnd"))
        {
            transform.position = targets[4].transform.position;
            nextA = false;
            nextB = false;
            nextC = false;
            end = false;
            stateClient = StateClient.Ninguno;
        }
    }
}
