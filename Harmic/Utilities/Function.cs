using SlugGenerator;
using System.Text;
using System.Text.RegularExpressions;

namespace Harmic.Utilities
{
    public class Function
    {
        public static string TitleSlugGenerationAlias(string title)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug(title);
        }

        public static string TitleSlugGeneration(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return string.Empty;

            // Chuyển đổi sang chữ thường
            string slug = title.ToLowerInvariant();
            slug = RemoveDiacritics(slug);

            // Loại bỏ dấu tiếng Việt
            // Loại bỏ ký tự không hợp lệ
            slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");

            // Thay khoảng trắng bằng dấu gạch ngang
            slug = Regex.Replace(slug, @"\s+", "-").Trim('-');

            return slug;
        }
        private static string RemoveDiacritics(string text)
        {
            string normalized = text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            foreach (char c in normalized)
            {
                if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

    }
}
