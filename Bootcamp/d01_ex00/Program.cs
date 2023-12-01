// See https://aka.ms/new-console-template for more information

using d01_ex00;

Test(TestEmptyStorage);
return;

// Тестовые Функции
bool TestEmptyStorage()
{
	Storage storage = new Storage(10);
	return storage.IsEmpty;
}

void Test(Func<bool> testFunc)
{
	if (testFunc())
	{
		Console.WriteLine($"{testFunc.Method.Name} passed");
	}
	else
	{
		throw new Exception($"{testFunc.Method.Name} failed");
	}
}