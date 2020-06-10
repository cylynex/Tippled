﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSafeArea : MonoBehaviour {

    RectTransform Panel;
    Rect LastSafeArea = new Rect(0, 0, 0, 0);

    void Awake() {
        Panel = GetComponent<RectTransform>();
        Refresh();
        //print("Safe area: " + Screen.safeArea);
    }

    void Update() {
        Refresh();
    }

    void Refresh() {
        Rect safeArea = GetSafeArea();

        if (safeArea != LastSafeArea)
            ApplySafeArea(safeArea);
    }

    Rect GetSafeArea() {
        return Screen.safeArea;
    }

    void ApplySafeArea(Rect r) {
        LastSafeArea = r;

        Vector2 anchorMin = r.position;
        Vector2 anchorMax = r.position + r.size;
        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;
        Panel.anchorMin = anchorMin;
        Panel.anchorMax = anchorMax;
    }

}
