using UnityEngine;

public class QuitHandler : MonoBehaviour
{
    public void DoQuit()
    {
        Debug.Log("按下了退出鍵！");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // 這行能讓你在編輯器內測試時真的停下來
#else
            Application.Quit();
#endif
    }
}