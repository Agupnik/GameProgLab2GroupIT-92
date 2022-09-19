using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreboardBehaviour : MonoBehaviour
{
    public static int Score = 0;

    private void OnGUI()
    {
        GUI.skin.box.fontSize = 30;
        GUI.Box(new Rect(50, 50, 200, 50), $"Score: {Score}");
        if (Score == 5 
            && SceneManager.GetActiveScene().name == "SampleScene")
        {
            GUI.Box(new Rect(300, 50, 400, 50), $"New zone unlocked!");
        }
    }
}
