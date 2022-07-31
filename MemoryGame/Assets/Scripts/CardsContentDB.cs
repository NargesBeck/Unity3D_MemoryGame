using UnityEngine;
using System.Collections.Generic;

public class CardsContentDB : MonoBehaviour
{
    public Sprite spritesheet;
    [SerializeField]
    private List<Sprite> _sprites = new List<Sprite>();

    public Sprite GetSpriteByIndex(int index)
    {
        index = Mathf.Clamp(index, 0, _sprites.Count - 1);
        return _sprites[index];
    }
}