
var handler = new HttpClientHandler
{
	ServerCertificateCustomValidationCallback = (request, cert, chain, errors) =>
	{
		Console.WriteLine("SSL error skipped");
		return true;
	}
};
HttpClient client = new HttpClient(handler);
//NOT OK - https://exchange.sandbox.local/ews/exchange.asmx
//OK - https://expired.badssl.com
//OK - https://self-signed.badssl.com
using HttpResponseMessage response = await client.GetAsync("https://exchange.sandbox.local/ews/exchange.asmx");

//expect response statuscode 401
string responseBody = await response.Content.ReadAsStringAsync();
Console.WriteLine("Response body: " + responseBody);
