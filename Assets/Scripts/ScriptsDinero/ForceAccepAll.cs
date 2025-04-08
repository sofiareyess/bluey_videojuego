using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class ForceAccepAll : CertificateHandler
{
    protected override bool ValidateCertificate(byte[] certificateD)
    {
        return true;
    }
    
}
