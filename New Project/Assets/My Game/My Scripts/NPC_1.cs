using UnityEngine;
using System.Collections;

public class NPC_1 : NPC {
	 
	public override void OnSetUpDialogue() {
        Speech.AddDialogue("0", "Hello, comrade!", "1");
        Speech.AddDialogue("1", "Welcome to this lonely desert.", "2");
        Speech.AddDialogue("2", "You need to help us.", "3");
        Speech.AddDialogue("3", "There are a lot of enemies that want to destroy our village.", "4");
        Speech.AddDialogue("4", "You need to find a powerup.", "5");
        Speech.AddDialogue("5", "And save us.");
        Speech.AddDialogue("6", "Hello, comrade!", "7");
        Speech.AddDialogue("7", "Welcome to this lonely desert.", "8");
        Speech.AddDialogue("8", "You need to help us.", "9");
        Speech.AddDialogue("9", "There are a lot of enemies that want to destroy our village.", "10");
        Speech.AddDialogue("10", "I can see you already found the powerup.", "11");
        Speech.AddDialogue("11", "Good, now you can move to next level.");
    }

	// Triggered when the player comes in range of the NPC
	public override void OnTriggerNPC( Collider other ){
        if (Abilities.doubleJumpEnabled)
        {
            Speech.SetDialogue("6");
        }
        else
        {
            Speech.SetDialogue("0");
        }
	}
}