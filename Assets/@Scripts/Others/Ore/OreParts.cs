using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreParts
{
    public string name;
    public int quantity;
    public Sprite img;

    public OreParts(string name, int quantity, Sprite img)
    {
        this.name = name;
        this.quantity = quantity;
        this.img = img;
    }
}
