using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class PalaceController: MonoBehaviour
{
    [SerializeField]
    private List<GameObject> MorrisItemsList;
    [SerializeField]
    private List<GameObject> MorrisItemsImagesList;
  

    [SerializeField]
    private GameObject EndScreen;

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

    public void ShowEndScreen()
    {
        EndScreen.SetActive(true);
        StartCoroutine(ShowEndScreenCorutine());
    }

    public IEnumerator ShowEndScreenCorutine()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadFinalScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
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
