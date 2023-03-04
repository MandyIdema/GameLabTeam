using Photon.Bolt;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : EntityBehaviour <IPlayerPositionState>
{
    public override void Attached()
    {
        state.SetTransforms(state.PlayerPosition, transform);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.1f * BoltNetwork.FrameDeltaTime);
        }

       if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.1f * BoltNetwork.FrameDeltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x - 0.1f * BoltNetwork.FrameDeltaTime, transform.position.y);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x + 0.1f * BoltNetwork.FrameDeltaTime, transform.position.y);
        }
    }
}
