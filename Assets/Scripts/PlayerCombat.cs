using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //serialized
    [SerializeField] private float attackCD=0.5f;
    [SerializeField] private float attackDamage;

    //private
    private bool inRange;
    private bool canAttack;
    public EnemyManager _closestEnemy;
 
    void Start()
    {
        _closestEnemy = null;
        inRange = false;
        canAttack = true;

    }

    // Update is called once per frame
    void Update()
    {           
        if (Input.GetButton("Fire1") && inRange && canAttack && _closestEnemy!= null)
        {     
            StartCoroutine(SetAttackCooldown());
            _closestEnemy.GetDamage(attackDamage);
        }
    }
    public IEnumerator SetAttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCD);
        canAttack = true;
    }


    void OnTriggerEnter(Collider col)
    {
        EnemyManager tempSc = col.gameObject.GetComponent<EnemyManager>();

        if (tempSc != null)
        {
            inRange = true;
            _closestEnemy = tempSc;
        }
    }

    void OnTriggerExit(Collider col)
    {
        EnemyManager tempSc = col.gameObject.GetComponent<EnemyManager>();
        if (tempSc != null)
        {
            inRange = false;
            _closestEnemy = null;
        }
    }
}