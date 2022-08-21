using System;
using UnityEngine;
using TMPro;
public class Watch : MonoBehaviour
{
    
    [SerializeField] private TMP_Text _timeText;

    private void Update()
    {
        _timeText.text = DateTime.Now.ToString("t");
    }
}
