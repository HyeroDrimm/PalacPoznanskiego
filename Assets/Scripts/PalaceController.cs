using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using JetBrains.Annotations;

public class PalaceController: MonoBehaviour
{
    [SerializeField]
    private List<GameObject> MorrisItemsList;

    public static PalaceController palaceController { get; private set; }
    private void Awake() 
    {
        SetupPalaceController();
        SetUpMorrisItemsList();
        Debug.Log("Palac jest obsługiwany moj panie!"); 
    }

    public void UpdateStatus(string _palaceStates)
    {
        Debug.Log(_palaceStates);
        switch(_palaceStates)
        {
            case "Money":
                MorrisItemsList.Single(go => go.name == "Money").SetActive(false);
                MorrisItemsList.Single(go => go.name == "Keys").SetActive(true);
                break;
            case "Keys":
                MorrisItemsList.Single(go => go.name == "Money").SetActive(true);
                MorrisItemsList.Single(go => go.name == "Keys").SetActive(false);
                break;
            default:
                Debug.Log("this state doesn't exist");
                break;
        }
    }

    private void SetUpMorrisItemsList()
    {
        foreach(GameObject item in MorrisItemsList)
        {
            item.SetActive(false);
        }
        MorrisItemsList.Single(go => go.name == "Money").SetActive(true);
    }

    private void SetupPalaceController()
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
