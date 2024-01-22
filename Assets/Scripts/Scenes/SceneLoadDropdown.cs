using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadDropdown : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public void LoadScene() {
        SceneManager.LoadScene(dropdown.options[dropdown.value].text);
    }
}
