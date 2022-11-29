using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private KeyManager keyManager;
    [SerializeField] private Material door;

    private TimeSpan timeSpan;
    private float curTime;

    void Start()
    {
        GamePlay();
    }

    private void GamePlay()
    {
        curTime = 0;
        playerController.gameObject.SetActive(true);
        playerController.OnGameOver += GameOver;
        playerController.OnWin += Win;
        uiManager.OnRestart += Restart;
        door.color = Color.white;
    }
    private void GameOver()
    {
        playerController.gameObject.SetActive(false);
        uiManager.ShowGameOver();
    }

    private void Restart()
    {
        SceneManager.LoadScene(0);
    }

    private void Win()
    {
        if (keyManager.CollectedKeys == keyManager.GetMaximumKeys())
        {
            door.color = Color.green;
            LeanTween.delayedCall(1, () =>
            {
                uiManager.ShowWin();
                uiManager.SetRecordTime(string.Format("{0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds));
            });
        }
        else
        {
            door.color = Color.red;
            LeanTween.delayedCall(1, () => uiManager.ShowGameOver());
        }
    }

    private void Update()
    {
        playerController.MovePlayer();
        playerController.JetpackMovement();
        uiManager.JetpackBar(playerController.curFuel);
        uiManager.SetCollectedKeys(keyManager.CollectedKeys, keyManager.GetMaximumKeys());

        curTime += Time.deltaTime;
        timeSpan = TimeSpan.FromSeconds(curTime);
        uiManager.UpdateTime(string.Format("{0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds));
    }

}

