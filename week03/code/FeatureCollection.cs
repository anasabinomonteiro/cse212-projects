public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary

    public List<Feature> Features { get; set; }
}

// <summary>
// Represents a unique geografic feature inside the List
// summary>
public class Feature
{
    // Correspondends to the "type" property in the JSON
    public FeatureProperties Properties { get; set; }
}

// <summary>
// Represents the object that contains the details of the each feature
// summary>
public class FeatureProperties
{
    // Correspondends to the key "mag" in the JSON
    public double? Mag { get; set; }

    // Correspondends to the key "place" in the JSON
    public string Place { get; set; }
}