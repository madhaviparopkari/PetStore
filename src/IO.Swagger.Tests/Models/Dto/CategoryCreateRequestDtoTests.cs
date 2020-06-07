using System;
using Xunit;

namespace IO.Swagger.Models
{
    public class CategoryCreateRequestDtoTests
    {
        CategoryCreateRequestDto testCategoryReqDto;

        CategoryCreateRequestDtoTests() {
            testCategoryReqDto = new CategoryCreateRequestDto();
        }    

        [Fact]
        public void validate_success() //happy path
        {
            //GIVEN
            testCategoryReqDto.Name = "testName";

            //WHEN
            try
            {
                testCategoryReqDto.Validate();
            }
            catch (Exception ex)
            {

                //THEN
                Assert.True(false, "Should not throw any exception but received one");
            }
        }

        [Fact]
        public void validate_fail_null_categoryName()
        {
            //GIVEN
            testCategoryReqDto.Name = null;
            string expectedErrorMessage = "Category name can not be null or empty.";

            //WHEN
            var ex = Assert.Throws<ArgumentException>(() => testCategoryReqDto.Validate());
            var actualErrorMessage = ex.Message;
        
            //THEN
            Assert.Equal(expectedErrorMessage, actualErrorMessage);
        }

        [Fact]
        public void validate_fail_empty_categoryName()
        {
            //GIVEN
            testCategoryReqDto.Name = string.Empty;
            string expectedErrorMessage = "Category name can not be null or empty.";

            //WHEN
            var ex = Assert.Throws<ArgumentException>(() => testCategoryReqDto.Validate());
            var actualErrorMessage = ex.Message;
        
            //THEN
            Assert.Equal(expectedErrorMessage, actualErrorMessage);
        }
    }
}