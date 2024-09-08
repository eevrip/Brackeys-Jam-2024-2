using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
public class TextWobble : MonoBehaviour
{
    private Sprite spr;
    private Image img;
    Vector2[] ver;
    private void Start()
    {
        img= GetComponent<Image>();
        spr = img.sprite;
        ver = spr.vertices;
    }
    private void Update()
    {
        ver = spr.vertices;
        Vector2 sizePix = (spr.rect.size * spr.pixelsPerUnit) + spr.pivot;
        for (int i = 0; i < ver.Length; i++)
        {
            Vector2 offset = Wobble(Time.time + i);
            /*  ver[i].x = Mathf.Clamp(
              (spr.vertices[i].x - spr.bounds.center.x -
              (spr.textureRectOffset.x / spr.texture.width) + spr.bounds.extents.x) /
              (2.0f * spr.bounds.extents.x) * spr.rect.width,
              0.0f, spr.rect.width);

              ver[i].y = Mathf.Clamp(
              (spr.vertices[i].y - spr.bounds.center.y -
              (spr.textureRectOffset.y / spr.texture.height) + spr.bounds.extents.y) /
              (2.0f * spr.bounds.extents.y) * spr.rect.height,
                  0.0f, spr.rect.height);
            */
            ver[i] = (ver[i] * spr.pixelsPerUnit) + spr.pivot;

            Debug.Log(ver[i] + " " + spr.vertices[i]);
            if (ver[i].x < spr.rect.size.x + 5f)// - offset.x)
            {
                ver[i].x = ver[i].x - 5f;//+ offset.x;
            }
            
            if (ver[i].y < spr.rect.size.y - 5f) // - offset.y)
            {
                ver[i].y = ver[i].y + 5f;//offset.y;
            }
           
            //ver[i] = (ver[i] * spr.pixelsPerUnit) + spr.pivot;
           
            
        }
        spr.OverrideGeometry(ver, spr.triangles);
    }
    public Vector2 Wobble(float time)
    {
        return new Vector2(Mathf.Sin(time * 1f), Mathf.Cos(time * 1f));
    }
}
