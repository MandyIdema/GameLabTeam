using Photon.Bolt;
using Photon.Bolt.Matchmaking;
using System;
using System.Collections;
using System.Collections.Generic;
using UdpKit;
using UnityEngine;
using UnityEngine.UI;

public class Menu : GlobalEventListener
{
    public Button createServer;
    public Button createClient;

    // Start is called before the first frame update
    void Start()
    {
        createClient.onClick.AddListener(CreateClient);
        createServer.onClick.AddListener(CreateServer);
    }

    // Update is called once per frame
    void Update()
    {

    }

  
    void CreateServer()
    {
        BoltLauncher.StartServer();
    }
    void CreateClient()
    {
        BoltLauncher.StartClient();
    } 
    
    public override void BoltStartDone()
    {
       if(BoltNetwork.IsServer)

        {
            string matchname = System.Guid.NewGuid().ToString();

            BoltMatchmaking.CreateSession(
                sessionID: matchname,
                sceneToLoad: "SampleScene"
             );
        }
    }

    public override void SessionListUpdated(Map<Guid, UdpSession> sessionList)
    {
        foreach(var session in sessionList)
        {
            UdpSession photonSession = session.Value;

            if(photonSession.Source == UdpSessionSource.Photon)
            {
                BoltMatchmaking.JoinSession(photonSession);
            }
        }
    }

}