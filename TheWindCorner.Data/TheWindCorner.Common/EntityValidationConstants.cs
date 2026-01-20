namespace TheWindCorner.Common
{
       
    public static class EntityValidationConstants
    {
        public static class Item
        {
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 80; 

            public const int SizeMinLength = 2;
            public const int SizeMaxLength = 50;

            public const int BrandMinLength = 3;
            public const int BrandMaxLength = 80;

            public const int ModelMinLength = 2;
            public const int ModelMaxLength = 80;

            public const int MinYear = 2000;

            public const string PriceMinValue = "1";
            public const string PriceMaxValue = "10000";

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 1000;

        }

        public static class WantedItem
        {
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 80;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 1000;
        }

        public static class ItemComment
        {
            public const int ContentMinLength = 2;
            public const int ContentMaxLength = 500;
        }

        public static class WantedItemComment
        {
            public const int ContentMinLength = 2;
            public const int ContentMaxLength = 500;
        }

        public static class SpotComment
        {
            public const int ContentMinLength = 2;
            public const int ContentMaxLength = 1000;
        }

        public static class EventComment
        {
            public const int ContentMinLength = 2;
            public const int ContentMaxLength = 1000;
        }

        public static class User
        {
            public const int UsernameMinLength = 3;
            public const int UsernameMaxLength = 20;

            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 50;

            public const int LastNameMinLength = 2;
            public const int LastNameMaxLength = 50;

            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;

            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 64;

            public const int EmailMinLength = 5;
            public const int EmailMaxLength = 320;
        }

        public static class Image
        {
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 100;

            public const int TextMinLength = 10;
            public const int TextMaxLength = 1000;
        }

        public static class Spot 
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 100;

            public const int DescriptionMinLength = 3;
            public const int DescriptionMaxLength = 1000;

            public const double MinLatitude = -90;
            public const double MaxLatitude = 90;

            public const double MinLongitude = -180;
            public const double MaxLongitude = 180;
        }

        public static class Event
        {
            public const int TitleMinLength = 2;
            public const int TitleMaxLength = 50;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 500;

            public const int FullInfoMinLength = 10;
            public const int FullInfoMaxLength = 2000;

            public const int LocationMinLength = 2;
            public const int LocationMaxLength = 100;
        }

        
    }
}
