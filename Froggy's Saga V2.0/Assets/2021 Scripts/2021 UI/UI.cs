using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UI : MonoBehaviour
{
    public abstract void CharacterChange(GameObject player);
    public abstract void UpdateInfo(float value);

}
