using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class EpicLoading : MonoBehaviour
{
    private TMP_Text textField;
    [SerializeField]private int dotsAmount = 3, delay = 500;

    private string _text;

    private void Awake()
    {
        textField = GetComponent<TMP_Text>();
        _text = textField.text;
    }

    private async void DotsCycle() {
        for (int i = 0; i < dotsAmount; i++) {
            textField.text += ".";
            await Task.Delay(delay);
        }

        textField.text = _text;
        DotsCycle();
    }


}
