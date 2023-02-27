using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageTakenFeedBackUI : MonoBehaviour
{
    private TMP_Text m_TextMeshPro;

    private void Awake()
    {
        m_TextMeshPro = GetComponent<TMP_Text>();

    }

    public void setup(float DamageToDisplay)
    {
        m_TextMeshPro.text = DamageToDisplay.ToString();
    }

    void Update()
    {

        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }
}
