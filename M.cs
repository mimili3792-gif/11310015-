using UnityEngine;
using UnityEngine.SceneManagement; // 切換場景用

public class MainMenu : MonoBehaviour
{
    [Header("UI 面板設定")]
    public GameObject rulesPanel; // 在 Inspector 中拖入你的規則視窗面板

    // 1. 開始遊戲 (按鈕：START)
    public void PlayGame()
    {
        // 確保你的遊戲場景名稱叫 "GameScene"，或者改為你的場景名
        SceneManager.LoadScene("GameScene");
    }

    // 2. 打開規則視窗 (按鈕：RULES)
    public void OpenRules()
    {
        if (rulesPanel != null)
        {
            rulesPanel.SetActive(true);
        }
    }

    // 3. 關閉規則視窗 (按鈕：CLOSE)
    public void CloseRules()
    {
        if (rulesPanel != null)
        {
            rulesPanel.SetActive(false);
        }
    }

    // 4. 退出遊戲 (按鈕：QUIT)
    public void QuitGame()
    {
        Debug.Log("遊戲已關閉");
        Application.Quit(); // 實際運行時會關閉程式
    }
}