using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TdtLab5BT.Models
{
    public class ForbiddenWordsAttribute : ValidationAttribute
    {
        private readonly string[] _forbiddenWords;

        public ForbiddenWordsAttribute(params string[] forbiddenWords)
        {
            _forbiddenWords = forbiddenWords ?? Array.Empty<string>();
        }

        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            if (value is null || string.IsNullOrWhiteSpace(value.ToString()))
                return ValidationResult.Success;

            string text = value.ToString()!;

            foreach (var word in _forbiddenWords)
            {
                if (string.IsNullOrWhiteSpace(word))
                    continue;

                // Kiểm tra không phân biệt hoa/thường và chỉ bắt đúng từ/cụm từ.
                string pattern = @"(?<![\p{L}\p{N}])" + Regex.Escape(word) + @"(?![\p{L}\p{N}])";

                if (Regex.IsMatch(text, pattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
                {
                    return new ValidationResult(
                        $"Mô tả không được chứa từ hoặc cụm từ không phù hợp: \"{word}\".",
                        new[] { validationContext.MemberName ?? string.Empty });
                }
            }

            return ValidationResult.Success;
        }
    }
}
