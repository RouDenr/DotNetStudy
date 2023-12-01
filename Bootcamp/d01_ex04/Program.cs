using d01_ex04;

try
{
	Test(TestEmptyStorage);
	Test(TestToStringCustomer);
	Test(TestSameCustomer);
	Test(TestDifferentCustomer);
	Test(TestCreateRandomCard);
}
catch (Exception e)
{
	Console.WriteLine(e);
}


bool TestEmptyStorage()
{
	Storage storage = new Storage(10);
	return storage.IsEmpty;
}

bool TestToStringCustomer()
{
	var customer = new Customer("Andrew", 1);
	return customer.ToString() == "Andrew, customer #1 (0 items in cart)";
}

bool TestSameCustomer()
{
	var customer1 = new Customer("Andrew", 1);
	var customer2 = new Customer("Andrew", 1);
	return customer1 == customer2;
}

bool TestDifferentCustomer()
{
	var customer1 = new Customer("Andrew", 1);
	var customer2 = new Customer("Andrew", 2);
	return customer1 != customer2;
}

bool TestCreateRandomCard()
{
	var customer = new Customer("Andrew", 1);
	var customer2 = new Customer("Bob", 2);
	var customer3 = new Customer("Charlie", 3);
	
	
	customer.FillCart(15);
	Console.WriteLine(customer);
	if (customer.GoodsCount is <= 0 or > 15)
	{
		return false;
	}
	customer2.FillCart(15);
	Console.WriteLine(customer2);
	if (customer2.GoodsCount is <= 0 or > 15)
	{
		return false;
	}
	customer3.FillCart(15);
	Console.WriteLine(customer3);
	return customer3.GoodsCount is > 0 and <= 15;
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