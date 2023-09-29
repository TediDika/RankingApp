using FluentValidation.TestHelper;
using RankingApp;
using RankingApp.Validator;

namespace RankingAppUnitTesting
{
    public class ItemValidatorTests
    {
        private readonly ItemValidator _validator = new ItemValidator();

        /*
        [Fact]
        public void GivenInvalidRanking_ShouldHaveValidationError()
        {

            _validator.ShouldHaveValidationErrorFor(model => model.Ranking, model);
        }

        [Fact]
        public void GivenNullRanking_ShouldHaveValidationError()
        {

            _validator.ShouldHaveValidationErrorFor(model => model.Ranking, model);
        }

        [Fact]
        public void GivenEmptyTitle_ShouldHaveValidationError()
        {

            _validator.ShouldHaveValidationErrorFor(model => model.Title, model);
        }

        [Fact]
        public void GivenNullTitle_ShouldHaveValidationError()
        {

            _validator.ShouldHaveValidationErrorFor(model => model.Title, model);
        }

        [Fact]
        public void GivenInvalidItemType_ShouldHaveValidationError()
        {


            _validator.ShouldHaveValidationErrorFor(model => model.ItemType, model);
        }


        */


    }
}