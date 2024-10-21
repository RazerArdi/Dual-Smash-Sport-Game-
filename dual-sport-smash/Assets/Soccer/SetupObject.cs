using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SetupObject : MonoBehaviour
{
    public static SetupObject Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
