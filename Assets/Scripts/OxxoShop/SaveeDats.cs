using System;
using System.Collections.Generic;

[Serializable]
public class SavedObjectData
{
    public string objectName;
    public float posX, posY, posZ;
    public float rotZ; // Para rotación en 2D
}

[Serializable]
public class SaveWrapper
{
    public List<SavedObjectData> objects;
}
