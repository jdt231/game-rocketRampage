using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour
{
    public void OpenWebsite()
    {
        Application.OpenURL("https://fromscratchgames.com/");
    }

    public void OpenTwitter()
    {
        Application.OpenURL("https://twitter.com/FromScratchGame");
    }

    public void OpenInstagram()
    {
        Application.OpenURL("https://www.instagram.com/fromscratchgames/");
    }

    public void OpenFacebook()
    {
        Application.OpenURL("https://www.facebook.com/FromScratchGames");
    }

    public void OpenPaypal()
    {
        Application.OpenURL("https://www.paypal.com/donate?hosted_button_id=DDS6NPVZ2B7KE");
    }
}
