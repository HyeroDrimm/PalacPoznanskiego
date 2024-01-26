using UnityEngine;
using UnityEngine.UI;

public class CatapultUI : MonoBehaviour
{
    [SerializeField] private Slider strenghtBar;
    [SerializeField] private Image angle;

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
        angle.fillAmount = 1-anglePercent;
    }
}
