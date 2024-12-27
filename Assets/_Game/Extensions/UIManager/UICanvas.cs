using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoBehaviour
{
    [SerializeField] bool isDestroyOnClose = false;
    
    private void Awake()
    {
        // Xử lý tai thỏ
        RectTransform rect = GetComponent<RectTransform>();
        float ratio = (float)Screen.width / (float)Screen.height;
        if(ratio > 2.1f)
        {
            Vector2 leftBottom = rect.offsetMin;
            Vector2 rightTop = rect.offsetMax;

            leftBottom.y = 0f;
            rightTop.y = -100f;

            rect.offsetMin = leftBottom;
            rect.offsetMax = rightTop;
        }
    }
    // Gọi trước khi canvas được active
    public virtual void Setup()
    {

    }

    // Gọi sau khi canvas được active
    public virtual void Open()
    {
        gameObject.SetActive(true);
    }

    // Tắt Canvas sau time (s)
    public virtual void Close(float time)
    {
        Invoke(nameof(CloseDirectly), time);
    }

    // Tắt Canvas trực tiếp
    public virtual void CloseDirectly()
    {
        if(isDestroyOnClose)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
