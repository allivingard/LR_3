using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lr1WebApi.Models
{
    public class PersonModel
    {
         public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
    
public BaseModelValidationResult Validate()
        {
            var validationResult = new BaseModelValidationResult();

            if (string.IsNullOrWhiteSpace(Name)) validationResult.Append($"Name cannot be empty");
            if (string.IsNullOrWhiteSpace(SurName)) validationResult.Append($"Surname cannot be empty");
            if (!(0 <  Age && Age < 100)) validationResult.Append($"Age {Age} is out of range (0..100)");

            if (!string.IsNullOrEmpty(Name) && !char.IsUpper(Name.FirstOrDefault())) validationResult.Append($"Name {Name} should start from capital letter");
            if (!string.IsNullOrEmpty(SurName) && !char.IsUpper(SurName.FirstOrDefault())) validationResult.Append($"Surname {SurName} should start from capital letter");

            return validationResult;
        }
public override string ToString()
        {
            return $"{Name} {SurName} age is {Age} from {Group}";
        }
}}

