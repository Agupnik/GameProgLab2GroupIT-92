using UnityEngine;

public class PillPoint : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "Cube")
        {
            ScoreboardBehaviour.Score += 1;
            Destroy(gameObject);
        }
    }
}
