namespace TheWindCorner.Common
{
    
    public static class EntityValidationMessages
    {

        public static class Item
        {
            public const string YearValidationMassage = "Please enter a valid year, 2000 or later!";
            public const string CategoryValidationMassage = "Invalid item category!";
            public const string TypeValidationMassage = "Invalid item type!";
            public const string TitleMinLengthMassage = "Item Title should be at least 3 characters long!";
            public const string TitleMaxLengthMassage = "Item Title should not be more than 80 characters long!";
            public const string SizeMinLengthMassage = "Item Size should be at least 2 characters long!";
            public const string SizeMaxLengthMassage = "Item Size should not be more than 50 characters long!";
            public const string BrandMinLengthMassage = "Item Brand should be at least 3 characters long!";
            public const string BrandMaxLengthMassage = "Item Brand should not be more than 80 characters long!";
            public const string DescriptionMinLengthMassage = "Item Description should be at least 10 characters long!";
            public const string DescriptionMaxLengthMassage = "Item Description should not be more than 1000 characters long!";
        }

        public static class ItemComment
        {
            public const string ContentMinLengthMassage = "Item Comment should be at least 2 characters long!";
            public const string ContentMaxLengthMassage = "Item Comment should not be more than 500 characters long!";
        }

        public static class WantedItemComment
        {
            public const string ContentMinLengthMassage = "Wanted item comment should be at least 2 characters long!";
            public const string ContentMaxLengthMassage = "Wanted item comment should not be more than 500 characters long!";
        }

        public static class SpotComment
        {
            public const string ContentMinLengthMassage = "Item Comment should be at least 2 characters long!";
            public const string ContentMaxLengthMassage = "Item Comment should not be more than 1000 characters long!";
        }

        public static class EventComment
        {
            public const string ContentMinLengthMassage = "Event Comment should be at least 2 characters long!";
            public const string ContentMaxLengthMassage = "Event Comment should not be more than 1000 characters long!";
        }

        public static class Spot
        {
            public const string NameMinLengthMessage = "Name should be at least 3 characters long!";
            public const string NameMaxLengthMessage = "Name should not be more than 100 characters long!";

            public const string DescriptionMinLengthMessage = "Description should be at least 3 characters long!";
            public const string DescriptionMaxLengthMessage = "Description should not be more than 1000 characters long!";

            public const string LatitudeValidationMessage = "Latitude must be between -90 and 90 degrees.";
            public const string LongitudeValidationMessage = "Longitude must be between -180 and 180 degrees.";
        }


        public static class User
        {
            public const string UsernameMinLengthMessage = "Item Title should be at least 3 characters long!";
            public const string UsernameMaxLengthMessage = "Wanted item comment should not be more than 500 characters long!";

            public const string FirstNameMinLengthMessage = "Item Title should be at least 2 characters long!";
            public const string FirstNameMaxLengthMessage = "Wanted item comment should not be more than 50 characters long!";

            public const string LastNameMinLengthMessage = "Item Title should be at least 2 characters long!";
            public const string LastNameMaxLengthMessage = "Wanted item comment should not be more than 50 characters long!";

            public const string PhoneNumberMinLengthMessage = "Phone number should be at least 7 characters long!";
            public const string PhoneNumberMaxLengthMessage = "Phone number should not be more than 15 characters long!";

            public const string PasswordMinLengthMessage = "Password should be at least 6 characters long!";
            public const string PasswordMaxLengthMessage = "Password should not be more than 64 characters long!";

            public const string EmailMinLengthMessage = "Email should be at least 5 characters long!";
            public const string EmailMaxLengthMessage = "Email should not be more than 320 characters long!";
        }

        public static class Event
        {
            public const string TitleMinLengthMassage = "Title should be at least 2 characters long!";
            public const string TitleMaxLengthMassage = "Title should not be more than 50 characters long!";

            public const string DescriptionMinLengthMassage = "Description should be at least 10 characters long!";
            public const string DescriptionMaxLengthMassage = "Description should not be more than 500 characters long!";

            public const string FullInfoMinLengthMassage = "FullInfo should be at least 10 characters long!";
            public const string FullInfoMaxLengthMassage = "FullInfo should not be more than 2000 characters long!";

            public const string LocationMinLengthMassage = "Location should be at least 2 characters long!";
            public const string LocationMaxLengthMassage = "Location should not be more than 100 characters long!";
        }

    }
}
