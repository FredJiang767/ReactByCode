namespace ReactByCode.Hosting;

// What the Razor shell needs to render a React page.
public sealed record ReactDocument(string ConfigurationJson, string ScriptUrl, string[] Styles, string? ViteBasePath);
