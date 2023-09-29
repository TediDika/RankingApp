using FluentValidation;
using FluentValidation.TestHelper;
using RankingApp.Models;

namespace RankingApp.Validator
{
    public class ItemValidator : AbstractValidator<ItemModel>
    {
        public ItemValidator()
        {
            RuleFor(model => model.Ranking).InclusiveBetween(0, 16).WithMessage("Rank out of bounds");
            RuleFor(model => model.Ranking).NotNull().WithMessage("Rank can't be null");
            RuleFor(model => model.Title).NotEmpty().WithMessage("Title can't be empty");
            RuleFor(model => model.Title).NotNull().WithMessage("Title can't be null");
            RuleFor(model => model.ItemType).InclusiveBetween(0, 2).WithMessage("Invalid item type");
        }
    }
}
