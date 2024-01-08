using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


public class LoadWeapons : MonoBehaviour
{
    [SerializeField]private string folder = "Weapons";
    private TMP_Dropdown dropdown;

    private void Awake() {
        dropdown = GetComponent<TMP_Dropdown>();

        dropdown.ClearOptions();
        dropdown.AddOptions(Resources.LoadAll(folder).Select(x => x.name).ToList());
    }
}
