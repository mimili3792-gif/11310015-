using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;

public class playerinputaction : MonoBehaviour
{
    [Header("移動設定")]
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 12f;

    [Header("場景設定")]
    [SerializeField] private string loseSceneName = "LoseScene";

    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource audioSource;
    private Vector2 moveInput;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        // --- 強制重置狀態，防止玩家卡住 ---
        isDead = false;
        if (rb != null)
        {
            rb.simulated = true; // 確保物理模擬是開啟的
            rb.linearVelocity = Vector2.zero; // 重置速度
        }

        // 檢查組件是否存在
        if (rb == null) Debug.LogError("錯誤：主角身上找不到 Rigidbody2D！");
        if (audioSource == null) Debug.LogWarning("提醒：主角身上沒有 AudioSource，將無法播放受傷音效。");
    }

    // 當鍵盤/手把輸入時觸發
    public void OnMove(InputAction.CallbackContext context)
    {
        if (isDead)
        {
            moveInput = Vector2.zero;
            return;
        }
        moveInput = context.ReadValue<Vector2>();
        // Debug.Log("讀取到移動訊號：" + moveInput); // 如果不動，請取消此行註解來檢查
    }

    // 當按跳躍鍵時觸發
    public void OnJump(InputAction.CallbackContext context)
    {
        if (!isDead && context.started)
        {
            // 簡單判斷：只有當 y 軸速度接近 0 時才能跳，防止無限二段跳
            if (Mathf.Abs(rb.linearVelocity.y) < 0.01f)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    void FixedUpdate()
    {
        // 如果死亡，停止所有物理移動邏輯
        if (rb == null || isDead) return;

        // 水平移動
        float targetXVelocity = moveInput.x * moveSpeed;
        rb.linearVelocity = new Vector2(targetXVelocity, rb.linearVelocity.y);

        // 動畫參數設定
        if (anim != null)
        {
            anim.SetFloat("Speed", Mathf.Abs(moveInput.x));
        }

        // 角色轉向
        if (moveInput.x > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput.x < 0) transform.localScale = new Vector3(-1, 1, 1);
    }

    // 碰撞偵測 (記得敵人要設為 Is Trigger 並 Tag 為 Enemy)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && !isDead)
        {
            StartCoroutine(TakeDamage());
        }
    }

    IEnumerator TakeDamage()
    {
        isDead = true;
        Debug.Log("玩家觸碰敵人！執行死亡程序");

        // 1. 播放受傷音效
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }

        // 2. 播放受傷動畫 (從 0f 開始播放確保 100% 執行)
        if (anim != null)
        {
            anim.Play("Player_Hurt", 0, 0f);
        }

        // 3. 物理停滯
        rb.linearVelocity = Vector2.zero;
        rb.simulated = false; // 讓角色定格

        // 4. 等待 1.5 秒讓玩家看到畫面
        yield return new WaitForSeconds(1.5f);

        // 5. 切換場景
        if (!string.IsNullOrEmpty(loseSceneName))
        {
            SceneManager.LoadScene(loseSceneName);
        }
        else
        {
            Debug.LogError("尚未設定 Lose Scene Name！");
        }
    }
}