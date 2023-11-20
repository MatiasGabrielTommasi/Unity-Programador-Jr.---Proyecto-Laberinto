using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevitationEffect : MonoBehaviour
{
    bool goUp = true;
    void Update()
    {
        if (goUp)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 0.3f);
            goUp = transform.position.y < 1.1;
        }
        else
        {
            transform.Translate(Vector3.up * -Time.deltaTime * 0.3f);
            goUp = transform.position.y < 0.8;
        }
    }
}
