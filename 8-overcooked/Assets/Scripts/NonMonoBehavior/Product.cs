public enum SimpleProducts
{
    Tomato,
    Cucumber,
    Potato,
    Bread,
    Meat,
    Shit
}

public enum ProductState
{
    Default,
    Cut,
    Fried,
    Boiled,
    Shit
}

[System.Serializable]
public class Product
{
    public SimpleProducts product;
    public ProductState state;

    public bool Equals(Product other)
    {
        return (product == other.product && state == other.state);
    }
}
