using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour {

    [SerializeField]
    Sprite[] peppermintLeaves;

    [SerializeField]
    float boostRegen = 0.01f;

    int boostTimer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Method that will detect when the player collides with
    /// the regen pickup. Activate the boosted regen timer
    /// </summary>
    
}
