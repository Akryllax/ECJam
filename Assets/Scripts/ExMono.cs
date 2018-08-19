using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExMono : MonoBehaviour {

    private static Rect screenBorders;
    public static bool IsPaused = false;

    public static void ExitGame()
    {
        Application.Quit();
    }

    public static Rect GetScreenRect()
    {
        if (screenBorders == null || screenBorders == Rect.zero)
        {
            Rect tempRect = new Rect();

            var topLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 10));
            var topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 10));
            var bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 10));
            var bottomRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 10));

            float width = topRight.x - topLeft.x;
            float height = topLeft.z - bottomLeft.z;

            tempRect.Set(-width / 2f, -height / 2f, width, height);

            screenBorders = tempRect;
        }

        return screenBorders;
    }
}
