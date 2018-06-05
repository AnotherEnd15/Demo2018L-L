using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitEdge : MonoBehaviour {

    private Resolution screenResolution;//屏幕分辨率
    private Transform mainCam;
    private BoxCollider2D camBox;
    private Vector2 mapEdge;
    [Range(0, 1)]
    public float moveRatio = 0.1f;//屏幕中触发移动的系数,即鼠标在屏幕边缘处，占屏幕n%处的空间内，会触发移动
    public float moveSpeed = 1f;
    private void Start()
    {
        screenResolution = Screen.currentResolution;
        mainCam = Camera.main.transform;
        camBox = mainCam.GetComponent<BoxCollider2D>();
        RectTransform map = GameObject.FindGameObjectWithTag("MapBg").transform.GetComponent<RectTransform>();

        mapEdge = new Vector2(map.localPosition.x, map.localPosition.x + map.rect.width);
    }
    void Update()
    {
        float x = Input.mousePosition.x;
        if (x <= screenResolution.width * moveRatio)
            Move(mainCam, false);
        else
            Move(mainCam, true);
    }
    void Move(Transform trans,bool right)
    {
        Vector3 dir = right ? Vector3.right : Vector3.left;
        float moveDistance = dir.x * moveSpeed * Time.deltaTime;
        float camBoxHalfL = dir.x * (camBox.size.x / 2);
        float aim = trans.transform.localPosition.x + camBoxHalfL + moveDistance ;
        aim = Mathf.Clamp(aim, mapEdge.x, mapEdge.y);
        trans.localPosition = new Vector3(aim- camBoxHalfL, trans.localPosition.y, trans.localPosition.z);
    }
}
