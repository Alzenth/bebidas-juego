using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public enum StateClient{
        Ninguno,
        AdvancePosition,
        order,
        preparing,
        checkOrder,
        next
    }

    public StateClient stateClient;

    public Sprite[] Skin;

    public float smooth;

    public float location;

    public GameObject[] targets;

    public bool nextC,nextB, nextA;

    private void Awake()
    {
        this.GetComponent<SpriteRenderer>().sprite = Skin[Random.Range(0, 2)];

        location = this.transform.position.x;

        stateClient = StateClient.AdvancePosition;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stateClient == StateClient.AdvancePosition)
        {
            var position = transform.position;

            if (ManaguerPosition.occupiedC == false &&  nextC == false)
            {
                StartCoroutine(Move(position, 0));

                if (transform.position.x == targets[0].transform.position.x)
                {
                    nextC = true;
                }
            }
            if (ManaguerPosition.occupiedB == false && nextC && nextB == false)
            {
                StartCoroutine(Move(position, 1));

                if (transform.position.x == targets[1].transform.position.x)
                {
                    nextB = true;
                }
            }
            if (ManaguerPosition.occupiedA == false && nextB)
            {
                StartCoroutine(Move(position, 2));

                if (transform.position.x == targets[2].transform.position.x)
                {
                   nextA = true;
                   stateClient  = StateClient.preparing;
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
    }

    IEnumerator Move(Vector2 position, int i)
    {
        position.x = Mathf.Lerp(position.x, targets[i].transform.position.x, smooth * Time.deltaTime);

        Vector2 target = new Vector2(position.x, 3.1f);

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
    }
}
