using System.Text;

List<string[]> ourAnimals =
[
    // {ID, Espécie, Idade, Condições, Personalidade, Apelido, Castrado}
    ["1", "Cachorro", "3", "Pelagem branca, porte médio", "Amigável, ativo", "Buddy", "Não Castrado"],
    ["2", "Gato", "2", "Pelagem preta, olhos verdes", "Calmo, independente", "Luna", "Castrado"],
    ["3", "Cachorro", "5", "Pelagem marrom, porte grande", "Protetor, leal", "Rex", "Não Castrado"],
    ["4", "Papagaio", "2", "Plumagem verde, bico branco", "inteligente", "Loro", "Não Castrado"],
];

bool optionIsValid = false;

do
{
    printMenu();
    var input = Console.ReadLine();

    optionIsValid = int.TryParse(input, out int option);
    if (!optionIsValid)
    {
        Console.WriteLine("Invalid Option! please choose a valid one: ");
        continue;
    }

    MenuProcess(option);

} while (!optionIsValid);


void printMenu()
{
    StringBuilder menu = new StringBuilder();
    menu.AppendLine("Menu principal - Selecione a opção que deseja: ");
    menu.AppendLine("0 - Listar animais");
    menu.AppendLine("1 - Adicionar novo bixinho");
    menu.AppendLine("2 - Adicionar dados veterinários");

#if !DEBUG
    Console.Clear();
#endif
    Console.WriteLine(menu);
}

void MenuProcess(int option)
{
    switch (option)
    {
        case 0:
            PrintListedAnimals(); break;

        case 1:
            AddNewAnimal(); break;

        case 2:
            AddVeterinaryInfo(); break;

        default:
            {
                Console.WriteLine("Invalid Option");
                optionIsValid = false;
                break;
            }
    }
}

void AddVeterinaryInfo()
{
#if !DEBUG
    Console.Clear();
#endif

    do
    {
        Console.Write("Digite o ID do animal que deseja inserir as informações: ");
        var input = Console.ReadLine();

        optionIsValid = int.TryParse(input, out var targetID);

        foreach (var animal in ourAnimals)
        {
            if (animal[0] == targetID.ToString())
            {
                Console.WriteLine($"\nAnimal encontrado: ID: {animal[0]} | Espécie: {animal[1]} | Idade: {animal[2]} | Condições: {animal[3]} | Personalidade: {animal[4]} | Apelido: {animal[5]} | Castração: {animal[6]}\n");
                foreach (var info in animal)
                {
                    if(info == "desconhecido")
                    Console.WriteLine("parece que alguns dados estão faltando, deseja atualizar o cadastro?");
                }
                break;
            } 
            else 
            {
                Console.WriteLine("Animal não encontrado na base!");
                optionIsValid = false; continue;
            }
        }

        Console.WriteLine("");

    } while (!optionIsValid);

}

void AddNewAnimal()
{
#if !DEBUG
    Console.Clear();
#endif
    Console.WriteLine("*** Register animal info screen ! ***");

    string race = "";
    var input = "";
    do
    {
        Console.WriteLine("Qual a raça do novo animalzinho? \n1- Cachorro\n2- Gato\n3- Papagaio");
        input = Console.ReadLine();

        optionIsValid = int.TryParse(input, out int option);
        if (!optionIsValid)
        {
            Console.WriteLine("Invalid Option! please choose a valid one: ");
            continue;
        }

        switch (option)
        {
            case 1:
                race = "Cachorro"; break;
            case 2:
                race = "Gato"; break;
            case 3:
                race = "Papagaio"; break;
            default:
                {
                    Console.WriteLine("Invalid Option");
                    optionIsValid = false;
                    break;
                }
        }
    } while (!optionIsValid);

    var lastRegisterId = int.Parse(ourAnimals.LastOrDefault()[0]);
    var newId = lastRegisterId + 1;

    Console.WriteLine("O animalzinho tem apelido ou nome? (Y/N)");
    input = Console.ReadLine();
    var name = "desconhecido";
    if (input != null && input == "Y")
    {
        Console.Write("Qual seria seu nome? ");
        name = Console.ReadLine();
    }

    // {ID, Espécie, Idade, Condições, Personalidade, Apelido, Castrado?}
    ourAnimals.Add([newId.ToString(), race, "desconhecido", "desconhecido", "desconhecido", name, "desconhecido"]);

    Console.WriteLine("Sucessfuly added!");
    PrintListedAnimals();
}

void PrintListedAnimals()
{
#if !DEBUG
    Console.Clear();
#endif
    Console.WriteLine("ID - RACE - AGE - PHYSICAL DESCRIPTION - PERSONALITY - NICKNAME");
    foreach (var animal in ourAnimals)
    {
        foreach (var info in animal)
        {
            Console.Write(info + "---");
        }
        Console.WriteLine("");
    }

#if !DEBUG
    Console.Clear();
#endif
    Console.Write("\n Want to go back to menu? Y/N:  ");
    var option = Console.ReadLine();

    if (option != null && option == "Y")
        optionIsValid = false;

}