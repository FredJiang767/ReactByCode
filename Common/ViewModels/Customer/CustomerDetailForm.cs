using ReactByCode.Common.Forms;
namespace ReactByCode.Common.ViewModels.Customer;

public sealed class CustomerDetailForm : IDetailForm<CustomerDetailForm>
{
    public int? CustomerID { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }

    public static FormBuilder<CustomerDetailForm> DefineForm()
        => Layout.Form<CustomerDetailForm>()
            .Text(form => form.Name, "Name", required: true)
            .Text(form => form.Email, "Email", required: true);

    public Dictionary<string, string> Validate()
    {
        var errors = new Dictionary<string, string>();
        if (string.IsNullOrWhiteSpace(Name)) errors["name"] = "Name is required.";
        if (string.IsNullOrWhiteSpace(Email)) errors["email"] = "Email is required.";
        else if (!Email.Contains('@')) errors["email"] = "Email is invalid.";
        return errors;
    }
}
