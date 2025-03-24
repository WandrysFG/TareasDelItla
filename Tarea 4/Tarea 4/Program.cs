
List<decimal> typedNumbers = new List<decimal>();

decimal result = 0;
int typedOption = 1;
bool running = true;


Console.WriteLine("This is the best calculator");

while (running)
{
    DisplayHeader();

    try
    {
        typedOption = Convert.ToInt32(Console.ReadLine());

        if (typedOption == 5)
        { running = false; }
        else
        {
            typedNumbers.Clear();
            int wantToContinue = 0;

            Console.WriteLine("Please Type the first number");
            typedNumbers.Add(Convert.ToDecimal(Console.ReadLine()));

            Console.WriteLine("Please Type the second number");
            typedNumbers.Add(Convert.ToDecimal(Console.ReadLine()));

            while (wantToContinue != 2)
            {
                Console.WriteLine("you want to continue inserting numbers? 1. Yes, 2. No");
                wantToContinue = Convert.ToInt32(Console.ReadLine());
                if (wantToContinue == 1)
                {
                    Console.WriteLine("Please Type another number");
                    typedNumbers.Add(Convert.ToDecimal(Console.ReadLine()));
                }
            }

            switch (typedOption)
            {
                case 1:
                    {
                        result = AddList(typedNumbers);
                    }
                    break;
                case 2:
                    {
                        result = SubtractList(typedNumbers);
                    }

                    break;
                case 3:
                    {
                        result = MultiplyList(typedNumbers);
                    }

                    break;
                case 4:
                    {
                        result = DivideList(typedNumbers);
                    }
                    break;
                default:
                    result = 0;
                    break;
            }

            Console.WriteLine($"The Result of the operation is:{result}");


        }
    }
    catch (DivideByZeroException ex)
    {
        Console.WriteLine($"You can not divide by zero: {ex.Message}");
    }
    catch (ArithmeticException ex)
    {
        Console.WriteLine($"You can not divide by zero: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"You need to choose a correct option: {ex.Message}");
    }
    finally
    {
        Console.WriteLine("Closing Db Conection");
    }

}

//function
static void DisplayHeader()
{
    Console.WriteLine("Please Type the option number than you want");
    Console.WriteLine("---------------------------------------");
    Console.WriteLine("1. Sum, \n2. Substract,  \n3. Multiplication,  \n4. Division,  \n5. Exit");
}

static decimal Subtract(decimal a, decimal b) => a - b;
static decimal Multiply(decimal a, decimal b) => a * b;
static decimal Divide(decimal a, decimal b) => a / b;

static decimal Add(decimal valueToModify, decimal value)
{
    valueToModify += value;
    return valueToModify;
}

static decimal AddList(List<decimal> typedNumbers)
{
    decimal result = 0;
    foreach (decimal typedNumber in typedNumbers)
    {
        result = Add(result, typedNumber);
    }
    return result;
}

static decimal SubtractList(List<decimal> typedNumbers)
{
    if (typedNumbers.Count == 0) return 0;

    decimal result = typedNumbers[0];
    for (int i = 1; i < typedNumbers.Count; i++)
    {
        result = Subtract(result, typedNumbers[i]);
    }
    return result;
}

static decimal MultiplyList(List<decimal> typedNumbers)
{
    if (typedNumbers.Count == 0) return 1;

    decimal result = typedNumbers[0];
    for (int i = 1; i < typedNumbers.Count; i++)
    {
        result = Multiply(result, typedNumbers[i]);
    }
    return result;
}

static decimal DivideList(List<decimal> typedNumbers)
{
    if (typedNumbers.Count == 0)
    {
        throw new InvalidOperationException("No numbers to divide.");
    }

    decimal result = typedNumbers[0];
    for (int i = 1; i < typedNumbers.Count; i++)
    {
        result = Divide(result, typedNumbers[i]);
    }
    return result;
}