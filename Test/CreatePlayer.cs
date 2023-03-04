using Photon.Bolt;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[BoltGlobalBehaviour]
public class CreatePlayer : GlobalEventListener
{
    void Start()
    {
        BoltNetwork.Instantiate(BoltPrefabs.Player, new Vector2(0, 0), transform.rotation);
    }

    public override void SceneLoadLocalDone(string scene)
    {
        BoltNetwork.Instantiate(BoltPrefabs.Player, new Vector2(0, 0), transform.rotation);
    }

    void Update()
    {

    }
}