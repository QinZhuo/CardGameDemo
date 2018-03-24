using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour {
    [SerializeField]
    public HealthBase health;
    public List<People> enemys;
 
    public void Attack(People other,float damage)
    {
        other.GetDamage(damage);
    }
    protected void GetDamage(float damage)
    {
        health.GetDamage(damage);
    }

}
[System.Serializable]
public class HealthBase
{
    public float max;
    public float current;
    public float defense;
    public bool GetDamage(float damage)
    {
        damage -= defense;
        if (damage > 0) {
            current -= damage;
        }
        else
        {
            defense += damage;
        }
       
        if (current <= 0)
        {
            current = 0;
            return true;
        }
        else
        {
            return true;
        }
    }
}
