using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float damageEffectCD = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetDamage()
    {
        StartCoroutine(DamageColorCooldown());
    }
    private IEnumerator DamageColorCooldown()
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(damageEffectCD);
        transform.GetComponent<MeshRenderer>().material.color = Color.white;
    }

}
