using UnityEngine;
using UnityEngine.SceneManagement;


public class  FinishPoint : MonoBehaviour
{

    [SerializeField] private int level;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UnlockNewLevel();
            SceneManager.LoadScene(level);
            //SceneController.Instance.LoadNextLevel();
        }
    }

    void UnlockNewLevel()
    {
        PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt("UnlockedLevels", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
        PlayerPrefs.Save();
    }



}