using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "Trap")]
public class TrapSO : ScriptableObject {

    public Sprite trapUISprite;
    public Sprite trapMouseImage;
    public GameObject trapPrefab;
    public AnimatorController animatorController;

}
