using UnityEngine;
using UnityEngine.UI;

public class CatapultUI : MonoBehaviour
{
    [SerializeField] private Slider strenghtBar;
    [SerializeField] private RectTransform arrowPixot;

    public void UpdateStrength(float strength)
    {
        strenghtBar.value = strength;
    }

    public void SetVisibility(bool state)
    {
        gameObject.SetActive(state);
    }

    public void UpdateAngle(float anglePercent)
    {
        arrowPixot.rotation = Quaternion.Euler(new Vector3(0, 0, (1 - anglePercent) * -90));
    }
}
