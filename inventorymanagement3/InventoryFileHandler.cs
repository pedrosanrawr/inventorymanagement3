using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace inventorymanagement3
{
    public class InventoryItem
    {
        public string ItemNumber { get; set; }
        public string ItemName { get; set; }
        public double ManufacturingCost { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
    }

    public static class InventoryFileHandler
    {
        private const string FilePath = "inventory_data.csv";

        public static void SaveInventoryItems(List<InventoryItem> inventoryItems)
        {
            // Convert inventory items to CSV format
            IEnumerable<string> lines = inventoryItems.Select(item =>
                $"{item.ItemNumber},{item.ItemName},{item.ManufacturingCost},{item.Quantity}");

            // Write CSV lines to the file
            File.WriteAllLines(FilePath, lines);
        }

        public static List<InventoryItem> LoadInventoryItems()
        {
            List<InventoryItem> loadedItems = new List<InventoryItem>();

            // Read CSV lines from the file
            if (File.Exists(FilePath))
            {
                IEnumerable<string> lines = File.ReadLines(FilePath);

                // Parse CSV lines and create InventoryItem objects
                foreach (string line in lines)
                {
                    string[] values = line.Split(',');
                    if (values.Length == 4)
                    {
                        loadedItems.Add(new InventoryItem
                        {
                            ItemNumber = values[0],
                            ItemName = values[1],
                            ManufacturingCost = double.Parse(values[2], CultureInfo.InvariantCulture),
                            Quantity = int.Parse(values[3])
                        });
                    }
                }
            }

            return loadedItems;
        }
    }
}

