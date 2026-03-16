using UnityEngine;

public class OpenKISIM : MonoBehaviour
{
    [Header("Website of the system")]
    public string url = "http://ec2-3-70-245-125.eu-central-1.compute.amazonaws.com/";

    private bool isPlayerNearby = false;

    // 当小人进入电脑前的感应区（触发器）
    void OnTriggerEnter(Collider other)
    {
        // 只要碰撞体属于玩家
        if (other.CompareTag("Player") || other.name.Contains("Character"))
        {
            isPlayerNearby = true;
            Debug.Log("Get close to the computer:Now can open the website by clicking the screen");
        }
    }

    // 当小人离开感应区
    void OnTriggerExit(Collider other)
    {
        isPlayerNearby = false;
        Debug.Log("Leave the computer");
    }

    void Update()
    {
        // 如果人在附近 并且 按下了鼠标左键
        if (isPlayerNearby && Input.GetMouseButtonDown(0))
        {
            // 从相机发射射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // 如果鼠标点中的正是挂载此脚本的电脑屏幕
                if (hit.transform == this.transform)
                {
                    Debug.Log("Opening the page " + url);
                    Application.OpenURL(url);
                }
            }
        }
    }
}