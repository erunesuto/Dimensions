using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData : MonoBehaviour//el monobehavoiur lo mismo hay que quitarlo
{
    public int level;
    public int health;

    public float[] position;

    public PlayerController playerController;//SIN EL MONOBEHAVIUR ES PRIVATE
    public PlayerHealth playerHealth;//el valor es nulo, hay que asignarle el valor de la vida de Hara SIN EL MONOBEHAVIUR ES PRIVATE

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    public PlayerData ()//constructor
    {
        //level = playerController.level;//current level
        health = playerHealth.currentHealth;//current life
        
        position = new float[3];//position of the player
        position[0] = this.playerController.transform.position.x;
        position[1] = this.playerController.transform.position.y;
        position[2] = this.playerController.transform.position.z;
    }

}
