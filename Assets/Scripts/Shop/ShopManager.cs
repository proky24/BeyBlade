using System.Collections.Generic;
using UnityEngine;
public class ShopManager : MonoBehaviour
{
    Dictionary<string, List<BeybladePart>> parts;
    public Dictionary<string, List<BeybladePart>> Parts { get { return parts; } }
    private void Start()
    {

    }
    public List<BeybladePart> GetBeybladeParts(string key)
    {
        return parts[key];
    }
}