using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{


    Slider _3dLifebar;
    public Slider _2dLifebar;

    Stats stats;

    private void Start()
    {

        stats = GetComponentInParent<Stats>();
        _3dLifebar = GetComponent<Slider>();

        _3dLifebar.maxValue = stats.MaxHealth;
        
        if (_2dLifebar != null)
        {
            _2dLifebar.maxValue = _3dLifebar.maxValue;
        }
    }

    private void Update()
    {
        _3dLifebar.value = stats.Health;

        if (_2dLifebar != null)
        {

            _2dLifebar.value = _3dLifebar.value;
        }

        if (stats.Health <= 0)
        {

            if (_2dLifebar != null)
            {
                if (stats.Health <= 0)
                {
                    Destroy(_2dLifebar.gameObject);
                }
            }

            Destroy(_3dLifebar.gameObject);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
    }
}
