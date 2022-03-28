
using Newtonsoft.Json;
using System.Collections;
using System.Linq;
using System.Text.Json;
string start = "";
string name = "";
int age;
int pay = 10000;
string fileName = "student.json";


List<Students> list = new List<Students>()
{
    new Students(){ Name ="moshe",Age=45},
    new Students(){ Name ="david",Age=34},
    new Students(){ Name ="reina",Age=23},
    new Students(){ Name ="joe",Age=41},
    new Students(){ Name ="dana",Age=24},
    new Students(){ Name ="ramya",Age=35}

};
string jsonString = System.Text.Json.JsonSerializer.Serialize(list);
File.WriteAllText(fileName, jsonString);
while (start != "q")
{

    Console.WriteLine(@"choosh an option from the folliwing list:
                            a - Add
                            r - Remove
                            e - Enumerate
                            es - name+pay
                            q - Quit
Your Option?");

    start = Console.ReadLine().ToLower();
    Console.Clear();
    switch (start)
    {
        case "a":
            {

                Console.WriteLine("Enter is name");
                name = Console.ReadLine();
                Console.WriteLine("Enter is age");
                age = int.Parse(Console.ReadLine());
                list.Add(new Students() { Name = name, Age = age });
                jsonString = System.Text.Json.JsonSerializer.Serialize(list);
                File.WriteAllText(fileName, jsonString);
                break;


            }
            break;
        case "e":
            {
                string json = File.ReadAllText(fileName);
                var playerList = JsonConvert.DeserializeObject<List<Students>>(json);
                for (int i = 0; i < playerList.Count; i++)
                {
                    Console.WriteLine(playerList[i].Name + " " + playerList[i].Age);
                }
            }
            break;
        case "es":
            {
                string json = File.ReadAllText(fileName);
                var playerList = JsonConvert.DeserializeObject<List<Students>>(json);
                for (int i = 0; i < playerList.Count; i++)
                {
                    if (playerList[i].Age < 25)
                    {
                        Console.WriteLine(playerList[i].Name + " " + playerList[i].Age + " need to pay " + pay * 0.9);
                    }
                    else
                        Console.WriteLine(playerList[i].Name + " " + playerList[i].Age + " need to pay " + pay);
                }
            }
            break;
        case "r":
            {
                Console.WriteLine("Enter a student name you want to remove");
                name = Console.ReadLine();
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Name == name)
                    {
                        list.RemoveAt(i);
                        jsonString = System.Text.Json.JsonSerializer.Serialize(list);
                        File.WriteAllText(fileName, jsonString);

                    }
                }


                //if (list.Contains(new Students() { Name = "dana" }))
                //{
                //    Console.WriteLine("hhhhh");
                //}

            }
            break;

        case "q":
            {
                Console.WriteLine("goodbye!");
                break;
            }
            break;
        default:
            {
                Console.WriteLine("Try Again");
            }
            break;
    }

}




Console.WriteLine(jsonString);

public class Students
{
    public Students() { }
    public string? Name { get; set; }
    public int Age { get; set; }
}
