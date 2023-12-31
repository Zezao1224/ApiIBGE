﻿using ApiIBGE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ApiIBGE.util
{
    /// <summary>
    /// Classe para utilidades do projeto
    /// </summary>
    public class ClsUtil
    {
        internal static Token GerarTokenJWT(string key)
        {
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            Token _token = new Token(stringToken.ToString());
            return _token;
        }

        /// <summary>
        /// Classe para gerar o Token JWT
        /// </summary>
        public class Token
        {
            /// <summary>
            /// Propriedade Bearer
            /// </summary>
            public string Bearer { get; set; }

            /// <summary>
            /// Construtor Token com bearer incluído
            /// </summary>
            /// <param name="bearer"></param>
            public Token(string bearer)
            {
                Bearer = bearer;
            }
        }


        internal static bool ValidaEmail(string _email)
        {
            Regex regex;          

            try
            {
                const string estrutura = @"^[a-zA-Z0-9._]+@[a-zA-Z0-9.-]+\.[a-z]{2,}$";
                regex = new Regex(estrutura);

                return regex.IsMatch(_email);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro em ClsUtil - ValidaEmail() " + ex.Message);
                return false;
            }
        }
    }
}
