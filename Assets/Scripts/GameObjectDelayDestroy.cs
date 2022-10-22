using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDelayDestroy : MonoBehaviour
{
    public float destroyTimer = 1.5f;
    void Update()
    {
        Destroy(gameObject, destroyTimer);
    }
}
