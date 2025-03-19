using Greenday;
using System.Drawing;

internal class Program
{
    static List<String> clothesTypes = new List<string> { "pants", "t-shirt", "shoes" };
    static List<String> clothesBrands = new List<string> { "jackandjones", "h&m" };
    static Dictionary<String, double> c0Savings = new Dictionary<String, double> 
    {
        {"denim", 20.0 },
        {"nylon", 10.0 },
    };
    static List<ClothesItem> clothes = new List<ClothesItem>();

    private static void Main(string[] args)
    {
        // Continously add items to the list
        while (true)
        {
            Console.WriteLine("Add new item");
            if (AddClothesItem())
            {
                Console.WriteLine("Added clothes item");
            } else {
                Console.WriteLine("Failed to add clothes item");
            }
            Console.WriteLine("");
        }
    }

    static private string GetUserString(String prompt)
    {
        String? str = null;

        while (str == null)
        {
            Console.Write(prompt);
            str = Console.ReadLine();
        }

        return str.ToLower();
    }

    private static bool AddClothesItem()
    {
        // Get and verify type
        String type = GetUserString("Type: ");
        if (!clothesTypes.Contains(type))
        {
            Console.WriteLine("Unknown type");
            return false;
        }
        // Get and verify material
        string material = GetUserString("Material: ");
        if (!c0Savings.ContainsKey(material))
        {
            Console.WriteLine("Unknown material");
            return false;
        }
        // Get size
        int size = GetSize();
        // Get condition
        int condition = GetCondition();
        // Get brand and verify
        string brand = GetUserString("Brand: ");
        if (!clothesBrands.Contains(brand))
        {
            Console.WriteLine("Unknown brand");
            return false;
        }

        try
        {
            clothes.Add(new ClothesItem
            {
                id = clothes.Count,
                type = type,
                size = size,
                brand = brand,
                condition = condition,
                material = material,
                c02Savings = c0Savings[material],
                sold = false,
                donationTime = DateTime.Now,
            });
        } catch (Exception e)
        {
            Console.WriteLine("Failed to add clothes items");
            Console.WriteLine(e.ToString());
            return false;
        }
        return true;
    }

    static int GetSize()
    {
        String? str = null;
        int value;

        while (true)
        {
            Console.Write("Size: ");
            str = Console.ReadLine();

            if (int.TryParse(str, out value))
            {
                return value;
            }
        }
    }

    static int GetCondition()
    {
        String? str = null;
        int value;
        
        // Retry until successful
        while (true)
        {
            Console.Write("Condition: ");
            str = Console.ReadLine();

            // If we successfully parse the value, we return.
            if (int.TryParse(str, out value))
            {
                if (value >= 0 && value <= 2)
                {
                    return value;
                }
            }
        }
    }
}