using QuantityMeasurementAppRepoLayer;
using Microsoft.AspNetCore.Identity; 
using QuantityMeasurementAppModelLayer.DTO;
using QuantityMeasurementAppModelLayer.Entity;
using QuantityMeasurementAppBusinessLayer.Interface;
using System.Text.RegularExpressions;
using QuantityMeasurementAppBusinessLayer.Exceptions;


namespace QuantityMeasurementAppBusinessLayer.Services;

public class AuthService : IAuthService
{
    private readonly IJwtService _jwtService;
    private readonly IMeasurementHistoryRepository _repository;
    private readonly PasswordHasher<UserEntity> _passwordHasher;

    public AuthService(IJwtService jwtService,IMeasurementHistoryRepository repository)
    {
        _jwtService = jwtService;
        _repository = repository;
        _passwordHasher = new PasswordHasher<UserEntity>();
    }

    // private bool ValidateInfo(string email, string password, string fullName, string phone)
    // {
    //     if(string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(password) || 
    //         string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone) ||
    //         phone.Length != 10){
    //         return false;
    //     }
    //     string emailPattern = @"^[a-zA-Z][a-zA-Z0-9._%+-]+@[a-zA-Z0-9]+\.[a-zA-Z]{2,}$";

    //     if(!Regex.IsMatch(email, emailPattern)){
    //         return false;
    //     }
    //     return true;
    // }
    public bool Register(RegisterDTO registerDTO)
    {
        var fullName = registerDTO.FullName;
        var password = registerDTO.Password;
        var email = registerDTO.Email;
        var phone = registerDTO.Phone;

        
        UserEntity user = new UserEntity();
        
        user.FullName = fullName;
        user.Email = email;
        user.Phone = phone;
        user.Password = _passwordHasher.HashPassword(user, password);

        return _repository.SaveUser(user);
    }

    public string Login(LoginDTO loginDTO){
        var email = loginDTO.Email;
        var password = loginDTO.Password;

        UserEntity user = _repository.VerifyUser(email);

        if(user != null &&
         _passwordHasher.VerifyHashedPassword(user, user.Password, password) == PasswordVerificationResult.Success)
        {
            return _jwtService.GenerateToken(user);
        }
 
        throw new PasswordNotMatchException("Password Not Match");
    }
}