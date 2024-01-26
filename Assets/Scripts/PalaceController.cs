using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using JetBrains.Annotations;

public class PalaceController: MonoBehaviour
{
    [SerializeField]
    private List<GameObject> MorrisItems;
    [SerializeField]
    private GameObject MoneyPref;
    [SerializeField]
    private GameObject KeysPref;
    public static PalaceController palaceController { get; private set; }
    private void Awake() 
    {
        SetUpMorrisItems();
        SetupSingleton();
        Debug.Log("Palac jest obsługiwany moj panie!"); 
    }

    public void UpdateStatus(string _palaceStates)
    {
        Debug.Log(_palaceStates);
        switch(_palaceStates)
        {
            case "Money":
                MorrisItems.Single(go => go.name == "Money").SetActive(false);
                MorrisItems.Single(go => go.name == "Keys").SetActive(true);
                break;
            case "Keys":
                MorrisItems.Single(go => go.name == "Money").SetActive(true);
                MorrisItems.Single(go => go.name == "Keys").SetActive(false);
                break;
            default:
                Debug.Log("this state doesn't exist");
                break;
        }
    }

    private void SetUpMorrisItems()
    {
        foreach(GameObject item in MorrisItems)
        {
            item.SetActive(false);
        }
        MorrisItems.Single(go => go.name == "Money").SetActive(true);
    }

    private void SetupSingleton()
    {
        if (palaceController != null && palaceController != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            palaceController = this; 
        }
    }


}
