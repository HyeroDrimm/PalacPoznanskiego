using UnityEngine;
using UnityEngine.UI;

public class CatapultUI : MonoBehaviour
{
    [SerializeField] private Slider strenghtBar;

    public void UpdateStrength(float strength)
    {
        strenghtBar.value = strength;
    }

    public void SetVisibility(bool state)
    {
        gameObject.SetActive(state);
    }
}
