using System;
using System.IO;
using System.Net;
using System.Collections.Generic;

var accessToken = "D239E89F68E4DF4BAFF1F9431E3F7AB934E24455467563701CBC03E20505577C4B4A0A14D5F0857EDADFBD0551815B065ADB22E690A040AD21E0725A8E8E11AA0D7B40D1B4638F4612485DF0D49C8EF1";

Console.WriteLine(HttpRequest.Main(accessToken));

public class HttpRequest
{
	public static string Main(string accessToken)
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
		
		if (!data.Contains("Unauthorized"))
		{
			char[] splitChars = {',', ':'};
			string[] splitData = data.Split(splitChars);
			List<string> dataStringList = new List<string>();

			foreach (var sub in splitData)
			{
				char[] trimChars = { '{', '}', '\"'};
				var subList = sub.Trim(trimChars);
				//Console.WriteLine($"Substring: {subList}");
				dataStringList.Add(subList);
			}

			//Console.WriteLine(String.Join(" ", dataStringList));
			string dataString = String.Join(" ", dataStringList);
			return dataString;
		}
		else
		{
			string dataString = data;
			return dataString;
		}
	}
}
