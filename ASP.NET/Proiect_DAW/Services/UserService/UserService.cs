using Proiect_DAW.Models.Constants;
using Proiect_DAW.Models.DTOs;
using Proiect_DAW.Models.Entities;
using Proiect_DAW.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Proiect_DAW.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly UserManager<User> _userManager;

        public UserService(
            UserManager<User> userManager,
            IRepositoryWrapper repository)
        {
            _userManager = userManager;
            _repository = repository;
        }

        public async Task<bool> RegisterUserAsync(RegisterUserDTO dto)
        {
            var registerUser = new User();

            registerUser.Email = dto.Email;
            registerUser.UserName = dto.Email;
            registerUser.FirstName = dto.FirstName;
            registerUser.LastName = dto.LastName;
            //System.Diagnostics.Debug.WriteLine(registerUser);

           


            var result = await _userManager.CreateAsync(registerUser, dto.Password);

            if (result.Succeeded)
            {

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("test.pmv5@gmail.com", "ACracLYfXKn6tp5yU7A6d1cQAFu8iJ");
                MailMessage msg = new MailMessage();
                msg.To.Add(registerUser.Email);
                msg.From = new MailAddress("test.pmv5@gmail.com");
                msg.Subject = "(Email test) Inregistrare realizata cu succes";
                msg.Body = "Inregistrarea dvs pe site-ul MobileRO,cu utilizatorul " + registerUser.UserName + " a fost realizata cu succes <br />Parola dvs. este: "+dto.Password;
                msg.IsBodyHtml = true;
                
                await client.SendMailAsync(msg);


                await _userManager.AddToRoleAsync(registerUser, UserRoleType.User);

                return true;
            }

            return false;
        }

        public async Task<string> LoginUser(LoginUserDTO dto)
        {
            User user = await _userManager.FindByEmailAsync(dto.Email);

            if (user != null)
            {
                user = await _repository.User.GetByIdWithRoles(user.Id);
                List<string> roles = user.UserRoles.Select(ur => ur.Role.Name).ToList();

                var newJti = Guid.NewGuid().ToString();
                var tokenHandler = new JwtSecurityTokenHandler();
                var signinkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("cheie customizabila pentru autentificare"));
                //"this is my custom secret key for auth"

                var token = GenerateJwtToken(signinkey, user, roles, tokenHandler, newJti);

                var passwordMatch = await _userManager.CheckPasswordAsync(user, dto.Password);

                if (passwordMatch == false)
                {
                    return "wrong password";
                }
                    

                _repository.SessionToken.Create(new SessionToken(newJti, user.Id, token.ValidTo));
                await _repository.SaveAsync();

                return tokenHandler.WriteToken(token);
            }

            return null;
        }

        private SecurityToken GenerateJwtToken(SymmetricSecurityKey signinkey, User user, List<string> roles, JwtSecurityTokenHandler tokenHandler, string newJti)
        {

            var subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, newJti)
            });

            foreach (var role in roles)
            {
                subject.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(signinkey, SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return token;
        }
    }
}
