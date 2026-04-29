using UnityEngine;
using UnityEngine.SceneManagement; // 如果你要切換場景需要這個

public class GameManager : MonoBehaviour
{
    public override bool Equals(object other)
    {
        return base.Equals(other);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    // 運行遊戲（通常是載入第一個遊戲關卡場景）
    public void GameScene()
    {
        // "GameScene" 請替換成你遊戲場景的實際名稱
        // 如果你只是想在選單點擊後進入下一關，可以使用：
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        Debug.Log("遊戲開始！");
    }

    // 退出遊戲
    public void QUIT()
    {
        // 這會關閉執行中的 .exe 或應用程式
        Application.Quit();

        // 因為在 Unity 編輯器內按下 Quit 不會有反應，所以加這行方便測試
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Debug.Log("遊戲已退出");
    }

    public override string ToString()
    {
        return base.ToString();
    }
}