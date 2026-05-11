using UnityEngine;
using Unity.Netcode.Components;
using Unity.Netcode;

public class CameraNetcode : NetworkBehaviour
{
    public GameObject camHolder;
    //void Start()
    //{
        //var netObj = GetComponentInParent<NetworkObject>();

        //if (netObj != null && !netObj.IsOwner)
        //{
            //gameObject.SetActive(false);
            //return;
        //}
    //}
    public override void OnNetworkSpawn()
    {
        if (!IsOwner)
        {
            camHolder.SetActive(IsOwner);
            return;
        }
    }
}
