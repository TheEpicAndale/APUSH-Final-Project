using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float width = ScreenScaler.GetScreenToWorldWidth;
        transform.localScale = Vector3.one * width;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
