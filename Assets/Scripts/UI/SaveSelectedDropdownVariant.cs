using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveSelectedDropdownVariant : MonoBehaviour
{
    [SerializeField]private TMP_Dropdown dropdown;
    [SerializeField]private string propertyName;

    public void OnDestroy() {
        PlayerPrefs.SetString(propertyName, dropdown.options[dropdown.value].text);
    }
}
