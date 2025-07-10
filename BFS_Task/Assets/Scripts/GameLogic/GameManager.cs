using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<LogicSystem> logicSystems;

    private void Start()
    {
        foreach (var item in logicSystems)
        {
            item.Init();
        }
    }

    private void FixedUpdate()
    {
        foreach (var item in logicSystems)
        {
            item.FixedTick();
        }
    }
}
