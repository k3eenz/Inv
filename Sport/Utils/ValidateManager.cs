using System.ComponentModel.DataAnnotations;
using System.Windows;

public static class ValidateManager
{
    public static bool IsNullTextBox(params string[] data)
    {
        foreach (string text in data)
        {
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("Заполните все поля");
                return true;
            }
        }
        return false;
    }

    public static bool IsCorrectModel<T>(T model)
    {
        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(model, context, results, true);

        if (!isValid)
        {
            MessageBox.Show(results.First().ErrorMessage);
            return false;
        }

        return true;
    }
}