using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    private readonly NetworkVariable<Vector3> _netpos = new(writePerm: NetworkVariableWritePermission.Owner);
    private readonly NetworkVariable<Quaternion> _netRot = new(writePerm: NetworkVariableWritePermission.Owner);

    void Update()
    {
        if (IsOwner)
        {
            _netpos.Value = transform.position;
            _netRot.Value = transform.rotation;
        }
        else
        {
            transform.position = _netpos.Value;
            transform.rotation = _netRot.Value;
        }
    }
}
