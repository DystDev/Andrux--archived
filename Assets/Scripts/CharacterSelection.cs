using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{

    private GameObject[] characterList;
    private int index;
    [SerializeField] Avatar derekAvatar;
    [SerializeField] Avatar alecAvatar;
    [SerializeField] Avatar charlieAvatar;
    [SerializeField] Avatar tillyAvatar;
    private void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");
        characterList = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }
        foreach (GameObject go in characterList)
        {
            go.SetActive(false);
        }
        if (characterList[index])
        {
            characterList[index].SetActive(true);
        }
        if (SceneManager.GetActiveScene().name == "Sandbox") {

            if (index == 0)
            {
                GetComponent<Animator>().avatar = derekAvatar;
            }

            if (index == 1)
            {
                GetComponent<Animator>().avatar = alecAvatar;
            }

            if (index == 2)
            {
                GetComponent<Animator>().avatar = charlieAvatar;
            }

            if (index == 3)
            {
                GetComponent<Animator>().avatar = tillyAvatar;
            }


        }
    

    }


    public void ToggleLeft()
    {
        characterList[index].SetActive(false);
        index--;
        if (index < 0) index = characterList.Length - 1;
        characterList[index].SetActive(true);
    }
    public void ToggleRight()
    {
        characterList[index].SetActive(false);
        index++;
        if (index == characterList.Length) index = 0;
        characterList[index].SetActive(true);
    }
    public void ConfirmButton()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene(1);
    }

}
