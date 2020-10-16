using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using TMPro;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class GhostZone : MonoBehaviour
{
    public List<string> tagsToGhost;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        CheckAll();
#endif // UNITY_EDITOR
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool Check(string currentTag, IEnumerable<string> enumerable)
    {
        bool found = false;
        int j = 0;
        while (!found && j < enumerable.Count())
        {
            if (enumerable.ElementAt(j).CompareTo(currentTag) == 0)
            {
                found = true;
            }
            j++;
        }

        return found;
    }

#if UNITY_EDITOR
    void CheckAll()
    {
        for (int i = 0; i < tagsToGhost.Count; i++)
        {
            string currentTag = tagsToGhost[i];

            Debug.Assert(Check(currentTag, UnityEditorInternal.InternalEditorUtility.tags), "DeadZone: Can't find tag " + currentTag);
        }
    }
#endif // UNITY_EDITOR

    private void OnDrawGizmos()
    {
        Collider myCollider = GetComponent<Collider>();
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawCube(myCollider.bounds.center, myCollider.bounds.size);
    }

    private void OnTriggerStay(Collider other)
    {
        if (! Check(other.tag, tagsToGhost))
            return;

        foreach (var elem in other.transform.parent.GetComponentsInChildren<Renderer>())
        {
            elem.material.color = new Color(1, 1, 1, 0.5f);
        }
    }
}
