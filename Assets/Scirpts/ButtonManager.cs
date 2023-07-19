using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Database database;
    public GameObject sound;
    public GameObject mute;
    public GameObject startPanel;
    public GameObject storePanel;
    public GameObject lock1;

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
    public void Sounds()
    {
        sound.SetActive(false);
        mute.SetActive(true);
    }
    public void Mute()
    {
        mute.SetActive(false);
        sound.SetActive(true);
    }
    public void Play()
    {
        startPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Store()
    {
        storePanel.SetActive(true);
    }
    public void Lock()
    {
        if (database.coin >= 100)
        {
            lock1.SetActive(false);
            database.coin += -100;
        }
    }
    public void Back()
    {
        storePanel.SetActive(false);
    }
}
