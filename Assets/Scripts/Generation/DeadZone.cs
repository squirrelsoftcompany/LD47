using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DeadZone : MonoBehaviour
{
    public List<string> tagsToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        CheckAll();
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

    void CheckAll()
    {
        for (int i = 0; i < tagsToDestroy.Count; i++)
        {
            string currentTag = tagsToDestroy[i];

            Debug.Assert(Check(currentTag, UnityEditorInternal.InternalEditorUtility.tags), "DeadZone: Can't find tag " + currentTag);
        }
    }

    private void OnDrawGizmos()
    {
        Collider myCollider = GetComponent<Collider>();
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawCube(myCollider.bounds.center, myCollider.bounds.size);
    }

    private void OnTriggerStay(Collider other)
    {
        if (! Check(other.tag, tagsToDestroy))
            return;

        Destroy(other.transform.parent.gameObject);
    }
}
