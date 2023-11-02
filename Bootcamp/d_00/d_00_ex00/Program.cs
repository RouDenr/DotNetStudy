using System.Globalization;

const string error = "Something went wrong. Check your input and retry.";

if (!ArgsAreValid(args))
{
	PrintError();
	return;
}


// Loan amount, RUB
var sum = double.Parse(args[0]);
// Annual percentage rate
var rate = double.Parse(args[1]) / 12 / 100;
// Number of months of the loan
var term = int.Parse(args[2]);


var payment = sum * rate 
              * Math.Pow(1 + rate, term) 
              / (Math.Pow(1 + rate, term) - 1);

Console.WriteLine("Payment no.\t" +
                  "Payment Date\t" +
                  "Payment\t" +
                  "Principal debt\t" +
                  "Interest\t" +
                  "Remaining debt");
DateTime date = DateTime.Today.AddMonths(1);
for (var i = 1; i <= term; ++i)
{
	var interest = sum * (rate / 12 * DateTime.DaysInMonth(date.Year, date.Month)) 
								/ (DateTime.IsLeapYear(date.Year) ? 366 : 365);
	
	var principal = payment - interest;
	sum -= principal;
	
	if (i == term)
	{
		payment += sum;
		principal += sum;
		sum = 0;
	}
	Console.WriteLine($"{i}\t" +
	                  $"{date.ToString("d", CultureInfo.CreateSpecificCulture("en-US"))}\t" +
	                  $"{payment:F2}\t" +
	                  $"{principal:F2}\t" +
	                  $"{interest:F2}\t" +
	                  $"{sum:F2}");
	
	date = date.AddMonths(1);
}





void PrintError()
{
	Console.WriteLine(error);
}

bool ArgsAreValid(string[] args)
{
	return args.Length == 3
		&& double.TryParse(args[0], out _)
		&& double.TryParse(args[1], out _)
		&& int.TryParse(args[2], out _);
}

void PrintUpcomingPayment(double sum, double rate, int years)
{
	
}