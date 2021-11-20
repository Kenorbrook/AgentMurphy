using UnityEngine;

[CreateAssetMenu(menuName ="Save/Key")]
public class SaveKey : ScriptableObject
{
    [SerializeField] private string _key;

    public string Key => _key;
}
