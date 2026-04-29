using UnityEngine;
using UnityEngine.UI; // 使用 UI 組件必備

public class PanelControl : MonoBehaviour
{
    // 你只需要在 Inspector 把你的按鈕拖進來
    public Button openButton;  // 打開面板的按鈕 (RULES)
    public Button closeButton; // 關閉面板的按鈕 (CLOSE)

    void Start()
    {
        // 遊戲開始時，確保面板是隱藏的
        gameObject.SetActive(false);

        // 自動幫按鈕綁定功能，不需要再去設定 OnClick()
        if (openButton != null)
        {
            openButton.onClick.AddListener(OpenPanel);
        }

        if (closeButton != null)
        {
            closeButton.onClick.AddListener(ClosePanel);
        }
    }

    public void OpenPanel()
    {
        gameObject.SetActive(true);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}