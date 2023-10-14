using UnityEngine;

public class Player_collition : MonoBehaviour
{
   public Player_Movement Movement;
  
   void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Obtacles")
        {
            Movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
