using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Mover : MonoBehaviour
{
    public float endPosition;

    public float timeSeconds;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveX(endPosition, timeSeconds).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
