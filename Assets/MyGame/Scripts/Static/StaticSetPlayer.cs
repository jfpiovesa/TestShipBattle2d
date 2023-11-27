using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class StaticSetPlayer
{
    public  static Action<CharacterBase> actionCharacter;

    public static void SittingCharactersActive(CharacterBase character)
    {
        actionCharacter?.Invoke(character);
    }
}
