using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float Forwordforce = 2000f;
    public float Sidewaysforce = 500f;
    public float JumpSpeed = 0.1f;
    bool Isgrounded;
    string Ground_tag = "Ground";
    

    // Update is called once per frame
    void FixedUpdate()
    {
       
        rb.AddForce(0,0,Forwordforce * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Sidewaysforce * Time.deltaTime,0,0,ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-Sidewaysforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetButton("Jump") && Isgrounded)
        {  
            Isgrounded = false;
            rb.AddForce(new Vector3(0, JumpSpeed, 0),ForceMode.Impulse);
        }
        if(rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame(); 
        }

    }
    private void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.gameObject.CompareTag(Ground_tag))
        {
            Isgrounded = true;
        }

    }
}
    