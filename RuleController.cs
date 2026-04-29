using UnityEngine;

public class RuleController : MonoBehaviour
{
    // 把你的規則視窗 (RulesWindow) 拖進這個欄位
    public GameObject rulesWindow;

    void Start()
    {
        // 遊戲開始時，先把規則視窗藏起來
        rulesWindow.SetActive(false);
    }

    // 按下「開啟」按鈕時執行
    public void OpenRules()
    {
        rulesWindow.SetActive(true);
    }

    // 按下「關閉」按鈕時執行
    public void CloseRules()
    {
        rulesWindow.SetActive(false);
    }
}