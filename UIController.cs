using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("要控制的面板")]
    public GameObject targetPanel;

    // 開啟面板
    public void Open()
    {
        if (targetPanel != null)
        {
            targetPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("找不到 targetPanel！請把面板拖進去 Inspector 裡的欄位。");
        }
    }

    // 關閉面板
    public void Close()
    {
        if (targetPanel != null)
        {
            targetPanel.SetActive(false);
        }
    }
}