using UnityEngine;
using DG.Tweening;

public class TWTrackingWave : MonoBehaviour
{
    public virtual void TW_TrackingWaveOn()
    {
        this.transform.GetComponent<RectTransform>().DOAnchorPosY(-75f, 1);
    }

    public virtual void TW_TrackingWaveOff()
    {
        this.transform.GetComponent<RectTransform>().DOAnchorPosY(120f, 1);
    }
}
