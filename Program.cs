// See https://aka.ms/new-console-template for more information
Console.WriteLine("*******Shopping List Lab********");
//create dictionary to store item and price
Dictionary<string, double> items = new Dictionary<string, double>()
{
    {"gum",1.50 },
    {"soda",2.50 },
    {"water",2.0 },
    {"skittles",1.5 },
    {"root beer",2.50 },
    {"gatorade",2.50 },
    {"snickers",1.50 },
    {"reese",1.50 }
};

//create list to store the user ordeered items
List<string> inputList = new List<string>();
Console.WriteLine("***Available Items in stock***");
bool addAnother;
bool doesItemExist;
string selectedItem = "";
double totalPrice = 0;
//loop continue till the user wants to add more item
do
{
    Console.WriteLine("   Items  \t Price");
    Console.WriteLine("-------------------------");
    //loop through each item in dictionary to display
    foreach (var item in items)
    {
        Console.WriteLine($"{item.Key}           \t-{item.Value:c}");
    }
    doesItemExist = false;
    //check if the user ordered valid item from list. loop continue till the user enter valid item by checking with items collection
    while (doesItemExist == false)
    {
        Console.WriteLine("what would you like to buy?\t");
        selectedItem = Console.ReadLine().ToLower().Trim();
        doesItemExist = items.ContainsKey(selectedItem);
        if (doesItemExist == false)
        {
            Console.WriteLine("Sorry, we don't have that item. Please try again");
        }
    }
    Console.WriteLine($"Adding {selectedItem} to cart at {items[selectedItem]:c}");
    // add selected item to the list and concatenate the price to find sum
    inputList.Add(selectedItem);
    
    totalPrice = totalPrice + items[selectedItem];

    Console.WriteLine("Would you like to order another item? say \"add\" or \"stop\"");

    addAnother = Console.ReadLine().ToLower().Trim() == "add";

} while (addAnother == true);

Console.ReadKey();
Console.Clear();
Console.WriteLine("***Thanks for your order***");
Console.WriteLine("   Here's what you got   ");
Console.WriteLine("------------------------------------");
//iterate the list to display the items orderd with price and also display the total price ordered
Dictionary<string, double> sortDict = new Dictionary<string, double>();

foreach (string list in inputList)
{
    Console.Write($"{list}           \t-");
    Console.WriteLine($" {items[list]:c}");
    sortDict.Add(list, items[list]);
    
}
Console.WriteLine("------------------------------------");
Console.WriteLine($"Total Price = \t{totalPrice:c}");
Console.WriteLine("------------------------------------");

Console.ReadKey();
Console.WriteLine("\nList Ordered by Price");
Console.WriteLine("------------------------------------");

foreach (KeyValuePair<string, double> sortValue in sortDict.OrderBy(key => key.Value))
{
    Console.WriteLine($"{sortValue.Key} - \t{sortValue.Value:c}");

}
Console.WriteLine("------------------------------------");
Console.WriteLine($"Total Price = \t{totalPrice:c}");
Console.WriteLine("------------------------------------");

KeyValuePair<string, double> kvpWithMaxValue = sortDict.Aggregate((a, b) => a.Value > b.Value ? a : b);
KeyValuePair<string, double> kvpWithMinValue = sortDict.Aggregate((a, b) => a.Value < b.Value ? a : b);

Console.WriteLine($"Most expensive Item ordered is {kvpWithMaxValue.Key} at {kvpWithMaxValue.Value:c}");
Console.WriteLine($"Least Expensive Item ordered is {kvpWithMinValue.Key} at {kvpWithMinValue.Value:c}");