using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //serialized
    [SerializeField] private float MaxHealth;
    [SerializeField] private int eggStealAmount=1;
    [SerializeField] private float damageEffectCD = 0.3f;
    [SerializeField] private GameObject myEgg;

    //public
    [NonSerialized] public EggManager _eggManager;

    //private
    private float CurrentHealth;
    private EnemyMovement _enemyMovement;
    private Animator animator;
    private int CarryEggAmount;


    // Start is called before the first frame update
    void Start()
    {
        CarryEggAmount = 0;
        animator = GetComponent<Animator>();
        SetMaxHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentHealth <= 0){
            gameObject.GetComponent<EnemyMovement>().isArrived = true;
        }
    }
    public void GetDamage(float attackDamage)
    {
        //StartCoroutine(DamageColorCooldown());
        CurrentHealth -= attackDamage;
        AmIDead();
    }
    public void TakeEgg()
    {
        myEgg.SetActive(true);
        _eggManager.DecreaseEgg(eggStealAmount);
        CarryEggAmount++;
    }
    private IEnumerator DamageColorCooldown()
    {
        transform.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(damageEffectCD);
        transform.GetComponentInChildren<MeshRenderer>().material.color = Color.white;
    }
    private void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }
    private void AmIDead() {
        if (CurrentHealth <= 0)
        {
            if (CarryEggAmount > 0)
                _eggManager.IncreaseEgg(CarryEggAmount);
            Destroy(gameObject,0.2f);
            
        }
    }
}
