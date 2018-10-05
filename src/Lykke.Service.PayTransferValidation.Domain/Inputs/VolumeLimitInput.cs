using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Lykke.Service.PayTransferValidation.Domain.Inputs
{
    public class VolumeLimitInput : IValidatableObject
    {
        public class AssetLimit
        {
            public string AssetId { get; set; }
            public SlidingPeriod? Period { get; set; }
            public decimal Limit { get; set; }
        }

        public IReadOnlyList<AssetLimit> Limits { get; set; }

        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(
            System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            if (Limits == null)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Field is required",
                    new[] {"Limits"});
            }
            else
            {
                if (Limits.Any())
                {
                    for (int i = 0; i < Limits.Count; i++)
                    {
                        if (string.IsNullOrEmpty(Limits[i].AssetId))
                            yield return new System.ComponentModel.DataAnnotations.ValidationResult(
                                $"Field is required (item[{i}])", new[] {"AssetId"});

                        if (Limits[i].Period == null)
                            yield return new System.ComponentModel.DataAnnotations.ValidationResult(
                                $"Field is required (item[{i}])", new[] {"Period"});

                        if (Limits[i].Limit <= 0)
                            yield return new System.ComponentModel.DataAnnotations.ValidationResult(
                                $"Asset limit must be greater than 0 (item[{i}])");
                    }

                    if (Limits.GroupBy(x => new {x.AssetId, x.Period}).Any(g => g.Count() > 1))
                        yield return new System.ComponentModel.DataAnnotations.ValidationResult(
                            "Only one value per asset per period is enabled", new[] {"Limits"});
                }
                else
                {
                    yield return new System.ComponentModel.DataAnnotations.ValidationResult(
                        "The collection can't be empty", new[] {"Limits"});
                }
            }
        }
    }
}
