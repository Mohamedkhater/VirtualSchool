using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    private Behaviour[] componentsToDisable;
    Camera scenecamera;
     void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
            
        }
        else
        {

            scenecamera = Camera.main;
            scenecamera.gameObject.SetActive(false);

        }


        
    }
    private void OnDisable()
    {
        if (scenecamera != null)
        {
            scenecamera.gameObject.SetActive(true);
        }
    }
}
