using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BatteryUI : MonoBehaviour
{
    TextMeshProUGUI tmp;

    void Start()
    {
        tmp = gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        Battery.batteryCollectedEvent += UpdateText;
    }

    private void OnDisable()
    {
        Battery.batteryCollectedEvent -= UpdateText;
    }

    void UpdateText(int num)
    {
        tmp.text = num.ToString();
    }
}
