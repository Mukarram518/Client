// This script handles detecting collisions with traps and telling the Game Manager
// when the player dies
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDieEffect : MonoBehaviour
{
	public GameObject deathVFXPrefab;   //The visual effects for player death
    public GameObject player;
	
    
 public void PlayerDie()
    {
        player.SetActive(false);
        Instantiate(deathVFXPrefab, transform.position, transform.rotation);
        AudioManager.PlayDeathAudio();

    }
}
