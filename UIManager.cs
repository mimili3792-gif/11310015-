using UnityEngine;

public class UIManager : MonoBehaviour
{
    // 在 Inspector 把 RulesPanel 拖進這個欄位
    [SerializeField] private GameObject rulesPanel;

    // 開啟規則視窗
    public void OpenRules()
    {
        rulesPanel.SetActive(true);
        // 如果想讓遊戲暫停，可以加這行：
        // Time.timeScale = 0f; 
    }

    // 關閉規則視窗
    public void CloseRules()
    {
        rulesPanel.SetActive(false);
        // 恢復遊戲運行：
        // Time.timeScale = 1f;
    }
}