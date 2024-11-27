using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Hiệu ứng thị sai giúp background chuyển động đa chiều
public class ParallaxEffect : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;
    Vector2 startingPosition; //Vị trí bắt đầu parallax game object
    float startingZ; //giá trị bắt đầu của Z
    // Khoảng Cam di chuyển từ khi bắt đầu
    Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startingPosition;
    float zDistanceFromTarget => transform.position.z - followTarget.transform.position.z;
    float clippingPlane => (cam.transform.position.z + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));
    /* Đối tượng càng ở xa người chơi thì đối tượng ParallaxEffect sẽ di chuyển càng nhanh
    Kéo giá trị Z của nó đến gần mục tiêu hơn để khiến nó di chuyển chậm hơn */
    float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //Khi mục tiêu di chuyển, di chuyển đối tượng thị sai với cùng khoảng cách * hệ số
        Vector2 newPosition = startingPosition + camMoveSinceStart * parallaxFactor;
        //Thay đổi X/Y, Z giữ nguyên
        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }
}
