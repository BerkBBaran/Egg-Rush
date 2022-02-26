using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float MaxHealth;
    [SerializeField] private float damageEffectCD = 0.3f;
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
            gameObject.GetComponentInParent<EnemyMovement>().isArrived = true;
        }
    }
    public void GetDamage(float attackDamage)
    {
        StartCoroutine(DamageColorCooldown());
        CurrentHealth -= attackDamage;
        Debug.Log("Shot! Current HP: " + CurrentHealth);
    }
    private IEnumerator DamageColorCooldown()
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(damageEffectCD);
        transform.GetComponent<MeshRenderer>().material.color = Color.white;
    }
    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }
}
