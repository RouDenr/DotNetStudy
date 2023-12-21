using d01_ex04;

try
{
	Test(TestEmptyStorage);
	Test(TestToStringCustomer);
	Test(TestSameCustomer);
	Test(TestDifferentCustomer);
	Test(TestCreateRandomCard);
	Test(Test25RandomCards);
	Test(TestSameCashRegister);
	Test(TestDifferentCashRegister);
	Test(TestCashRegisterWithMinCustomers);
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
	
	Storage storage = new Storage(45, 45);
	
	customer.FillCart(15, storage);
	if (customer.GoodsCount is <= 0 or > 15)
	{
		Console.WriteLine("Goods count is out of range");
		return false;
	}
	customer2.FillCart(15, storage);
	if (customer2.GoodsCount is <= 0 or > 15)
	{
		Console.WriteLine("Goods count is out of range");
		return false;
	}
	customer3.FillCart(15, storage);
	
	if (customer3.GoodsCount is > 0 and <= 15)
	{
		return true;
	}
	Console.WriteLine("Goods count is out of range");
	return false;
}

bool Test25RandomCards()
{
	var customers = new Customer[25];
	for (int i = 0; i < customers.Length; i++)
	{
		customers[i] = new Customer($"Customer #{i + 1}", i + 1);
		customers[i].FillCart(15, new Storage(45, 45));
		if (customers[i].GoodsCount is > 0 and <= 15) continue;
		
		Console.WriteLine("Goods count is out of range");
		return false;
	}
	return true;
}

bool TestSameCashRegister()
{
	var cashRegister1 = new CashRegister("Register #1");
	var cashRegister2 = new CashRegister("Register #1");
	return cashRegister1 == cashRegister2;
}

bool TestDifferentCashRegister()
{
	var cashRegister1 = new CashRegister("Register #1");
	var cashRegister2 = new CashRegister("Register #2");
	return cashRegister1 != cashRegister2;
}


bool TestCashRegisterWithMinCustomers()
{
	var cashRegister1 = new CashRegister("Register #1");
	var cashRegister2 = new CashRegister("Register #2");
	var cashRegister3 = new CashRegister("Register #3");
	var cashRegister4 = new CashRegister("Register #4");
	var cashRegister5 = new CashRegister("Register #5");
	
	cashRegister1.AddCustomer(new Customer("Andrew", 1));
	cashRegister1.AddCustomer(new Customer("Bob", 2));
	cashRegister1.AddCustomer(new Customer("Charlie", 3));
	
	cashRegister2.AddCustomer(new Customer("Andrew", 1));
	cashRegister2.AddCustomer(new Customer("Bob", 2));
	
	cashRegister3.AddCustomer(new Customer("Andrew", 1));
	cashRegister3.AddCustomer(new Customer("Bob", 2));
	cashRegister3.AddCustomer(new Customer("Charlie", 3));
	cashRegister3.AddCustomer(new Customer("David", 4));
	
	cashRegister4.AddCustomer(new Customer("Andrew", 1));
	cashRegister4.AddCustomer(new Customer("Bob", 2));
	cashRegister4.AddCustomer(new Customer("Charlie", 3));
	cashRegister4.AddCustomer(new Customer("David", 4));
	cashRegister4.AddCustomer(new Customer("Ethan", 5));
	
	cashRegister5.AddCustomer(new Customer("Andrew", 1));
	cashRegister5.AddCustomer(new Customer("Bob", 2));
	cashRegister5.AddCustomer(new Customer("Charlie", 3));
	cashRegister5.AddCustomer(new Customer("David", 4));
	cashRegister5.AddCustomer(new Customer("Ethan", 5));
	cashRegister5.AddCustomer(new Customer("Frank", 6));
	
	var cashRegisters = new[] {cashRegister1, cashRegister2, cashRegister3, cashRegister4, cashRegister5};
	var minQueue = CustomerExtensions.CashRegisterWithMinCustomers(cashRegisters);
	return minQueue == cashRegister2;
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