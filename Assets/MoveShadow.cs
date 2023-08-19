using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MoveShadow : MonoBehaviour
{
    public float whereToGo;

    public float durationSecond;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveY(whereToGo, durationSecond).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
