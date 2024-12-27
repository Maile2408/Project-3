using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject projectilePrefab;

    public void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, launchPoint.transform.position, projectilePrefab.transform.rotation);
        Vector3 origScale = projectile.transform.localScale;

        // Lật hướng và chuyển động của đạn dựa trên hướng mà nhân vật đang hướng tới tại thời điểm phóng
        projectile.transform.localScale = new Vector3(
            origScale.x * transform.localScale.x > 0 ? 1 : -1,
            origScale.y * transform.localScale.x > 0 ? 1 : -1,
            origScale.z
        );
    }
}
