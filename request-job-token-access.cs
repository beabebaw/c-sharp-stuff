using System;
using System.IO;
using System.Net;

var accessToken = "2DFB5994E9E9344BACFB44ED65AA5735876914D1258A1190CB207465530276DD0AEA98A1D79E824650AE42220FB502E7187B8A7E8091DB1D508F50A0ECA695D004DB60CD71D1AE440A0A366F99963BD9";

HttpRequest.Main(accessToken);

public class HttpRequest
{
	public static void Main(string accessToken)
	{
		var url = "https://gene.lacuna.cc/api/dna/jobs";

		var httpRequest = (HttpWebRequest)WebRequest.Create(url);
		httpRequest.Method = "GET";

		httpRequest.Accept = "application/json";
		httpRequest.Headers["Authorization"] = "Bearer " + accessToken;

		var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
		var reader = new StreamReader(httpResponse.GetResponseStream());
		var data = reader.ReadToEnd();

		Console.WriteLine(httpResponse.StatusCode);
		Console.WriteLine(data);
		
		reader.Close();
		httpResponse.Close();
	}
}
