using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeathSystem : MonoBehaviour
{
	public GameObject ragdoll;

    void OnDeath() {
    	References.stats.AddKill();
    	Instantiate(ragdoll, transform.position, transform.rotation);
    	Destroy(gameObject);
    }
}
