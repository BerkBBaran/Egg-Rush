using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //serialize
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform groundCheck;
    [SerializeField] public float groundDistance = 0.4f;
    [SerializeField] public LayerMask groundMask;
    //public
    public int spawnerNo;
    public List<Transform> NestPoints;
    public List<Transform> SpawnPoints;

    Rigidbody rb;
    //privates
    private int targetNestNo;
    private Vector3 toPosition;
    private bool isArrived = false;
    private bool isGrounded;
    

    // Start is called before the first frame update
    public void goPosition(Vector3 targetPosition)
        {
            float positionTolerance = 1.5f;
            toPosition = new Vector3(targetPosition.x - transform.position.x, targetPosition.y - transform.position.y, targetPosition.z - transform.position.z);

            if (Mathf.Abs(targetPosition.x - transform.position.x) + Mathf.Abs(targetPosition.z - transform.position.z) > positionTolerance)
            {
                if (isGrounded)
                    rb.MovePosition( transform.position + Vector3.Normalize(toPosition) * Time.deltaTime * moveSpeed);
            }
            else{
                isArrived = true;
            }   
        }
    void Start()
    {     
        rb = transform.GetComponent<Rigidbody>();
        targetNestNo = TargetNest();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        if (!isArrived)
            goPosition(NestPoints[targetNestNo].position);
        else
            goPosition(SpawnPoints[spawnerNo].position);

    }
    private int TargetNest()
    {
        if (spawnerNo == 0 ||  spawnerNo == 1)
            return 0;
        else if (spawnerNo == 2 || spawnerNo == 3)
            return 1;
        else if (spawnerNo == 4 || spawnerNo == 5)
            return 2;
        else
            return 3;
    }

    

}

