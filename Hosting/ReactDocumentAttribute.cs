namespace ReactByCode.Hosting;

// Marks an action that serves the React document shell.
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public sealed class ReactDocumentAttribute : Attribute;