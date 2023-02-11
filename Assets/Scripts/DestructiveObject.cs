using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructiveObject : MonoBehaviour
{

    private Stats stats;
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        isDie();
    }

    private void isDie()
    {

        if (stats.life <= 0) {
            Destroy(gameObject);
        }
    }
}
