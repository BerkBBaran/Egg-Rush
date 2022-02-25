using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //serialized
    [SerializeField] private float attackCD=0.5f;
    [SerializeField] private float damageEffectCD = 0.3f;


    //private
    private bool inRange;
    private bool canAttack;
    private EnemyManager _closestEnemy;
 
    void Start()
    {
        _closestEnemy = null;
        inRange = false;
        canAttack = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1")  && inRange && canAttack)
        {     
            StartCoroutine(SetAttackCooldown());
            StartCoroutine(DamageColorCooldown(_closestEnemy));
        }

    }
    public IEnumerator SetAttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCD);
        canAttack = true;
    }

    public IEnumerator DamageColorCooldown(EnemyManager lastenemy)
    {
        if(lastenemy!=null)
            lastenemy.transform.parent.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(attackCD);
        if (lastenemy != null)
            lastenemy.transform.parent.GetComponentInChildren<MeshRenderer>().material.color = Color.white;
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
