using IFitFusion.Domain.Entities;
using System.Data;

namespace FitFusion.Infrastructure.Data.Queries
{
    public static class UserQuery
    {
        public const string PasswordSign = @"
            SELECT 
                Id
                ,Name
                ,Email EmailStr
                ,Password PasswordStr
                ,Active
            FROM 
                Users
            WHERE
                Email = @EMAIL
                AND Password = @PASSWORD
                AND Active = 1                
        ";

        public const string CheckEmail = @"
            SELECT 
               1
            FROM 
                Users
            WHERE
                Email = @EMAIL             
        ";

        public const string Insert = @"
            INSERT INTO Users (Name, BirthDate, Gender, Email, Password, Active, Phone, Height, Weight, Goal)
            VALUES(@Name, @BirthDate, @Gender, @Email, @Password, @Active, @Phone, @Height, @Weight, @Goal)
        ";
    }
}