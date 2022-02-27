using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonateScript : MonoBehaviour
{

    public string Url;
    public void Open()
    {
        Application.OpenURL(Url);
    }
}
