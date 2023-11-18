
const string materialDictionaryPath = ".";
const string namesDictionaryPath = $"{materialDictionaryPath}/us_names.txt";
const string prefixChar = ">";
const string inputPrompt = "Enter name: ";
const string helloMessage = "Hello, {0}!";
const string checkNameMessage = "Did you mean \"{0}\"?";
const string notFoundMessage = "Your name was not found.";

const string expectedUserInputYes = "Y";
const string expectedUserInputNo = "N";
 
const int maxDistance = 2;

var names = File.ReadAllLines(namesDictionaryPath);

Print(inputPrompt);
var input = Console.ReadLine();


if (input is null or "")
{
	Print(notFoundMessage);
	return;
}

var findingName = input;

foreach (var name in names)
{
	if (name == findingName)
	{
		Print(string.Format(helloMessage, name));
		return;
	}
	
	if (LevenshteinDistance(name, findingName) < maxDistance)
	{
		Print(string.Format(checkNameMessage, name));
		var isUserInputValid = false;

		while (!isUserInputValid)
		{
			input = Console.ReadLine();
			isUserInputValid = true;
			
			switch (input)
			{
				case expectedUserInputYes:
					Print(string.Format(helloMessage, name));
					return;
				case expectedUserInputNo:
					Print(notFoundMessage);
					break;
				default:
					isUserInputValid = false;
					break;
			}
		}
	}
}

return;


void Print(string message)
{
	Console.Write(prefixChar);
	Console.WriteLine(message);
}

int LevenshteinDistance(string? str1, string str2)
{
	if (str1 == null)
		throw new ArgumentNullException(nameof(str1));
	if (str2 == null)
		throw new ArgumentNullException(nameof(str2));
	
	var len1 = str1.Length;
	var len2 = str2.Length;
	
	var d = new int[len1 + 1, len2 + 1];
	
	for (var i = 0; i <= len1; ++i)
		d[i, 0] = i;
	
	for (var i = 0; i <= len2; ++i)
		d[0, i] = i;

	for (var i = 1; i <= len1; ++i)
	{
		for (var j = 1; j <= len2; ++j)
		{
			if (str1[i - 1] == str2[j - 1])
				d[i, j] = d[i - 1, j - 1];
			else
				d[i, j] = 1 + Math.Min(d[i - 1, j - 1], Math.Min(d[i, j - 1], d[i - 1, j]));
		}
	}
	
	return d[len1, len2];
}