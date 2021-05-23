using FluentValidation;

namespace ClientsApi.Validators
{
    public static class CustomValidators
    {
        private const string UrlRegex = @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";
        
        public static IRuleBuilderOptions<T, string> Phone<T>(this IRuleBuilder<T, string> ruleBuilder) =>
            ruleBuilder.Matches(@"^\+7 \d{3} \d{3} \d{2} \d{2}$").WithMessage("Incorrect phone format");

        public static IRuleBuilderOptions<T, string> Tin<T>(this IRuleBuilder<T, string> ruleBuilder) =>
            ruleBuilder.Must(IsValidChecksum).WithMessage("Incorrect tin format");

        public static IRuleBuilderOptions<T, string> Url<T>(this IRuleBuilder<T, string> ruleBuilder) =>
            ruleBuilder.Matches(UrlRegex).WithMessage("Incorrect url format");

        private static bool IsValidChecksum(string tin)
        {
            if (tin == null) return true;
            
            var len = tin.Length;

            if (len != 10 && len != 12) return false;

            var sum = 0;
            var coefficients = new[] {3, 7, 2, 4, 10, 3, 5, 9, 4, 6, 8};

            for (var i = 1; i < len; i++)
                sum += int.Parse(tin.Substring(i - 1, 1)) * coefficients[11 - len + i];

            return int.Parse(tin.Substring(len - 1, 1)) == sum % 11 % 10;
        }
    }
}
