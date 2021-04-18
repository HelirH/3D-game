using UnityEngine;
using System.Collections;
using System;

public class PlayerScript : MonoBehaviour {

    public int coins;

	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	protected void Start() {
        Abilities.doubleJumpEnabled = false;
        Abilities.spinAttackEnabled = false;
    }

    // OnTriggerEnter is called when the Collider "collided" enters the trigger.
    protected void OnTriggerEnter(Collider collided)
    {

        // Check for collision with coins
        if (collided.gameObject.tag == "Coin")
        {
            coins++;
            HUD.UpdateCoinCount(coins);
            Destroy(collided.gameObject);
            if (coins == 1)
                HUD.Message("ACHIVEMENT: You have collected your first coin!");
        }
        // Check for collision with powerup
        if (collided.gameObject.tag == "Powerup")
        {
            Abilities.doubleJumpEnabled = true;
            HUD.Message("ACHIVEMENT: Collect a powerup!");
            Destroy(collided.gameObject, 1f);
        }
        if (collided.gameObject.tag == "Powerup2")
        {
            Abilities.spinAttackEnabled = true;
            Destroy(collided.gameObject, 1f);
        }
    }
}