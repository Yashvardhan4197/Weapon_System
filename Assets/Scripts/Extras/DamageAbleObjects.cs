
using UnityEngine;

public class DamageAbleObjects : MonoBehaviour, IDamageAble
{
    [SerializeField] float health;
    public void TakeDamage(float damage)
    {
        health-= damage;
        if(health < 0)
        {
            Destroy(gameObject);
        }
    }
}

