using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Item", fileName="Item")]
public class Item : ScriptableObject
{
    public string name;
    public string description;
    public int id;
    
}