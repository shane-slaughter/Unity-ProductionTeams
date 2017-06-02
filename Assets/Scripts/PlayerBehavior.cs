﻿using UnityEngine;

public class PlayerBehavior : MonoBehaviour, IDamageable
{

    private GameObject bottle;
    public GameObject bottlePrefab;

    private int _playerHealth = 100;

    
    public int PlayerHealth
    {
        get { return _playerHealth; }
        set { _playerHealth = value; }
    }


    public void TakeDamage(int amount)
    {
        PlayerHealth -= amount;
    }
   

    public void ThrowBottle()
    {
        bottle = Instantiate(bottlePrefab, transform, false);
        bottle.transform.SetParent(null);
        bottle.GetComponent<Rigidbody>().velocity += transform.TransformDirection(0, 0, 25);
        Destroy(bottle, 10);
    }

    public void Dead()
    {
        gameObject.GetComponent<Material>().color = Color.red;
    }


    public void Update()
    {
        if(PlayerHealth == 0)
            Dead();

        if(Input.GetMouseButtonDown(0))
            ThrowBottle();
    }

  
}