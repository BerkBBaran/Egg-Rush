using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float moveSpeed;
    private Vector3[] Nest;
    [SerializeField] GameObject Object;
    private Vector3[] SpawnPosition;
    private Vector3 toPosition;
    public bool isArrived = false;
    // Start is called before the first frame update
    public void goPosition(Vector3 targetPosition, float positionTolerance)
        {
            toPosition = new Vector3(targetPosition.x - transform.position.x, targetPosition.y - transform.position.y, targetPosition.z - transform.position.z);

            if (Mathf.Abs(targetPosition.x - transform.position.x) + Mathf.Abs(targetPosition.z - transform.position.z) > positionTolerance)
            {
                rb.MovePosition(transform.position + Vector3.Normalize(toPosition) * Time.deltaTime * moveSpeed);
            }else{
                isArrived = true;
            }   
        }
    void Start()
    {     
        rb = GetComponent<Rigidbody>();
        SpawnPosition = new Vector3[8];
        Nest = new Vector3[4];
        Nest[0] = new Vector3(10, 51, -10);
        Nest[1] = new Vector3(30, 51, 10);
        Nest[2] = new Vector3(50, 51, -10);
        Nest[3] = new Vector3(30, 51, -30);
        SpawnPosition[0] = new Vector3(-30,51,-10);
        SpawnPosition[1] = new Vector3(-30,51,50);
        SpawnPosition[2] = new Vector3(30,51,50);
        SpawnPosition[3] = new Vector3(90,51,50);
        SpawnPosition[4] = new Vector3(90,51,-10);
        SpawnPosition[5] = new Vector3(90,51,-70);
        SpawnPosition[6] = new Vector3(30,51,-70);
        SpawnPosition[7] = new Vector3(-30,51,-70);

    }

    // Update is called once per frame
    void Update()
    {
        if(isArrived == false)
        {
            if(Object.CompareTag("0"))
            {
                goPosition(Nest[0], 1.5f);
            }
            if(Object.CompareTag("1"))
            {
                goPosition(Nest[0], 1.5f);
            }
            if(Object.CompareTag("2"))
            {
                goPosition(Nest[1], 1.5f);
            }
            if(Object.CompareTag("3"))
            {
                goPosition(Nest[1], 1.5f);
            }
            if(Object.CompareTag("4"))
            {
                goPosition(Nest[2], 1.5f);
            }
            if(Object.CompareTag("5"))
            {
                goPosition(Nest[2], 1.5f);
            }
            if(Object.CompareTag("6"))
            {
                goPosition(Nest[3], 1.5f);
            }
            if(Object.CompareTag("7"))
            {
                goPosition(Nest[3], 1.5f);
            }
        }else{
            if(Object.CompareTag("0"))
            {
                goPosition(SpawnPosition[0], 0.2f);
            }
            if(Object.CompareTag("1"))
            {
                goPosition(SpawnPosition[1], 0.2f);
            }
            if(Object.CompareTag("2"))
            {
                goPosition(SpawnPosition[2], 0.2f);
            }
            if(Object.CompareTag("3"))
            {
                goPosition(SpawnPosition[3], 0.2f);
            }
            if(Object.CompareTag("4"))
            {
                goPosition(SpawnPosition[4], 0.2f);
            }
            if(Object.CompareTag("5"))
            {
                goPosition(SpawnPosition[5], 0.2f);
            }
            if(Object.CompareTag("6"))
            {
                goPosition(SpawnPosition[6], 0.2f);
            }
            if(Object.CompareTag("7"))
            {
                goPosition(SpawnPosition[7], 0.2f);
            }
            
        }

    }
}

