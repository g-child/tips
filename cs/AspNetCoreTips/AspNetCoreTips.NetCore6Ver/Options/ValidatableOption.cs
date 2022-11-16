using System.ComponentModel.DataAnnotations;

namespace AspNetCoreTips.NetCore6Ver.Options
{
    public class ValidatableOption : IValidatableObject
    {
        public string? NonNull { get; set; }
        public int MoreThan1 { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (NonNull is null) { yield return new ValidationResult("not null", new[] { nameof(NonNull) }); }
            if (MoreThan1 < 1) { yield return new ValidationResult("< 1", new[] { nameof(MoreThan1) }); }
        }
    }
}
