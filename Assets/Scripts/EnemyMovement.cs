using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //serialize
    [SerializeField] private float positionTolerance = 2f;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform groundCheck;
    [SerializeField] public float groundDistance = 0.4f;
    [SerializeField] public LayerMask groundMask;
    //public
    [NonSerialized] public int spawnerNo;
    [NonSerialized] public List<Transform> NestPoints;
    [NonSerialized] public List<Transform> SpawnPoints;
    [NonSerialized] public bool isArrived = false;

    Rigidbody rb;
    //privates
    private int targetNestNo;
    private Vector3 toPosition;
    private bool isGrounded;
    private EnemyManager _enemyManager;
    private Animator animator;
    

    // Start is called before the first frame update
    public void goPosition(Vector3 targetPosition)
        {
            Vector3 movementDir;
            toPosition = new Vector3(targetPosition.x - transform.position.x, targetPosition.y - transform.position.y, targetPosition.z - transform.position.z);

            //Face Position
            
            movementDir = toPosition;
            movementDir.Normalize();
            if(movementDir != Vector3.zero)
                {
                    transform.forward = -movementDir;
                }
            
            //Move Position
            if (Mathf.Abs(targetPosition.x - transform.position.x) + Mathf.Abs(targetPosition.z - transform.position.z) > positionTolerance)
            {
                if (isGrounded)
                    rb.MovePosition( transform.position + Vector3.Normalize(toPosition) * Time.deltaTime * moveSpeed);
            }
            else
            {
                if (!isArrived)
                {
                    isArrived = true;
                    _enemyManager.TakeEgg();
                //    StartCoroutine(SetOnArriveAnimation()); Buglu, sürekli çalışıp duruyor çözemedim
                }
                else 
                {
                Destroy(gameObject);
                }

            }   
        }
    void Start()
    {     
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        targetNestNo = TargetNest();
        _enemyManager = GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        if (!isArrived){
            goPosition(NestPoints[targetNestNo].position);
        }
        else
        {
            moveSpeed = 110;
            goPosition(SpawnPoints[spawnerNo].position);

        }


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

    private IEnumerator SetOnArriveAnimation(){
        animator.SetTrigger("onArrived");
        yield return new WaitForSeconds(1.0f);
        animator.ResetTrigger("onArrived");
    }

}

