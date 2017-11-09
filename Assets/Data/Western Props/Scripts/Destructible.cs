
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

	public GameObject destroyedVersion;	// Reference to the shattered version of the object
    public PlayerShoot ps;

	void Update()
	{
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire1");
            if (ps.hitBottle)
            {
                Debug.Log("destroy bottle");
                // Spawn a shattered object
                GameObject destroyedGO = Instantiate(destroyedVersion, transform.position, transform.rotation);
                // Remove the current object
                Destroy(gameObject);
                Destroy(destroyedGO, 3);
                ps.hitBottle = false;
                ps.addScore = true;
            }

        }

	}

}
