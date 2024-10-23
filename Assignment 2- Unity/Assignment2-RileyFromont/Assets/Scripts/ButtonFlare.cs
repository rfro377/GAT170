using UnityEngine;
using DG.Tweening;

public class ButtonFlare : MonoBehaviour
{
    public void ButtonOut(Transform button)
    {
        button.DOScale(Vector3.one * 1.25f, 0.5f).SetEase(Ease.OutBounce);
    }

    public void ButtonIn(Transform button)
    {
        button.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBounce);
    }
}