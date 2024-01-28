using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using JetBrains.Annotations;

public class PalaceController: MonoBehaviour
{
    [SerializeField]
    private List<GameObject> MorrisItemsList;
    [SerializeField]
    private List<GameObject> MorrisItemsImagesList;

    public static PalaceController palaceController { get; private set; }
    private void Awake() 
    {
        SetupPalaceController();
        SetUpMorrisItemsList();
        Debug.Log("Palac jest obsługiwany moj panie!"); 
        Application.targetFrameRate=60;
    }

    public void UpdateStatus(string _palaceStates)
    {
        Debug.Log(_palaceStates);
        switch(_palaceStates)
        {
            case "Money":
                MorrisItemsList.Single(go => go.name == "Money").SetActive(false);
                MorrisItemsImagesList.Single(go => go.name == "MoneyPanel").SetActive(true);
                break;
            case "Keys":
                MorrisItemsList.Single(go => go.name == "Keys").SetActive(false);
                MorrisItemsImagesList.Single(go => go.name == "KeysPanel").SetActive(true);
                break;
            case "MommyKiss":
                MorrisItemsList.Single(go => go.name == "MommyKiss").SetActive(false);
                MorrisItemsImagesList.Single(go => go.name == "MommyKissPanel").SetActive(true);
                break;
            case "EuDeToilette":
                MorrisItemsList.Single(go => go.name == "EuDeToilette").SetActive(false);
                MorrisItemsImagesList.Single(go => go.name == "EuDeToilettePanel").SetActive(true);
                break;
            case "PocketWatch":
                MorrisItemsList.Single(go => go.name == "PocketWatch").SetActive(false);
                MorrisItemsImagesList.Single(go => go.name == "PocketWatchPanel").SetActive(true);
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
