using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 参考サイトhttps://teratail.com/questions/266045

/// <summary>
/// 視点移動
/// </summary>
public class ViewPointMove : MonoBehaviour
{
    [SerializeField] float sensitivity;

    void Start()
    {
        
    }

    void Update()
    {

#if UNITY_ANDROID
        ViewPointRotate_ForAndroid();

#elif UNITY_EDITOR
        ViewPointRotate_ForPC();
#endif
    }

    void ViewPointRotate_ForPC()
    {
        //! Y軸方向の回転は上限を設定した上で回転できた方がよいかも
        Vector3 angle = new Vector3(0, Input.GetAxis("Mouse X") * sensitivity, 0);

        transform.Rotate(angle);
    }

    private float XAxis;
    private float YAxis;

    private Touch initTouch = new Touch();

    void ViewPointRotate_ForAndroid()
    {
        foreach(Touch touch in Input.touches)
        {
            // 画面左側での入力なら下の処理を飛ばす
            if(touch.position.x < Screen.width / 2.0) continue;

            if(touch.phase == TouchPhase.Began)
            {
                initTouch = touch;
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                XAxis = initTouch.position.x - touch.position.x;
                YAxis = initTouch.position.y - touch.position.y;

                float angleX = XAxis * sensitivity * Time.deltaTime;
                float angleY = YAxis * sensitivity * Time.deltaTime;
                Vector3 angle = new Vector3(0, angleX, 0);

                transform.Rotate(angle);
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                initTouch = new Touch();
            }
        }
    }
}
