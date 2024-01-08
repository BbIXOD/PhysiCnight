using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using System.Linq;

[Serializable]
public class RemovingComponent
{
    public MonoBehaviour component;
    public ViewDelStatus status;
}


//this component will remove objects on some views depending on their status
[RequireComponent(typeof(PhotonView))]
public class ComponentViewRemover : MonoBehaviour
{
    private PhotonView _view;

    [SerializeField]private RemovingComponent[] components;

    private void Awake()
    {
        _view = GetComponent<PhotonView>();
    }

    private void Start()
    {
        RemoveComponents();
    }

    public void RemoveComponents()
    {
       _view.RPC(nameof(RemoveRPC), RpcTarget.All);
    }

    [PunRPC]
    protected void RemoveRPC()
    {
        
        foreach ( var component in components.Where(x => !ComponentNeedenceCheck(x.status)))
        {
            component.component.enabled = false;
        }
    }

    //So we turn on only components for which this function returns false
    private bool ComponentNeedenceCheck(ViewDelStatus status)
    {
        return (PhotonNetwork.IsMasterClient && status is ViewDelStatus.MineAndMaster or ViewDelStatus.OnlyMaster)
            || (_view.IsMine && status is ViewDelStatus.MineAndMaster or ViewDelStatus.OnlyMine);
    }
}
