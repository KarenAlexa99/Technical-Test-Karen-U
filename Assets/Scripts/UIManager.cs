using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Action OnRestart;

    [SerializeField] private Image barFillImg;
    [SerializeField] private CanvasGroup gameOverPanel, winPanel;
    [SerializeField] private Button[] restartBtn;
    [SerializeField] private TMP_Text collectedKeysText, timerTxt, recordTimeTxt;

    private void Awake()
    {
        gameOverPanel.alpha = 0;
        winPanel.alpha = 0;
        gameOverPanel.gameObject.SetActive(false);
        winPanel.gameObject.SetActive(false);

        for (int i = 0; i < restartBtn.Length; i++)
        {
            restartBtn[i].onClick.AddListener(Restart);
        }
    }

    public void JetpackBar(float _curFuel)
    {
        barFillImg.fillAmount = _curFuel;
    }

    public void ShowGameOver()
    {
        gameOverPanel.gameObject.SetActive(true);
        gameOverPanel.alpha = 1;
    }

    public void ShowWin()
    {
        winPanel.gameObject.SetActive(true);
        winPanel.alpha = 1;
    }

    private void Restart()
    {
        if (OnRestart != null)
            OnRestart();
    }

    public void SetCollectedKeys(int collectedKeys, int maximumKeys)
    {
        collectedKeysText.text = $"collected keys {collectedKeys} of {maximumKeys}";
    }

    public void UpdateTime(string timeLeft)
    {
        timerTxt.text = timeLeft;
    }

    public void SetRecordTime(string timeLeft)
    {
        recordTimeTxt.text = $"Record time of {timeLeft}";
    }
}
