using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float MaxHealth;
    [SerializeField] private float damageEffectCD = 0.3f;
    [SerializeField] private GameObject myEgg;
    private float CurrentHealth;
    private EnemyMovement _enemyMovement;

    // Start is called before the first frame update
    void Start()
    {
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
        StartCoroutine(DamageColorCooldown());
        CurrentHealth -= attackDamage;
        AmIDead();
    }
    public void TakeEgg()
    {
        myEgg.SetActive(true);

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
            Destroy(gameObject,0.2f);
        }
    }
}
