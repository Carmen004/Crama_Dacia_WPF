using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Crama_Dacia_WPF
{
    //validator pentru camp required
    public class StringNotEmpty : ValidationRule
    {
        //mostenim din clasa ValidationRule
        //suprascriem metoda Validate ce returneaza un
        //ValidationResult
        public override ValidationResult Validate(object value,
        System.Globalization.CultureInfo cultureinfo)
        {
            string aString = value.ToString();
            if (aString == "")
                return new ValidationResult(false, "String cannot be empty");
            return new ValidationResult(true, null);
        }
    }
    //validator pentru lungime minima a string-ului
    public class StringMinLengthValidator : ValidationRule
    {
        public override ValidationResult Validate(object value,
        System.Globalization.CultureInfo cultureinfo)
        {
            string aString = value.ToString();
            if (aString.Length < 3)
                return new ValidationResult(false, "String must have at least 3 characters!");
        return new ValidationResult(true, null);
        }
    }

    private void SetValidationBinding()
    {
        Binding nume1ValidationBinding = new Binding();
        nume1ValidationBinding.Source = clientiVSource;
        nume1ValidationBinding.Path = new PropertyPath("Nume");
        nume1ValidationBinding.NotifyOnValidationError = true;
        nume1ValidationBinding.Mode = BindingMode.TwoWay;
        nume1ValidationBinding.UpdateSourceTrigger =
       UpdateSourceTrigger.PropertyChanged;
        //string required
        nume1ValidationBinding.ValidationRules.Add(new StringNotEmpty());
        nume1TextBox.SetBinding(TextBox.TextProperty,
       nume1ValidationBinding);


        Binding prenume1ValidationBinding = new Binding();
        prenume1ValidationBinding.Source = clientiVSource;
        prenume1ValidationBinding.Path = new PropertyPath("Prenume");
        prenume1ValidationBinding.NotifyOnValidationError = true;
        prenume1ValidationBinding.Mode = BindingMode.TwoWay;
        prenume1ValidationBinding.UpdateSourceTrigger =
       UpdateSourceTrigger.PropertyChanged;
        //string min length validator
        prenume1ValidationBinding.ValidationRules.Add(new
       StringMinLengthValidator());
        prenume1TextBox.SetBinding(TextBox.TextProperty,prenume1ValidationBinding); //setare binding nou
    }

}
