using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Vk.Base.Response;
using Vk.Base.Token;
using Vk.Data.Domain;
using Vk.Data.Uow;
using Vk.Operation.Cqrs;

namespace Vk.Operation.Command;

public class TokenCommandHandler :
    IRequestHandler<CreateTokenCommand, ApiResponse<TokenResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly JwtConfig jwtConfig;

    
    public TokenCommandHandler(IUnitOfWork unitOfWork,IOptionsMonitor<JwtConfig> jwtConfig)
    {
        this.unitOfWork = unitOfWork;
        this.jwtConfig = jwtConfig.CurrentValue;
    }


    public async Task<ApiResponse<TokenResponse>> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
    {
       var entity = await unitOfWork.CustomerRepository.GetAsQueryable()
           .Where(x => x.CustomerNumber == request.Model.UserNumber).SingleOrDefaultAsync(cancellationToken);
       
       if (entity == null)
        {
            return new ApiResponse<TokenResponse>("Error");
        }
       
        if (!entity.IsActive)
        {
            return new ApiResponse<TokenResponse>("Error");
        }
        
        string token = Token(entity);
        TokenResponse tokenResponse = new()
        {
            Token = token,
            ExpireDate = DateTime.Now.AddMinutes(jwtConfig.AccessTokenExpiration),
            UserNumber = entity.CustomerNumber,
            FullName = entity.CustomerFirstName + entity.CustomerLastName
                
        };
        return new ApiResponse<TokenResponse>(tokenResponse);
    }
    
    private string Token(Customer user)
    {
        Claim[] claims = GetClaims(user);
        var secret = Encoding.ASCII.GetBytes(jwtConfig.Secret);

        var jwtToken = new JwtSecurityToken(
            jwtConfig.Issuer,
            jwtConfig.Audience,
            claims,
            expires: DateTime.Now.AddMinutes(jwtConfig.AccessTokenExpiration),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
        );

        string accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        return accessToken;
    }
    
    private Claim[] GetClaims(Customer user)
    {
        var claims = new[]
        {
            new Claim("Id", user.Id.ToString()),
            new Claim("CustomerNumber", user.CustomerNumber.ToString()),
            new Claim("Role", user.CustomerLastName),
            new Claim("FullName", user.CustomerFirstName+user.CustomerLastName),
            new Claim(ClaimTypes.Role, user.CustomerLastName),
        };

        return claims;
    }
}