using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode.Components;

[DisallowMultipleComponent]
// This is a custom NetworkAnimator that overrides the default NetworkAnimator to make it
// client authoritative
// Attaching this script to the character will make it so that the character's animations are
// controlled by the client that owns it, rather than the server
public class Scene1_Script4 : NetworkAnimator
{
    protected override bool OnIsServerAuthoritative()
    {
        return false;
    }
}

