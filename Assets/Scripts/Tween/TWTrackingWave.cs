using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TWTrackingWave : MonoBehaviour
{
    public virtual void TW_TrackingWaveOn()
    {
        this.transform.GetComponent<RectTransform>().DOAnchorPosY(445f, 1);
    }

    public virtual void TW_TrackingWaveOff()
    {
        this.transform.GetComponent<RectTransform>().DOAnchorPosY(650f, 1);
    }
}
