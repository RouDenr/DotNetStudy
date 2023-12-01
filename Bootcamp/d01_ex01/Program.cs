using d01_ex01;

try
{
	Test(TestToStringCustomer);
	Test(TestSameCustomer);
}
catch (Exception e)
{
	Console.WriteLine(e);
}

bool TestToStringCustomer()
{
	var customer = new Customer("Andrew", 1);
	return customer.ToString() == "Andrew, customer #1";
}

bool TestSameCustomer()
{
	var customer1 = new Customer("Andrew", 1);
	var customer2 = new Customer("Andrew", 1);
	return customer1 == customer2;
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