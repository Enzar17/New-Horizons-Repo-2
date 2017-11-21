using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class controls the Cytotoxin Level UI
/// </summary>
public class CytoLevelController : MonoBehaviour {

    // the cytotoxin level UI element
    Image cytoLevelImage;

    //self explanatory...always between 0 and 1
    float cytoRegenRate = .2f;

	// Use this for initialization
	void Start () {

        // get the Cytotoxin level bar image
        cytoLevelImage = GetComponent<Image>();
        
	}

    /// <summary>
    /// Allows the regen rate to be accessed from outside of the class
    /// </summary>
    public float RegenRate
    {
        set
        {
            cytoRegenRate = value;
            if(cytoRegenRate < 0) { cytoRegenRate = 0; }//clamp
            if(cytoRegenRate > 1) { cytoRegenRate = 1; }//clamp
        }
        get { return cytoRegenRate; }

    }

    /// <summary>
    /// Allows outside access to the Cytotoxin level
    /// </summary>
    /// <param name="amount"></param>
    public float CytotoxinLevel
    {
        set
        {
            cytoLevelImage.fillAmount += value;
            if(cytoLevelImage.fillAmount > 1) { cytoLevelImage.fillAmount = 1; }//clamp amount
            if(cytoLevelImage.fillAmount < 0) { cytoLevelImage.fillAmount = 0; }//clamp amount            
        }
        get { return cytoLevelImage.fillAmount; }
    }
    /// <summary>
    /// Regen cytotoxin
    /// </summary>
    private void Update()
    {
        // do not regen cytotoxin while the mousebutton is down!
        if (cytoLevelImage.fillAmount < 1 && !Input.GetMouseButton(0))
        {
            this.CytotoxinLevel = cytoRegenRate * Time.deltaTime;
        }
    }

}
