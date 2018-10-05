﻿using System.ComponentModel.DataAnnotations;

namespace Lykke.Service.PayTransferValidation.Validation
{
    /// <summary>
    /// Checks if decimal value is greater then zero.
    /// </summary>
    /// <seealso cref="System.ComponentModel.DataAnnotations.ValidationAttribute" />
    internal class DecimalGreaterThanZeroAttribute : ValidationAttribute
    {
        /// <inheritdoc />
        public override string FormatErrorMessage(string name)
            => $"{name} must be more greater than zero.";

        /// <inheritdoc />
        public override bool IsValid(object value)
        {
            // Nullable should be checked by required flag.
            if (value == null)
            {
                return true;
            }

            if (value as decimal? > 0m) return true;
            return false;
        }

        /// <inheritdoc />
        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            if (IsValid(value))
                return ValidationResult.Success;

            return new ValidationResult(
                FormatErrorMessage(validationContext.MemberName)
            );
        }
    }
}
