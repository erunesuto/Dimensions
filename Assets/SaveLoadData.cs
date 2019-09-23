using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SaveLoadData : MonoBehaviour
{

    public PlayerController playerController;
    public PlayerHealth playerHealth;

    public void savePlayer()
    {
        SaveSystem.savePlayer();
    }

    public void loadPlayer()
    {
        PlayerData data = SaveSystem.loadPlayer();

        playerController.level = data.level;
        playerHealth.currentHealth = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

}
