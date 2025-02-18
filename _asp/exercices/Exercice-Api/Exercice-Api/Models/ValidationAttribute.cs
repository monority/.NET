using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class UpperCaseAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string str && str != str.ToUpper())
        {
            return new ValidationResult("Le nom doit être en majuscules.");
        }
        return ValidationResult.Success;
    }
}

public class CapitalizeFirstLetterAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string str && (str.Length == 0 || char.IsLower(str[0])))
        {
            return new ValidationResult("Le prénom doit commencer par une majuscule.");
        }
        return ValidationResult.Success;
    }

}

public class BirthDateLimit : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateOnly date && date.Year < 1910)
        {
            return new ValidationResult("Birthdate should be after 1910");
        }
        return ValidationResult.Success;
    }
}

public class LimitToCharacters : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string character && !"FMN".Contains(character))
        {
            return new ValidationResult("The character must be F, M, or N.");
        }
        return ValidationResult.Success;
    }
}


public class ValidateEmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string email && !IsValidEmail(email))
        {
            return new ValidationResult("Email is invalid.");
        }
        return ValidationResult.Success;
    }

    private bool IsValidEmail(string email)
    {
        return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
    }
}

public class ValidatePhone : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string phone && !isValidPhone(phone))
        {
            return new ValidationResult("Phone number is invalid.");
        }
        return ValidationResult.Success;
    }
    private bool isValidPhone(string phone)
    {
        return Regex.IsMatch(phone, @"^(?:(?:\+|00)33[\s.-]{0,3}(?:\(0\)[\s.-]{0,3})?|0)[1-9](?:(?:[\s.-]?\d{2}){4}|\d{2}(?:[\s.-]?\d{3}){2})$", RegexOptions.IgnoreCase);
    }
}

