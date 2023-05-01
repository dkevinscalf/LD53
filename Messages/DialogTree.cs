using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogTree : MonoBehaviour
{
    public Sprite[] Characters;
    public OrientationPrefab[] Prefabs;
    public TextAsset DialogFile;
    public float BufferTime;
    private Queue<DialogNode> dialogQueue;
    private GameObject CurrentMessage;

    public void Start()
    {
        var json = DialogFile.text;
        var file = JsonUtility.FromJson<DialogFile>(json);
        dialogQueue = new Queue<DialogNode>(file.Nodes);
    }

    private void Update()
    {
        if (CurrentMessage == null)
            SpawnMessage();
    }

    private void SpawnMessage()
    {
        if (!dialogQueue.Any())
        {
            Destroy(this.gameObject);
            return;
        }
        var node = dialogQueue.Dequeue();
        var prefab = Prefabs.FirstOrDefault(o => o.Orientation == node.Orientation).Prefab;
        var sprite = Characters[node.CharacterId];
        CurrentMessage = Instantiate(prefab);
        CurrentMessage.GetComponent<TextMessageWindow>().Setup(node.Message, sprite);
    }
}

[Serializable]
public class OrientationPrefab
{
    public Orientation Orientation;
    public GameObject Prefab;
}

[Serializable]
public class DialogFile
{
    public DialogNode[] Nodes;
}

[Serializable]
public class DialogNode
{
    public string Message;
    public int CharacterId;
    public Orientation Orientation;
}

[Serializable]
public enum Orientation
{
    BottomLeft,
    BottomRight,
    TopLeft,
    TopRight
}