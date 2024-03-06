using System.Collections.Generic;

public enum ContainerType
{
    Pot,
    Pan,
    Plate
}

[System.Serializable]
public class Container
{
    public ContainerType container;
    public List<Product> products = new List<Product>();
}