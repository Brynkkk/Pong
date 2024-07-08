using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage RawImage;
    [SerializeField] private float x, y;
    
    void Update()
    {
        RawImage.uvRect = new Rect(RawImage.uvRect.position + new Vector2(x, y) * Time.deltaTime, RawImage.uvRect.size);
    }
}
