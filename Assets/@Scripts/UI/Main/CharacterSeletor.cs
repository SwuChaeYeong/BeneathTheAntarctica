using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSeletor : MonoBehaviour
{
    
    public void Selected(int num)
    {
        CharacterManager.Instance.SelectCharacter(num);
    }
}
