using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInstantiation : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> characterList;

    //TODO add resources
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        characterList[PlayerPrefs.GetInt("ChoosenCharacter", 0)].SetActive(true);  
    }
}
