using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    Dictionary<System.Type, UICanvas> canvasActives = new Dictionary<System.Type, UICanvas>();
    Dictionary<System.Type, UICanvas> canvasPrefabs = new Dictionary<System.Type, UICanvas>();
    [SerializeField] Transform parent;

    private void Awake()
    {
        // Load UI prefab từ Resources
        UICanvas[] prefabs = Resources.LoadAll<UICanvas>("UI/");

        for(int i = 0; i < prefabs.Length; i++)
        {
            canvasPrefabs.Add(prefabs[i].GetType(), prefabs[i]);
        }
    }
    // Mở Canvas
    public T OpenUI<T>() where T : UICanvas
    {
        T canvas = GetUI<T>();

        canvas.Setup();
        canvas.Open();

        return canvas;
    }

    // Đóng Canvas sau time (s)
    public void CloseUI<T>(float time) where T : UICanvas
    {
        if(IsOpened<T>())
        {
            canvasActives[typeof(T)].Close(time);
        }
    }

    // Đóng Canvas trực tiếp
    public void CloseUIDirectly<T>() where T : UICanvas
    {
        if(IsOpened<T>())
        {
            canvasActives[typeof(T)].CloseDirectly();
        }
    }

    //Kiểm tra Canvas đã được tạo chưa
    public bool IsUILoaded<T>() where T : UICanvas
    {
        return canvasActives.ContainsKey(typeof(T)) && canvasActives[typeof(T)] != null;
    }

    //Kiểm tra Canvas đã được active hay chưa
    public bool IsOpened<T>() where T : UICanvas
    {
        return IsUILoaded<T>() && canvasActives[typeof(T)].gameObject.activeSelf;
    }

    //Lấy Active Canvas
    public T GetUI<T>() where T : UICanvas
    {
        if(!IsUILoaded<T>())
        {
            T prefab = GetUIPrefab<T>();
            T canvas = Instantiate(prefab, parent);
            canvasActives[typeof(T)] = canvas;
        }

        return canvasActives[typeof(T)] as T;
    }

    // Get Prefab
    private T GetUIPrefab<T>() where T : UICanvas
    {
        return canvasPrefabs[typeof(T)] as T;
    }

    //Đóng tất cả
    public void CloseAll()
    {
        foreach(var canvas in canvasActives)
        {
            if(canvas.Value != null && canvas.Value.gameObject.activeSelf)
            {
                canvas.Value.Close(0);
            }
        }
    }
}
