using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeBehaviour : MonoBehaviour
{
    public float Speed = 10;
    private Rigidbody rb;
    public float JumpForce = 200;
    private bool IsPlayerOnGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move
        var dir = new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")) * Speed;

        dir.y = rb.velocity.y;
        rb.velocity = dir;

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) 
            && IsPlayerOnGround)
        {
            rb.AddForce(Vector3.up * JumpForce);
        }

        var playerObject = GameObject.Find("Cube");
        var playerPos = playerObject.transform.position;
        if (playerPos.y < -5)
        {
            SceneManager.LoadScene("SampleScene");
            ScoreboardBehaviour.Score = 0;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Plate")
        {
            IsPlayerOnGround = true;

        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Plate")
        {
            IsPlayerOnGround = false;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "NextScenePortal" 
            && ScoreboardBehaviour.Score == 5)
        {
            SceneManager.LoadScene("SecondScene");
        }
    }
}
