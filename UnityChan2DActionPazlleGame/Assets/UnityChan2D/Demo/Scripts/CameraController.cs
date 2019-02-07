using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public Transform target;
    public Transform stopPosition;

    [SceneName]
    public string nextLevel;

    private Camera m_camera;

    void Awake()
    {
        m_camera = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        var right = m_camera.ViewportToWorldPoint(Vector2.right);
        var center = m_camera.ViewportToWorldPoint(Vector2.one * 0.5f);

        if (center.x < target.position.x)
        {
            var pos = m_camera.transform.position;

            if (Math.Abs(pos.x - target.position.x) >= 0.0000001f)
            {
                m_camera.transform.position = new Vector3(target.position.x, pos.y, pos.z);
            }
        }

        //カメラがストッパーの位置まで来たとき
        if (stopPosition.position.x - right.x < 0)
        {
            //クリアの処理を行うメソッドを呼び出す
            StartCoroutine(INTERNAL_Clear());
            //カメラの動きを止める
            enabled = false;
        }
    }

    private IEnumerator INTERNAL_Clear()
    {
        var player = GameObject.FindGameObjectWithTag("Player");

        if (player)
        {
            player.SendMessage("Clear", SendMessageOptions.DontRequireReceiver);
        }

        //三秒待つ
        yield return new WaitForSeconds(3);

        Application.LoadLevel(nextLevel);
    }
}
