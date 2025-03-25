using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class FeatherlessClient
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _apiUrl;
    private string _model;

    public delegate void StreamUpdateHandler(string text);
    public event StreamUpdateHandler? OnStreamUpdate;

    public FeatherlessClient(string apiKey, string apiUrl = "https://api.featherless.ai/v1/chat/completions")
    {
        _httpClient = new HttpClient();
        _apiKey = apiKey;
        _apiUrl = apiUrl;
        _model = "featherless-ai/Qwerky-72B";
    }

    public async Task SendMessageAsync(
        string userMessage,
        string model = "featherless-ai/Qwerky-72B",
        float? presencePenalty = null,
        float? frequencyPenalty = null,
        float? repetitionPenalty = null,
        float? temperature = null,
        float? topP = null,
        int? topK = null,
        float? minP = null,
        int? seed = null,
        List<string>? stop = null,
        List<int>? stopTokenIds = null,
        bool? includeStopStrInOutput = null,
        int? maxTokens = null,
        int? minTokens = null)
    {
        var requestBody = new Dictionary<string, object?>
        {
            { "model", model },
            { "messages", new[]
                {
                    new { role = "system", content = "You are a helpful assistant." },
                    new { role = "user", content = userMessage }
                }
            },
            { "stream", true }
        };

        // Only add optional parameters if they are set
        AddIfNotNull(requestBody, "presence_penalty", presencePenalty);
        AddIfNotNull(requestBody, "frequency_penalty", frequencyPenalty);
        AddIfNotNull(requestBody, "repetition_penalty", repetitionPenalty);
        AddIfNotNull(requestBody, "temperature", temperature);
        AddIfNotNull(requestBody, "top_p", topP);
        AddIfNotNull(requestBody, "top_k", topK);
        AddIfNotNull(requestBody, "min_p", minP);
        AddIfNotNull(requestBody, "seed", seed);
        AddIfNotNull(requestBody, "stop", stop);
        AddIfNotNull(requestBody, "stop_token_ids", stopTokenIds);
        AddIfNotNull(requestBody, "include_stop_str_in_output", includeStopStrInOutput);
        AddIfNotNull(requestBody, "max_tokens", maxTokens);
        AddIfNotNull(requestBody, "min_tokens", minTokens);

        var json = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        using var request = new HttpRequestMessage(HttpMethod.Post, _apiUrl);
        request.Headers.Add("Authorization", $"Bearer {_apiKey}");
        request.Content = content;

        using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"API call failed: {response.StatusCode}");
        }

        using var stream = await response.Content.ReadAsStreamAsync();
        using var reader = new StreamReader(stream);

        while (!reader.EndOfStream)
        {
            var line = await reader.ReadLineAsync();
            if (line is not null && line.StartsWith("data: "))
            {
                string jsonResponse = line.Substring(6).Trim();
                if (!string.IsNullOrEmpty(jsonResponse) && jsonResponse != "[DONE]")
                {
                    try
                    {
                        var responseObject = JsonSerializer.Deserialize<JsonElement>(jsonResponse);
                        string? delta = responseObject.GetProperty("choices")[0].GetProperty("delta").GetProperty("content").GetString();
                        if (delta != null)
                        {
                            OnStreamUpdate?.Invoke(delta);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error parsing response: " + ex.Message);
                    }
                }
            }
        }
    }

    private void AddIfNotNull<T>(Dictionary<string, object?> dict, string key, T? value)
    {
        if (value != null)
        {
            dict[key] = value;
        }
    }
}