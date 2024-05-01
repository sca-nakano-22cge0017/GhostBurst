using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �Q�l�T�C�ghttps://teratail.com/questions/266045

/// <summary>
/// ���_�ړ�
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
        //! Y�������̉�]�͏����ݒ肵����ŉ�]�ł��������悢����
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
            // ��ʍ����ł̓��͂Ȃ牺�̏������΂�
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
